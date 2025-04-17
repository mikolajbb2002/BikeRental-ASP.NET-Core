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
            context.SaveChanges();
        }
    }
}