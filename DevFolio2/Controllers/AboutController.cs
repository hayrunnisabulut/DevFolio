using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio2.Models;

namespace DevFolio2.Controllers
{
    public class AboutController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: About
        public ActionResult About()
        {
            var values = db.TblAbout.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = db.TblAbout.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout s)
        {
            var value = db.TblAbout.Find(ViewBag.aboutId);
            value.Description = s.Description;
            db.SaveChanges();
            return RedirectToAction("About");
        }
    }
}