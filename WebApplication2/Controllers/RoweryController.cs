using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Data.Repository;
using WebApplication2.Models;

namespace WebApplication2.Controllers  // ✅ Upewnij się, że przestrzeń nazw jest zgodna z projektem
{
    public class RoweryController : Controller
    {
        private readonly IRoweryRepository _roweryRepository;

        // ✅ Konstruktor obsługujący Dependency Injection
        public RoweryController(IRoweryRepository roweryRepository)
        {
            _roweryRepository = roweryRepository;
        }

        // ✅ Akcja zwracająca listę klientów
        [HttpGet]
        public IActionResult Index()
        {
            var model = _roweryRepository.GetAll();
            return View(model);
        }

        // ✅ Wyświetlanie formularza dodawania klienta
        [HttpGet]
        public IActionResult AddRowery()
        {
            return View();
        }

        // ✅ Obsługa zapisu nowego klienta
        [HttpPost]
        public IActionResult AddRowery(Rowery model)
        {
            if (ModelState.IsValid)
            {
                _roweryRepository.Insert(model);
                _roweryRepository.Save();
                return RedirectToAction("Index");  // 🔹 Poprawione przekierowanie
            }
            return View(model);
        }

        // ✅ Edycja klienta - pobranie danych
        [HttpGet]
        public IActionResult EditRowery(int id)
        {
            var model = _roweryRepository.GetById(id);
            if (model == null)
            {
                return NotFound();  // 🔹 Obsługa błędu, gdy klient nie istnieje
            }
            return View(model);
        }

        // ✅ Obsługa edycji klienta
        [HttpPost]
        public IActionResult EditRowery(Rowery model)
        {
            if (ModelState.IsValid)
            {
                _roweryRepository.Update(model);
                _roweryRepository.Save();
                return RedirectToAction("Index");  // 🔹 Poprawione przekierowanie
            }
            return View(model);
        }

        // ✅ Usuwanie klienta - potwierdzenie
        [HttpGet]
        public IActionResult DeleteRowery(int id)
        {
            var model = _roweryRepository.GetById(id);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // ✅ Obsługa usunięcia klienta
        [HttpPost, ActionName("DeleteRowery")]
        public IActionResult DeleteConfirmed(int id)
        {
            _roweryRepository.Delete(id);
            _roweryRepository.Save();
            return RedirectToAction("Index");  // 🔹 Poprawione przekierowanie
        }
    }
}
