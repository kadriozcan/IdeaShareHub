using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IdeaShareHub.Controllers
{
    public class LoginController : Controller
    {
        private readonly AdminManager _adminManager = new AdminManager(new EfAdminDal());


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            Admin adminUserInfo = _adminManager.GetAdminInfo(admin);
            if (adminUserInfo != null) 
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.Username, false);
                Session["Username"] = adminUserInfo.Username;
                return RedirectToAction("Index", "AdminCategory");   
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}