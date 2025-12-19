using System.ComponentModel.DataAnnotations;

namespace ColdStorageManagement.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [Display(Name = "Username")]
        public string Username { get; set; } = "";

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone")]
        public string Phone { get; set; } = "";

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Address")]
        public string Address { get; set; } = "";

        [Display(Name = "Full Name")]
        public string? FullName { get; set; } // Make nullable

        [Display(Name = "Role")]
        public string Role { get; set; } = "User";

        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Active")]
        public bool IsActive { get; set; } = true;

        [Display(Name = "Display Name")]
        public string DisplayName => !string.IsNullOrEmpty(FullName) ? FullName : Username;
    }
}