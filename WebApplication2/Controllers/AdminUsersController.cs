using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModels;
using WebApplication2.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WebApplication2.Controllers
{
   
    public class AdminUsersController : Controller
    {
        private readonly IKlienciService _service;
        
        public AdminUsersController(IKlienciService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Authorize(Policy = "WyzszeUpr")]
        public async Task<IActionResult> Index()
        {
            var klienci = await _service.GetAllAsync();
            var viewModel = klienci.Adapt<List<KlienciViewModel>>();

            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(KlienciViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var klient = model.Adapt<Klienci>();

            await _service.CreateAsync(klient);
            TempData["Success"] = "Użytkownik został pomyślnie utworzony.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var klient = await _service.GetByIdAsync(id);
            if (klient == null)
            {
                return NotFound();
            }

            var model = klient.Adapt<KlienciViewModel>();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(KlienciViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var klient = model.Adapt<Klienci>();
            await _service.UpdateAsync(klient);
            TempData["Success"] = "Dane użytkownika zostały pomyślnie zaktualizowane.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int id)
        {
            var klient = await _service.GetByIdAsync(id);
            if (klient == null)
            {
                return NotFound();
            }

            var model = klient.Adapt<KlienciViewModel>();
            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var klient = await _service.GetByIdAsync(id);
            if (klient == null)
            {
                return NotFound();
            }

            var model = klient.Adapt<KlienciViewModel>();
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var klient = await _service.GetByIdAsync(id);
            if (klient == null)
            {
                return NotFound();
            }
        
            await _service.DeleteAsync(id);
            TempData["Success"] = "Użytkownik został pomyślnie usunięty.";
            return RedirectToAction("Index");
        }
    }
}
