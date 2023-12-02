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
    public class WriterPanelEntryController : Controller
    {
        private readonly EntryManager _entryManager = new EntryManager(new EfEntryDal());

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetEntries()
        {
            Context c = new Context();
            string username = (string)Session["Username"];
            int id = c.Writers.Where(x => x.Username==username).Select(y => y.Id).FirstOrDefault();
            List<Entry> entries = _entryManager.GetAllByWriter(id);
            return View(entries);
        }
    }
}