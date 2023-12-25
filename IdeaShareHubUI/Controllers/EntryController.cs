using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeaShareHub.Controllers
{
    public class EntryController : Controller
    {
        private readonly EntryManager entryManager = new EntryManager(new EfEntryDal());
        private readonly TopicManager topicManager = new TopicManager(new EfTopicDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAll(string p="")
        {
            List<Entry> entries = entryManager.GetAll(p);
            return View(entries);
        }

        public ActionResult GetByTopic(int id)
        {
            List<Entry> entries = entryManager.GetListByTopic(id);
            Topic topic = topicManager.GetById(id);
            ViewBag.Topic = topic.Name;
            return View(entries);
        }
    }
}