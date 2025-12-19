using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColdStorageManagement.Data;
using ColdStorageManagement.Models;

namespace ColdStorageManagement.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper: Check if user is admin
        private bool IsAdmin()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null) return false;

            var user = _context.Users.Find(userId);
            return user?.Role == "Admin";
        }

        // GET: Admin Dashboard
        public async Task<IActionResult> Dashboard()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            try
            {
                // Get all payments
                var payments = await _context.Payments
                    .Include(p => p.Product)
                    .OrderByDescending(p => p.PaymentDate)
                    .ToListAsync();

                // Get all products in storage
                var products = await _context.Products
                    .Where(p => p.IsActive)
                    .OrderByDescending(p => p.EntryDate)
                    .ToListAsync();

                // Get all users
                var users = await _context.Users
                    .OrderByDescending(u => u.CreatedDate)
                    .ToListAsync();

                // Get all cold rooms
                var coldRooms = await _context.ColdRooms.ToListAsync();

                // Calculate totals
                var totalPayments = payments.Sum(p => p.Amount);
                var totalProducts = products.Count;
                var totalUsers = users.Count;
                var totalQuantity = products.Sum(p => p.Quantity);
                
                // Calculate total storage days
                var totalStorageDays = 0;
                foreach (var product in products)
                {
                    totalStorageDays += (DateTime.Now - product.EntryDate).Days;
                }
                
                var todayPayments = payments
                    .Where(p => p.PaymentDate.Date == DateTime.Today.Date)
                    .Sum(p => p.Amount);

                ViewBag.Payments = payments;
                ViewBag.Products = products;
                ViewBag.Users = users;
                ViewBag.TotalPayments = totalPayments;
                ViewBag.TotalProducts = totalProducts;
                ViewBag.TotalUsers = totalUsers;
                ViewBag.TotalQuantity = totalQuantity;
                ViewBag.TotalStorageDays = totalStorageDays;
                ViewBag.TodayPayments = todayPayments;
                ViewBag.TotalRooms = coldRooms.Count;

                return View();
            }
            catch (Exception ex)
            {
                // Return empty data on error
                ViewBag.Payments = new List<Payment>();
                ViewBag.Products = new List<Product>();
                ViewBag.Users = new List<User>();
                ViewBag.TotalPayments = 0;
                ViewBag.TotalProducts = 0;
                ViewBag.TotalUsers = 0;
                ViewBag.TotalQuantity = 0;
                ViewBag.TotalStorageDays = 0;
                ViewBag.TodayPayments = 0;
                ViewBag.TotalRooms = 0;

                return View();
            }
        }

        // GET: All Users
        public async Task<IActionResult> Users()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            var users = await _context.Users
                .OrderByDescending(u => u.CreatedDate)
                .ToListAsync();

            return View(users);
        }

        // GET: Edit User
        public async Task<IActionResult> EditUser(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        // POST: Update User
        [HttpPost]
        public async Task<IActionResult> UpdateUser(User user)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null)
                return NotFound();

            existingUser.Username = user.Username;
            existingUser.FullName = user.FullName ?? "";
            existingUser.Phone = user.Phone;
            existingUser.Address = user.Address;
            existingUser.Role = user.Role;
            existingUser.IsActive = user.IsActive;

            await _context.SaveChangesAsync();

            TempData["Success"] = "User updated successfully!";
            return RedirectToAction("Users");
        }

        // GET: Toggle User Status
        public async Task<IActionResult> ToggleUserStatus(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            user.IsActive = !user.IsActive;
            await _context.SaveChangesAsync();

            TempData["Success"] = $"User {(user.IsActive ? "activated" : "deactivated")} successfully!";
            return RedirectToAction("Users");
        }

        // GET: All Products in Storage
        public async Task<IActionResult> StorageProducts()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            var products = await _context.Products
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.EntryDate)
                .ToListAsync();

            return View(products);
        }

        // GET: Payment History
        public async Task<IActionResult> Payments()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            var payments = await _context.Payments
                .Include(p => p.Product)
                .OrderByDescending(p => p.PaymentDate)
                .ToListAsync();

            return View(payments);
        }

        // GET: Cold Rooms Management
        public async Task<IActionResult> ColdRooms()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            var rooms = await _context.ColdRooms
                .OrderBy(r => r.Type)
                .ThenBy(r => r.Name)
                .ToListAsync();

            return View(rooms);
        }

        // GET: Create Cold Room Form
        public IActionResult CreateRoom()
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            return View();
        }

        // POST: Create New Cold Room
        [HttpPost]
        public async Task<IActionResult> CreateRoom(ColdRoom room)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                room.AvailableCapacity = room.Capacity;
                room.IsAvailable = true;

                _context.ColdRooms.Add(room);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Cold room created successfully!";
                return RedirectToAction("ColdRooms");
            }

            return View(room);
        }

        // GET: Edit Cold Room
        public async Task<IActionResult> EditRoom(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            var room = await _context.ColdRooms.FindAsync(id);
            if (room == null)
                return NotFound();

            return View(room);
        }

        // POST: Update Cold Room
        [HttpPost]
        public async Task<IActionResult> UpdateRoom(ColdRoom room)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            var existingRoom = await _context.ColdRooms.FindAsync(room.Id);
            if (existingRoom == null)
                return NotFound();

            existingRoom.Name = room.Name;
            existingRoom.Type = room.Type;
            existingRoom.Temperature = room.Temperature;
            existingRoom.Capacity = room.Capacity;
            existingRoom.PricePerKgPerDay = room.PricePerKgPerDay;
            existingRoom.IsAvailable = room.IsAvailable;

            if (room.Capacity != existingRoom.Capacity)
            {
                var capacityDifference = room.Capacity - existingRoom.Capacity;
                existingRoom.AvailableCapacity += capacityDifference;
                
                if (existingRoom.AvailableCapacity < 0)
                    existingRoom.AvailableCapacity = 0;
            }

            await _context.SaveChangesAsync();

            TempData["Success"] = "Cold room updated successfully!";
            return RedirectToAction("ColdRooms");
        }

        // GET: Toggle Room Availability
        public async Task<IActionResult> ToggleRoomStatus(int id)
        {
            if (!IsAdmin())
                return RedirectToAction("Login", "Account");

            var room = await _context.ColdRooms.FindAsync(id);
            if (room == null)
                return NotFound();

            room.IsAvailable = !room.IsAvailable;
            await _context.SaveChangesAsync();

            TempData["Success"] = $"Cold room {(room.IsAvailable ? "activated" : "deactivated")} successfully!";
            return RedirectToAction("ColdRooms");
        }
    }
}