using System.ComponentModel.DataAnnotations;

namespace ColdStorageManagement.Models
{
    public class ColdRoom
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Room Name")]
        public string Name { get; set; } = "";

        [Required]
        [Display(Name = "Room Type")]
        public string Type { get; set; } = "Frozen";

        [Required]
        [Display(Name = "Temperature (°C)")]
        public decimal Temperature { get; set; }

        [Required]
        [Display(Name = "Total Capacity (kg)")]
        public decimal Capacity { get; set; }

        [Display(Name = "Available Capacity (kg)")]
        public decimal AvailableCapacity { get; set; }

        [Required]
        [Display(Name = "Price per kg per day")]
        public decimal PricePerKgPerDay { get; set; }

        [Display(Name = "Is Available")]
        public bool IsAvailable { get; set; } = true;

        [Display(Name = "Description")]
        public string? Description { get; set; } // Make nullable with ?
    }
}