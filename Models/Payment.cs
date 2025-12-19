using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColdStorageManagement.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        public int? ProductId { get; set; }
        
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        public int UserId { get; set; }
        
        [ForeignKey("UserId")] // ADD THIS
        public User? User { get; set; } // ADD THIS

        public decimal Amount { get; set; }

        public string Currency { get; set; } = "BDT";

        public string PaymentType { get; set; } = "Storage Fee";

        public string Status { get; set; } = "Pending";

        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}