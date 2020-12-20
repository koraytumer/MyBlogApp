using Microsoft.AspNetCore.Mvc;
using MyBlogApp.Data.Abstract;
using MyBlogApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository repository;
        public CategoryController(ICategoryRepository _repo)
        {
            repository = _repo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(repository.GetAll());
        }
        [HttpGet]
        public IActionResult AddorUpdate(int? id)
        {
            if (id == null)
            {
                return View(new Category());
            }
            else
            {
                return View(repository.GetById((int)id));
            }
        }
        [HttpPost]
        public IActionResult AddorUpdate(Category entity)
        {
            if (ModelState.IsValid)
            {
                repository.SaveCategory(entity);
                TempData["message"] = $"{entity.Name} Added.";
                return RedirectToAction("List");
            }
            return View(entity);
        }

    }
}
