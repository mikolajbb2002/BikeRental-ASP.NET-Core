using WebApplication2.Data;
using WebApplication2.Data.Repository;
using WebApplication2.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Data.Repository
{
    public class RoweryRepository : IRoweryRepository
    {
        private readonly AppDbContext _context;

        public RoweryRepository(AppDbContext context)
        {
            _context = context;
        }

        // Pobieranie wszystkich klientów
        public IEnumerable<Rowery> GetAll()
        {
            // Używamy ToList() aby wykonać zapytanie i zwrócić listę
            return _context.Rowery.ToList();
        }

        // Pobieranie klienta po ID
        public Rowery GetById(int id)
        {
            // Zwracamy pierwszy lub null, jeśli nie znaleziono
            return _context.Rowery.FirstOrDefault(k => k.IdRoweru == id);
        }

        // Dodawanie nowego klienta
        public void Insert(Rowery Rowery)
        {
            if (Rowery != null)
            {
                _context.Rowery.Add(Rowery);
            }
        }

        // Aktualizacja klienta
        public void Update(Rowery Rowery)
        {
            if (Rowery != null)
            {
                var existingKlient = _context.Rowery.FirstOrDefault(k => k.IdRoweru == Rowery.IdRoweru);
                if (existingKlient != null)
                {
                    // Aktualizujemy tylko jeśli istnieje w bazie
                    _context.Rowery.Update(Rowery);
                }
            }
        }

        // Usuwanie klienta
        public void Delete(int id)
        {
            var klient = _context.Rowery.FirstOrDefault(k => k.IdRoweru == id);
            if (klient != null)
            {
                _context.Rowery.Remove(klient);
            }
        }

        // Zapisanie zmian do bazy danych
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}