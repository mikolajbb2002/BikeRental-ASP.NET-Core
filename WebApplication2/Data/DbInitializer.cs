using System;
using System.Linq;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            // Upewnij się, że baza danych istnieje
            context.Database.EnsureCreated();

            // Sprawdź, czy są już dane w tabeli Klienci, aby nie dodać ich wielokrotnie
            if (context.Klienci.Any())
            {
                return; // Jeśli są dane, zakończ inicjalizację
            }

            // Dodaj nowych klientów
            var klienci = new Klienci[]
            {
                new Klienci { Imie = "Adam", Nazwisko = "Reszta", Email = "adamreszta@gmail.com", Telefon = "111222333" },
                new Klienci { Imie = "Władek", Nazwisko = "Nowak", Email = "wladeknowak@gmail.com", Telefon = "222333444" },
                new Klienci { Imie = "Igor", Nazwisko = "Kowalski", Email = "igorkowalski@gmail.com", Telefon = "999888777" },
                new Klienci { Imie = "Marian", Nazwisko = "Zając", Email = "marian@gmail.com", Telefon = "123123123" },
            };

            // Dodaj klientów do kontekstu
            context.Klienci.AddRange(klienci);

            // Zapisz zmiany do bazy danych
            context.SaveChanges();
        }
    }
}