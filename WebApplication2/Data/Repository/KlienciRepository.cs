using WebApplication2.Data;
using WebApplication2.Data.Repository;
using WebApplication2.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Data.Repository
{
    public class KlienciRepository : IKlienciRepository
    {
        private readonly AppDbContext _context;

        public KlienciRepository(AppDbContext context)
        {
            _context = context;
        }

       
        public IEnumerable<Klienci> GetAll()
        {
            
            return _context.Klienci.ToList();
        }

        
        public Klienci GetById(int id)
        {
            
            return _context.Klienci.FirstOrDefault(k => k.IdKlienta == id);
        }

        // Dodawanie nowego klienta
        public void Insert(Klienci klienci)
        {
            if (klienci != null)
            {
                _context.Klienci.Add(klienci);
            }
        }

      
        public void Update(Klienci klienci)
        {
            if (klienci != null)
            {
                var existingKlient = _context.Klienci.FirstOrDefault(k => k.IdKlienta == klienci.IdKlienta);
                if (existingKlient != null)
                {
                
                    _context.Klienci.Update(klienci);
                }
            }
        }

        
        public void Delete(int id)
        {
            var klient = _context.Klienci.FirstOrDefault(k => k.IdKlienta == id);
            if (klient != null)
            {
                _context.Klienci.Remove(klient);
            }
        }

        // Zapisanie zmian do bazy danych
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}