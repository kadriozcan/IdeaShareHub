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
    public class DirectMessageController : Controller
    {
        DirectMessageManager directMessageManager = new DirectMessageManager(new EfDirectMessageDal());

        public ActionResult GetReceivedMessages()
        {
            List<DirectMessage> receivedMessages = directMessageManager.GetReceivedMessages();
            return View(receivedMessages);
        }
        public ActionResult GetDetails(int id)
        {
            DirectMessage directMessage = directMessageManager.GetById(id);
            return View(directMessage);
        }

        public ActionResult GetSentMessages()
        {
            List<DirectMessage> sentMessages = directMessageManager.GetSentMessages();
            return View(sentMessages);
        }

        [HttpGet]
        public ActionResult Compose()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Compose(DirectMessage dm)
        {
            return View();
        }
    }
}