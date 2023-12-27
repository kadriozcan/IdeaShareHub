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
    public class AuthorizationController : Controller
    {
        private readonly AdminManager adminManager = new AdminManager(new EfAdminDal());

        public ActionResult Index()
        {
            List<Admin> admins = adminManager.GetAll();
            return View(admins);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adminManager.Add(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            Admin admin = adminManager.GetById(id);
            return View(admin);
        }

        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            adminManager.Update(admin);
            return RedirectToAction("Index");
        }
    }
}