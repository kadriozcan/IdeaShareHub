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
    public class TopicController : Controller
    {
        private readonly TopicManager topicManager = new TopicManager(new EfTopicDal());

        private readonly CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        private readonly WriterManager writerManager = new WriterManager(new EfWriterDal());


        public ActionResult Index()
        {
            List<Topic> topics = topicManager.GetAll();
            return View(topics);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<SelectListItem> categoryValues = (from c in categoryManager.GetAll()
                                                   select new SelectListItem
                                                   {
                                                       Text = c.Name,
                                                       Value = c.Id.ToString()
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;


            List<SelectListItem> writerValues = (from w in writerManager.GetAll()
                                                 select new SelectListItem
                                                 {
                                                     Text = w.Username,
                                                     Value = w.Id.ToString()
                                                 }).ToList();
            ViewBag.WriterValues = writerValues;

            return View();
        }

        [HttpPost]
        public ActionResult Add(Topic topic)
        {
            topic.CreatedAt = DateTime.Parse(DateTime.Now.ToShortDateString());
            topicManager.Add(topic);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
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
        public ActionResult Update(Topic topic)
        {
            topic.CreatedAt = DateTime.Now;
            topicManager.Update(topic);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Topic topic = topicManager.GetById(id);
            topicManager.Delete(topic);
            return RedirectToAction("Index");
        }

    }
}