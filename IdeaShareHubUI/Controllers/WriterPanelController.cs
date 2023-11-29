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
    public class WriterPanelController : Controller
    {
        private readonly TopicManager topicManager = new TopicManager(new EfTopicDal());
        private readonly CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult WriterProfile()
        {
            return View();
        }

        public ActionResult WriterTopics()
        {
            
            List<Topic> writerTopics = topicManager.GetAllByWriter();
            return View(writerTopics);
        }

        [HttpGet]
        public ActionResult AddTopic()
        {
            List<SelectListItem> categoryValues = (from c in categoryManager.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.Name,
                                                       Value = c.Id.ToString()
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        public ActionResult AddTopic(Topic topic)
        {
            
            topic.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            topic.WriterId = 4;
            topic.Status = true;
            topicManager.Add(topic);
            return RedirectToAction("WriterTopics");
        }

        [HttpGet]
        public ActionResult UpdateTopic(int id)
        {
            List<SelectListItem> categoryValues = (from c in categoryManager.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.Name,
                                                       Value = c.Id.ToString()
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            Topic topic = topicManager.GetById(id);
            return View(topic);
        }
        [HttpPost]
        public ActionResult UpdateTopic(Topic topic)
        {
            topic.CreatedAt = DateTime.Now;
            topicManager.Update(topic);
            return RedirectToAction("WriterTopics");
        }


        public ActionResult DeleteTopic(int id)
        {
            Topic topic = topicManager.GetById(id);
            topicManager.Delete(topic);
            return RedirectToAction("WriterTopics");
        }
    }
}