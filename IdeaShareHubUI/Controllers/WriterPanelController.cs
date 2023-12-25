using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using PagedList;
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
        private readonly WriterManager writerManager = new WriterManager(new EfWriterDal());

        [HttpGet]
        public ActionResult WriterProfile()
        {
            Context c = new Context();
            string username = (string)Session["Username"];
            ViewBag.D = username;
            int writerId = c.Writers.Where(x => x.Username == username).Select(y => y.Id).FirstOrDefault();
            ViewBag.A = writerId;
            Writer writerValue = writerManager.GetById(writerId);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator validator = new WriterValidator();
            ValidationResult validationResult = validator.Validate(writer);
            if (validationResult.IsValid)
            {
                writerManager.Update(writer);
                return RedirectToAction("WriterProfile");
            }
            else
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }
        }

        public ActionResult WriterTopics()
        {
            Context c = new Context();
            string username = (string)Session["Username"];
            int writerId = c.Writers.Where(x => x.Username == username).Select(y => y.Id).FirstOrDefault();
            List<Topic> topics = topicManager.GetAllByWriter(writerId);
            return View(topics);
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
            Context c = new Context();
            string username = (string)Session["Username"];
            int writerId = c.Writers.Where(x => x.Username == username).Select(y => y.Id).FirstOrDefault();
            topic.WriterId = writerId;
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
            Context c = new Context();
            topic.CreatedAt = DateTime.Now;
            string username = (string)Session["Username"];
            int writerId = c.Writers.Where(x => x.Username == username).Select(y => y.Id).FirstOrDefault();
            topic.WriterId = writerId;
            topic.Status = true;
            topicManager.Update(topic);
            return RedirectToAction("WriterTopics");
        }


        public ActionResult DeleteTopic(int id)
        {
            Topic topic = topicManager.GetById(id);
            topicManager.Delete(topic);
            return RedirectToAction("WriterTopics");
        }

        public ActionResult AllTopics(int p = 1)
        {
            IEnumerable<Topic> allTopics = topicManager.GetAll().ToPagedList(p, 7);
            return View(allTopics);
        }

       
    }
}