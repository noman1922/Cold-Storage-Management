using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ColdStorageManagement.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = "";

        [Required]
        public string Category { get; set; } = "";

        [Required]
        public decimal Quantity { get; set; }

        public decimal PricePerDay { get; set; }

        public DateTime EntryDate { get; set; } = DateTime.Now;

        public int UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int ColdRoomId { get; set; }
        
        [ForeignKey("ColdRoomId")]
        public ColdRoom? ColdRoom { get; set; }

        public bool IsActive { get; set; } = true;
        
        public bool PaymentCompleted { get; set; } = false;
        
        public decimal TotalAmountDue { get; set; } = 0;
    }
}