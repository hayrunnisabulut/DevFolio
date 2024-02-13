using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio2.Models;

namespace DevFolio2.Controllers
{
    public class SkillController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();

        public ActionResult SkillList()
        {
            var values = db.TblSkill.ToList();
            return View(values);
        }
        [HttpGet] //attribute
        public ActionResult CreateSkill() 
        {
            return View();
        }

        [HttpPost] //attribute
        public ActionResult CreateSkill(TblSkill p)
        {
            db.TblSkill.Add(p);
            db.SaveChanges();
            return RedirectToAction("SkillList");
        }


        public ActionResult DeleteSkill(int id)
        {
            var value = db.TblSkill.Find(id);
            db.TblSkill.Remove(value);
            db.SaveChanges();
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var value = db.TblSkill.Find(id);
            return View(value);

        }

        [HttpPost]
        public ActionResult UpdateSkill(TblSkill s)
        {
            var value = db.TblSkill.Find(s.SkillID);
            value.SkillTitle = s.SkillTitle;
            value.SkillValue = s.SkillValue;
            db.SaveChanges();
            return RedirectToAction("SkillList");
        }
    }
}