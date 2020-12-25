using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyBlogApp.Business.Abstract;
using MyBlogApp.Data.Abstract;
using MyBlogApp.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogService _blogService;
        private ICategoryService _categoryService;
        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }
        public IActionResult Index(int? id, string q)
        {
            var query = _blogService.GetAll()
                        .Where(i => i.isApproved);

            if (id != null)
            {
                query = query.Where(i => i.CategoryId == id);
            }
            if (!string.IsNullOrEmpty(q))
            {
                query = query.Where(x => EF.Functions.Like(x.Title, "%" + q + "%") || EF.Functions.Like(x.Description, "%" + q + "%") || EF.Functions.Like(x.Body, "%" + q + "%"));
            }

            return View(query.OrderByDescending(i => i.Date));
        }
        public IActionResult List()
        {
            return View(_blogService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "CategoryId", "Name");

            return View(new Blog());
        }
        [HttpPost]
        public IActionResult Create(Blog entity)
        {
            if (ModelState.IsValid)
            {
                _blogService.Update(entity);
                TempData["message"] = $"{entity.Title} added.";
                return RedirectToAction("List");
            }
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "CategoryId", "Name");
            return View(entity);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "CategoryId", "Name");

            return View(_blogService.GetById(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Blog entity, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                        entity.Image = file.FileName;
                    }
                }
                _blogService.Update(entity);
                TempData["message"] = $"{entity.Title} added.";
                return RedirectToAction("List");
            }
            ViewBag.Categories = new SelectList(_categoryService.GetAll(), "CategoryId", "Name");
            return View(entity);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View(_blogService.GetById(id));
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int BlogId)
        {
            var entity = _blogService.GetById(BlogId);
            _blogService.Delete(entity);
            TempData["message"] = $"{BlogId} added.";
            return RedirectToAction("List");
        }
        public IActionResult Details(int id)
        {
            return View(_blogService.GetById(id));
        }
    }
}
