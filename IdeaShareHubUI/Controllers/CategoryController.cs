using Business.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeaShareHub.Controllers
{
    public class CategoryController : Controller
    {

        CategoryManager categoryManager = new CategoryManager();

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll()
        {
            List<Category> categories = categoryManager.GetAll();
            return View(categories);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category category)
        {
            categoryManager.Add(category);
            return RedirectToAction("GetAll");
        }
    }
}