using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class WypozyczeniaController : Controller
    {
        private readonly AppDbContext _context;

        public WypozyczeniaController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var wypozyczenia = await _context.Wypozyczenia.ToListAsync();
            return View(wypozyczenia);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var wypozyczenie = await _context.Wypozyczenia
                .FirstOrDefaultAsync(m => m.IdWypozyczenia == id);

            if (wypozyczenie == null)
                return NotFound();

            return View(wypozyczenie);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Wypozyczenia wypozyczenie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wypozyczenie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wypozyczenie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var wypozyczenie = await _context.Wypozyczenia.FindAsync(id);
            if (wypozyczenie == null)
                return NotFound();

            return View(wypozyczenie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Wypozyczenia wypozyczenie)
        {
            if (id != wypozyczenie.IdWypozyczenia)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wypozyczenie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WypozyczenieExists(wypozyczenie.IdWypozyczenia))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(wypozyczenie);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var wypozyczenie = await _context.Wypozyczenia
                .FirstOrDefaultAsync(m => m.IdWypozyczenia == id);

            if (wypozyczenie == null)
                return NotFound();

            return View(wypozyczenie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wypozyczenie = await _context.Wypozyczenia.FindAsync(id);
            _context.Wypozyczenia.Remove(wypozyczenie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WypozyczenieExists(int id)
        {
            return _context.Wypozyczenia.Any(e => e.IdWypozyczenia == id);
        }
    }
}