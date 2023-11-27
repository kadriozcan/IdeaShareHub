using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeaShareHub.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        DirectMessageManager directMessageManager = new DirectMessageManager(new EfDirectMessageDal());

        ContactValidator validator = new ContactValidator();

        public ActionResult Index()
        {
            List<Contact> contacts = contactManager.GetAll();
            return View(contacts);
        }

        public ActionResult GetDetails(int id)
        {
            Contact contact = contactManager.GetById(id);
            return View(contact);
        }

        public PartialViewResult ContactSideBar()
        {
            int numOfContacts = contactManager.GetNumOfContacts();
            ViewBag.NumOfContacts = numOfContacts;
            ViewBag.NumOfSentMessages = directMessageManager.GetNumOfSentMessages();
            ViewBag.NumOfReceivedMessages = directMessageManager.GetNumOfReceivedMessages();
            return PartialView();
        }


    }
}