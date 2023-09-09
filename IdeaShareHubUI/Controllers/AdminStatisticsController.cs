using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeaShareHub.Controllers
{
    public class AdminStatisticsController : Controller
    {

        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            int numberOfCategories = categoryManager.GetNumberOfCategories();

            ViewBag.NumberOfCategories = numberOfCategories;
            return View();
        }

    }
}