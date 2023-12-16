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
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly AdminManager _adminManager = new AdminManager(new EfAdminDal());
        private readonly WriterManager _writerManager = new WriterManager(new EfWriterDal());


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

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            Writer writerUserInfo = _writerManager.GetWriterInfo(writer);
            if (writerUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writerUserInfo.Username, false);
                Session["Username"] = writerUserInfo.Username;
                return RedirectToAction("GetEntries", "WriterPanelEntry");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Topics", "Default");
        }
    }
}