using Microsoft.AspNetCore.Mvc;
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
        private IBlogRepository blogRepository;
        public HomeController(IBlogRepository repository)
        {
            blogRepository = repository;
        }
        public IActionResult Index()
        {
            var model = new HomeBlogModel();
            model.HomeBlogs = blogRepository.GetAll().Where(i => i.isApproved == true && i.isHome == true).ToList();
            model.SliderBlogs = blogRepository.GetAll().Where(i => i.isApproved == true && i.isSlider == true).ToList();
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
