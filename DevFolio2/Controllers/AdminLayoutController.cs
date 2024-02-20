using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio2.Models;

namespace DevFolio2.Controllers
{
    public class AdminLayoutController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Dashboard()
        {
            ViewBag.gelenKutusu = db.TblContact.Where(x => x.IsRead == false).Count().ToString();
            DateTime dt = Convert.ToDateTime(db.TblProject.Max(x => x.CreateDate));
            ViewBag.sonprojetarihi = dt.ToString("dd/MM/yyyy");
            ViewBag.referans = db.TblTestimonial.Count().ToString();
            return PartialView();
        }
        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult SidebarPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }

    }
}