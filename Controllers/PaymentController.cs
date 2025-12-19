using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ColdStorageManagement.Data;
using ColdStorageManagement.Models;

namespace ColdStorageManagement.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaymentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Helper: Get current user ID
        private int? GetCurrentUserId()
        {
            return HttpContext.Session.GetInt32("UserId");
        }

        // GET: Create Payment
        public async Task<IActionResult> CreatePayment(int productId, decimal amount, string paymentType = "Storage Fee")
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == productId && p.UserId == userId);

            if (product == null)
                return NotFound();

            ViewBag.Product = product;
            ViewBag.Amount = amount;
            ViewBag.PaymentType = paymentType;

            return View();
        }

        // POST: Process Payment
        [HttpPost]
        public async Task<IActionResult> ProcessPayment(int productId, decimal amount, string paymentType)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
                return RedirectToAction("Login", "Account");

            var product = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == productId && p.UserId == userId);

            if (product == null)
                return NotFound();

            // Create payment record
            var payment = new Payment
            {
                ProductId = productId,
                UserId = userId.Value,
                Amount = amount,
                PaymentType = paymentType,
                Status = "Completed",
                PaymentDate = DateTime.Now
            };

            _context.Payments.Add(payment);

            // Update product
            product.PaymentCompleted = true;
            
            // If this is a removal payment, mark product as inactive
            if (paymentType == "Removal Fee")
            {
                product.IsActive = false;
            }

            await _context.SaveChangesAsync();

            TempData["Message"] = "Payment completed successfully!";
            return RedirectToAction("Dashboard", "User");
        }

        // GET: Payment Success
        public IActionResult Success()
        {
            return View();
        }

        // GET: Payment Failed
        public IActionResult Failed()
        {
            return View();
        }
    }
}