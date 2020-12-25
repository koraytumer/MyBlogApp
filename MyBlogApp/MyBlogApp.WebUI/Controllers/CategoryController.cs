using Microsoft.AspNetCore.Mvc;
using MyBlogApp.Business.Abstract;
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
        private ICategoryService _categoryService ;
        public CategoryController(ICategoryService  categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List()
        {
            return View(_categoryService.GetAll());
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
                return View(_categoryService.GetById((int)id));
            }
        }
        [HttpPost]
        public IActionResult AddorUpdate(Category entity)
        {
            if (ModelState.IsValid)
            {
                _categoryService.Update(entity);
                TempData["message"] = $"{entity.Name} Added.";
                return RedirectToAction("List");
            }
            return View(entity);
        }

    }
}
