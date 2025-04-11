using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels
{
    public class KlienciViewModel
    {
        public int IdKlienta { get; set; }

        [Required(ErrorMessage = "Imię jest wymagane.")]
        public string Imie { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane.")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Adres e-mail jest wymagany.")]
        [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu e-mail.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Numer telefonu jest wymagany.")]
        [Phone(ErrorMessage = "Nieprawidłowy format numeru telefonu.")]
        public string Telefon { get; set; }

    }
}