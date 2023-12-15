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
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly TopicManager _topicManager = new TopicManager(new EfTopicDal());
        private readonly EntryManager _entryManager = new EntryManager(new EfEntryDal());

        public ActionResult Topics()
        {
            List<Topic> topics = _topicManager.GetAll();
            return View(topics);
        }

        public PartialViewResult Index(int id = 0)
        {
            List<Entry> entries = _entryManager.GetListByTopic(id);
            Topic topic = _topicManager.GetById(id);
            if (topic!=null)
            {
            ViewBag.Topic = topic.Name;

            }
            return PartialView(entries);
        }
    }
}