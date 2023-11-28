using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeaShareHub.Controllers
{
    public class DirectMessageController : Controller
    {
        DirectMessageManager _directMessageManager = new DirectMessageManager(new EfDirectMessageDal());

        private readonly DirectMessageValidator validator = new DirectMessageValidator();


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

        [HttpGet]
        public ActionResult Compose()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Compose(DirectMessage dm)
        {
            ValidationResult result = validator.Validate(dm);
            if (result.IsValid)
            {
                dm.Date = DateTime.Now;
                _directMessageManager.Add(dm);
                return RedirectToAction("GetSentMessages");
            } 
            else
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
    }
}