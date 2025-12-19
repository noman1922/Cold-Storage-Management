using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColdStorageManagement.Data;
using ColdStorageManagement.Models;

namespace ColdStorageManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper: Get current user ID
        private int? GetCurrentUserId()
        {
            return HttpContext.Session.GetInt32("UserId");
        }

        // Dashboard
        public async Task<IActionResult> Dashboard()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return RedirectToAction("Login", "Account");

            // Get active products
            var products = await _context.Products
                .Include(p => p.ColdRoom)
                .Where(p => p.UserId == userId && p.IsActive)
                .ToListAsync();

            ViewBag.User = user;
            ViewBag.Products = products;
            ViewBag.ProductCount = products.Count;

            return View();
        }

        // Add Product
        public async Task<IActionResult> AddProduct()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            ViewBag.ColdRooms = await _context.ColdRooms
                .Where(r => r.IsAvailable)
                .ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                product.UserId = userId.Value;
                product.EntryDate = DateTime.Now;
                product.IsActive = true;

                var room = await _context.ColdRooms.FindAsync(product.ColdRoomId);
                if (room != null)
                {
                    product.PricePerDay = room.PricePerKgPerDay;
                    product.TotalAmountDue = product.Quantity * product.PricePerDay * 30;
                }

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                TempData["Message"] = "Product added successfully!";
                return RedirectToAction("Dashboard");
            }

            ViewBag.ColdRooms = await _context.ColdRooms.Where(r => r.IsAvailable).ToListAsync();
            return View(product);
        }

        // Product Details
        public async Task<IActionResult> ProductDetails(int id)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var product = await _context.Products
                .Include(p => p.ColdRoom)
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // Remove Product
        public async Task<IActionResult> RemoveProduct(int id)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var product = await _context.Products
                .Include(p => p.ColdRoom)
                .FirstOrDefaultAsync(p => p.Id == id && p.UserId == userId && p.IsActive);

            if (product == null)
                return NotFound();

            var daysStored = (DateTime.Now - product.EntryDate).Days;
            var storageAmount = product.Quantity * product.PricePerDay * daysStored;
            var removalFee = 100;
            var totalAmount = storageAmount + removalFee;

            ViewBag.Product = product;
            ViewBag.DaysStored = daysStored;
            ViewBag.StorageAmount = storageAmount;
            ViewBag.RemovalFee = removalFee;
            ViewBag.TotalAmount = totalAmount;

            return View();
        }

        // Process Removal (FIXED LINE 282)
       [HttpPost]
public async Task<IActionResult> ProcessRemoval(int productId, string paymentMethod = "cash")
{
    var userId = GetCurrentUserId();
    if (userId == null)
        return RedirectToAction("Login", "Account");

    var product = await _context.Products
        .FirstOrDefaultAsync(p => p.Id == productId && p.UserId == userId && p.IsActive);

    if (product == null)
        return NotFound();

    // Calculate amount
    var daysStored = (DateTime.Now - product.EntryDate).Days;
    var storageAmount = product.Quantity * product.PricePerDay * daysStored;
    var removalFee = 100;
    var totalAmount = storageAmount + removalFee;

    // Create payment record
    var payment = new Payment
    {
        ProductId = productId,
        UserId = userId.Value,
        Amount = totalAmount,
        PaymentType = $"Removal Fee ({paymentMethod.ToUpper()})",
        Status = "Completed",
        PaymentDate = DateTime.Now
    };

    _context.Payments.Add(payment);

    // Mark product as removed
    product.IsActive = false;
    product.PaymentCompleted = true;

    // Return capacity to cold room
    var room = await _context.ColdRooms.FindAsync(product.ColdRoomId);
    if (room != null)
    {
        room.AvailableCapacity += product.Quantity;
        _context.Update(room);
    }

    await _context.SaveChangesAsync();

    // Redirect to receipt
    return RedirectToAction("Receipt", new { paymentId = payment.Id });
}

        // Receipt (FIXED VERSION)
        public async Task<IActionResult> Receipt(int paymentId)
{
    var userId = GetCurrentUserId();
    if (userId == null)
        return RedirectToAction("Login", "Account");

    // Get payment with product info
    var payment = await _context.Payments
        .Include(p => p.Product)
        .FirstOrDefaultAsync(p => p.Id == paymentId && p.UserId == userId);

    if (payment == null)
        return NotFound();

    // Calculate days stored
    int daysStored = 0;
    if (payment.Product != null)
    {
        daysStored = (DateTime.Now - payment.Product.EntryDate).Days;
    }

    // Pass data to view
    ViewBag.Payment = payment;
    ViewBag.DaysStored = daysStored;
    ViewBag.ReceiptDate = DateTime.Now;
    ViewBag.ProductName = payment.Product?.Name ?? "Product";
    ViewBag.ProductQuantity = payment.Product?.Quantity ?? 0;
    ViewBag.RemovalFee = 100; // Fixed removal fee

    return View();
}

        // Profile
        public async Task<IActionResult> Profile()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return RedirectToAction("Login", "Account");

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(User updatedUser)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return RedirectToAction("Login", "Account");

            user.FullName = updatedUser.FullName;
            user.Phone = updatedUser.Phone;
            user.Address = updatedUser.Address;

            await _context.SaveChangesAsync();

            TempData["Message"] = "Profile updated successfully!";
            return RedirectToAction("Profile");
        }

        // Change Password
        public IActionResult ChangePassword()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
                return RedirectToAction("Login", "Account");

            if (!BCrypt.Net.BCrypt.Verify(currentPassword, user.Password))
            {
                TempData["Error"] = "Current password is incorrect!";
                return View();
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Password changed successfully!";
            return View();
        }
    }
}