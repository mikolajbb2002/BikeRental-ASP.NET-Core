using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModels;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class KlienciController : Controller
    {
        private readonly IKlienciService _service;

        public KlienciController(IKlienciService service)
        {
            _service = service;
        }

        [HttpGet]
       
        public async Task<IActionResult> Index()
        {
            var klienci = await _service.GetAllAsync();
            var viewModel = klienci.Select(k => new KlienciViewModel
            {
                IdKlienta = k.IdKlienta,
                Imie = k.Imie,
                Nazwisko = k.Nazwisko,
                Email = k.Email,
                Telefon = k.Telefon,
               
            }).ToList();

            return View(viewModel);
        }

        [HttpGet]
    
        public IActionResult Create() => View();

        [HttpPost]
     
        public async Task<IActionResult> Create(KlienciViewModel model)
        {
            if (ModelState.IsValid)
            {
                var klient = new Klienci
                {
                    IdKlienta = model.IdKlienta,
                    Imie = model.Imie,
                    Nazwisko = model.Nazwisko,
                    Email = model.Email,
                    Telefon = model.Telefon,
                  
                };

                await _service.CreateAsync(klient);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}