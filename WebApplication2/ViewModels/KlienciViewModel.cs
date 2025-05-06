using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.ViewModels
{
    public class KlienciViewModel
    {
        public int IdKlienta { get; set; }

        public string Imie { get; set; }

        public string Nazwisko { get; set; }

        public string Email { get; set; }

        public string Telefon { get; set; }

    }
}