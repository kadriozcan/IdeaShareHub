using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using IdeaShareHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeaShareHub.Controllers
{
    public class ChartController : Controller
    {
        private readonly CategoryManager _categoryManager = new CategoryManager(new EfCategoryDal());
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryClass> BlogList()
        {
            List<CategoryClass> categoryClasses = new List<CategoryClass>();
            Context context = new Context();
            categoryClasses = context.Categories.Select(x => new CategoryClass
            {
                Name = x.Name,
                Count = context.Topics.Count(t => t.CategoryId == x.Id)

            }).ToList();
            return categoryClasses;
        }
    }
}