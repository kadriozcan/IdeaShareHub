using Business.Concrete;
using Business.ValidationRules.FluentValidation;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeaShareHub.Controllers
{
    public class WriterController : Controller
    {
        private readonly WriterManager writerManager = new WriterManager(new EfWriterDal());

        private readonly WriterValidator validator = new WriterValidator();


        public ActionResult Index()
        {
            List<Writer> writers = writerManager.GetAll();
            return View(writers);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Writer writer)
        {
            ValidationResult validationResult = validator.Validate(writer);
            if (validationResult.IsValid)
            {
                writerManager.Add(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Writer writer = writerManager.GetById(id);
            return View(writer);
        }

        [HttpPost]
        public ActionResult Update(Writer writer)
        {
            ValidationResult validationResult = validator.Validate(writer);
            if(validationResult.IsValid)
            {
                writerManager.Update(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }
        }
    }
}