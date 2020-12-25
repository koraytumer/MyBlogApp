using Microsoft.AspNetCore.Mvc;
using MyBlogApp.Business.Abstract;
using MyBlogApp.Data.Abstract;
using MyBlogApp.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogApp.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogService _blogService;
        public HomeController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public IActionResult Index()
        {
            var model = new HomeBlogModel();

            model.SliderBlogs = _blogService.GetAll().Where(i => i.isApproved == true && i.isSlider == true).ToList();
            model.HomeBlogs = _blogService.GetAll().Where(i => i.isApproved == true && i.isHome == true).ToList();
            return View(model);
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult List()
        {
            return View();
        }
    }
}
