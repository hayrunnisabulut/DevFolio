using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio2.Models;

namespace DevFolio2.Controllers
{
    public class ProfileController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Profile
        public ActionResult ProfileList()
        {
            var values = db.TblProfile.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProfile() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProfile(TblProfile p)
        {
            db.TblProfile.Add(p);
            db.SaveChanges();
            return RedirectToAction("ProfileList");
        }

        public ActionResult DeleteProfile(int id)
        {
            var value = db.TblProfile.Find(id);
            db.TblProfile.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProfileList");
        }

        [HttpGet]
        public ActionResult UpdateProfile(int id)
        {
            var value = db.TblProfile.Find(id);
            return View(value);
        }


    }
}
