using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        [Display(Name = "Nazwa użytkownika")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Adres email jest wymagany")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu email")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Display(Name = "Rola")]
        public string Role { get; set; }
    }
}