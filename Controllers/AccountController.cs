using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColdStorageManagement.Data;
using ColdStorageManagement.Models;

namespace ColdStorageManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(string phone, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Phone == phone && u.IsActive);

            if (user == null)
            {
                ViewBag.Error = "Invalid phone number or password";
                return View();
            }

            // ADMIN LOGIN: Check by phone OR username
            if ((user.Phone == "01700000000" || user.Username == "admin") && password == "admin123")
            {
                // Set session
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("Phone", user.Phone);
                HttpContext.Session.SetString("UserRole", "Admin");
                HttpContext.Session.SetString("DisplayName", user.DisplayName);

                return RedirectToAction("Dashboard", "Admin");
            }

            // Check if password is BCrypt hashed (starts with $2)
            if (user.Password.StartsWith("$2"))
            {
                // Try BCrypt verification for regular users
                if (BCrypt.Net.BCrypt.Verify(password, user.Password))
                {
                    // Set session for regular user
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Phone", user.Phone);
                    HttpContext.Session.SetString("UserRole", user.Role);
                    HttpContext.Session.SetString("DisplayName", user.DisplayName);

                    return RedirectToAction("Dashboard", "User");
                }
            }
            else
            {
                // Plain text password check (for old users)
                if (user.Password == password)
                {
                    // Set session
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Phone", user.Phone);
                    HttpContext.Session.SetString("UserRole", user.Role);
                    HttpContext.Session.SetString("DisplayName", user.DisplayName);

                    return RedirectToAction("Dashboard", "User");
                }
            }

            ViewBag.Error = "Invalid phone number or password";
            return View();
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /Account/Register
        [HttpPost]
        public async Task<IActionResult> Register(User user, string ConfirmPassword)
        {
            // Manual password confirmation check
            if (user.Password != ConfirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match");
                return View(user);
            }

            if (ModelState.IsValid)
            {
                // Check if phone already exists
                if (await _context.Users.AnyAsync(u => u.Phone == user.Phone))
                {
                    ModelState.AddModelError("Phone", "Phone number already registered");
                    return View(user);
                }

                // Check if username already exists
                if (await _context.Users.AnyAsync(u => u.Username == user.Username))
                {
                    ModelState.AddModelError("Username", "Username already taken");
                    return View(user);
                }

                // Hash the password before saving
                user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                
                // Set default values
                user.Role = "User"; // Default role
                user.CreatedDate = DateTime.UtcNow;
                user.IsActive = true;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                // Set session variables
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("Phone", user.Phone);
                HttpContext.Session.SetString("UserRole", user.Role);
                HttpContext.Session.SetString("DisplayName", user.DisplayName);

                return RedirectToAction("Dashboard", "User");
            }
            
            return View(user);
        }

        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}