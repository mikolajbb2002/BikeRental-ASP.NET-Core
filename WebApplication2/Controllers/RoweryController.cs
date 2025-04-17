using Microsoft.AspNetCore.Mvc;
using WebApplication2.Data;
using WebApplication2.Data.Repository;
using WebApplication2.Models;

namespace WebApplication2.Controllers  
{
    public class RoweryController : Controller
    {
        private readonly IRoweryRepository _roweryRepository;

       
        public RoweryController(IRoweryRepository roweryRepository)
        {
            _roweryRepository = roweryRepository;
        }

        
        [HttpGet]
        public IActionResult Index()
        {
            var model = _roweryRepository.GetAll();
            return View(model);
        }

        
        [HttpGet]
        public IActionResult AddRowery()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult AddRowery(Rowery model)
        {
            if (ModelState.IsValid)
            {
                _roweryRepository.Insert(model);
                _roweryRepository.Save();
                return RedirectToAction("Index");  
            }
            return View(model);
        }

        
        [HttpGet]
        public IActionResult EditRowery(int id)
        {
            var model = _roweryRepository.GetById(id);
            if (model == null)
            {
                return NotFound();  
            }
            return View(model);
        }

        
        [HttpPost]
        public IActionResult EditRowery(Rowery model)
        {
            if (ModelState.IsValid)
            {
                _roweryRepository.Update(model);
                _roweryRepository.Save();
                return RedirectToAction("Index");  
            }
            return View(model);
        }

        
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

       
        [HttpPost, ActionName("DeleteRowery")]
        public IActionResult DeleteConfirmed(int id)
        {
            _roweryRepository.Delete(id);
            _roweryRepository.Save();
            return RedirectToAction("Index");  
        }
    }
}
