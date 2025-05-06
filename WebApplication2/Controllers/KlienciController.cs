using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModels;
using WebApplication2.Models;
using FluentValidation;
using FluentValidation.AspNetCore;
using WebApplication2.Data.Repository;
using Mapster;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication2.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class KlienciController : Controller
    {
        private readonly IKlienciService _service;
        
        public KlienciController(IKlienciService service)
        {
            _service = service;
        }
        

        [HttpGet]
        [AllowAnonymous]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Index()
        {
            var klienci = await _service.GetAllAsync();
            var viewModel = klienci.Adapt<List<KlienciViewModel>>();

            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Create(KlienciViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var klient = model.Adapt<Klienci>();

            await _service.CreateAsync(klient);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
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
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> Edit(KlienciViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var klient = model.Adapt<Klienci>();
            await _service.UpdateAsync(klient);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Employee")]
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
        [Authorize(Roles = "Admin,Employee")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}

public class KlienciViewModelValidator : AbstractValidator<KlienciViewModel>
{
    public KlienciViewModelValidator()
    {
        RuleFor(x => x.Imie).NotEmpty().WithMessage("Imię jest wymagane.");
        RuleFor(x => x.Nazwisko).NotEmpty().WithMessage("Nazwisko jest wymagane.");
        RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("Nieprawidłowy adres email.");
        RuleFor(x => x.Telefon).NotEmpty().WithMessage("Telefon jest wymagany.")
            .Matches(@"^\d{9}$").WithMessage("Numer telefonu musi składać się z 9 cyfr.");
    }
}