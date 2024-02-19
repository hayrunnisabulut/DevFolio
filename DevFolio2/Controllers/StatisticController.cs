using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio2.Models;

namespace DevFolio2.Controllers
{
    public class StatisticController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        public ActionResult Index()
        {
            ViewBag.categoryCount = db.TblCategory.Count();
            ViewBag.projectCount = db.TblProject.Count();
            ViewBag.skillCount = db.TblSkill.Count();
            ViewBag.skillAvgValue = db.TblSkill.Average(x => x.SkillValue);
            ViewBag.lastSkillTitle = db.GetLastSkillTitle().FirstOrDefault();
            ViewBag.coreCategoryProjectCount = db.TblProject.Where(x => x.ProjectCategory == 1).Count();
            ViewBag.eniyihizmet = db.GetBestSkill().FirstOrDefault();
            ViewBag.hakkimdakelimesayisi = db.TblAbout.Where(x => x.AboutID == 1).ToList()[0].Description.Split().Count();
            ViewBag.sosyalMedyaSayisi = db.TblSocialMedia.Where(x => x.Status == true).Count();
            ViewBag.okunmayanmesajlar = db.TblContact.Where(x => x.IsRead == false).Count();
            return View();
        }
    }
}