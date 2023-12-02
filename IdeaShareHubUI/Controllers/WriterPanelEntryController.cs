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
    public class WriterPanelEntryController : Controller
    {
        private readonly EntryManager entryManager = new EntryManager(new EfEntryDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEntries()
        {
            List<Entry> entries = entryManager.GetAllByWriter();
            return View(entries);
        }
    }
}