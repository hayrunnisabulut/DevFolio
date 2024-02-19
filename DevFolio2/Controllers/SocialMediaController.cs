using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio2.Models;

namespace DevFolio2.Controllers
{
    public class SocialMediaController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();

        public ActionResult SocialMediaList()
        {
            var values = db.TblSocialMedia.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(TblSocialMedia s)
        {
            s.Status = Convert.ToBoolean(s.Status);
            db.TblSocialMedia.Add(s);
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }


        public ActionResult DeleteSocialMedia(int id)
        {
            var value = db.TblSocialMedia.Find(id);
            db.TblSocialMedia.Remove(value);
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }


        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var value = db.TblSocialMedia.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedia s)
        {
            var value = db.TblSocialMedia.Find(s.SocialMediaID);
            value.PlatformName = s.PlatformName;
            value.IconUrl = s.IconUrl;
            value.RedirectUrl = s.RedirectUrl;
            value.Status = s.Status;
            db.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }
    }
}