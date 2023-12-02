using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeaShareHub.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        // GET: WriterPanelMessage
        private readonly DirectMessageManager _directMessageManager = new DirectMessageManager(new EfDirectMessageDal());

        private readonly DirectMessageValidator _validator = new DirectMessageValidator();

        public ActionResult GetReceivedMessages()
        {

            List<DirectMessage> receivedMessages = _directMessageManager.GetReceivedMessages();
            return View(receivedMessages);
        }

        public ActionResult GetDetails(int id)
        {
            DirectMessage directMessage = _directMessageManager.GetById(id);
            return View(directMessage);
        }


        public ActionResult GetSentMessages()
        {

            List<DirectMessage> sentMessages = _directMessageManager.GetSentMessages();
            return View(sentMessages);
        }

        public PartialViewResult ContactSideBar()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult Compose()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Compose(DirectMessage dm)
        {
            ValidationResult result = _validator.Validate(dm);
            if (result.IsValid)
            {
                dm.SenderMail = "gizem@gmail.com";
                dm.Date = DateTime.Now;
                _directMessageManager.Add(dm);
                return RedirectToAction("GetSentMessages");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }



    }
}