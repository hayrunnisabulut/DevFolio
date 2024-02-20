using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio2.Models;

namespace DevFolio2.Controllers
{
    public class DefaultController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialFeature()
        {
            var values = db.TblFeature.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialProfile()
        {
            var values = db.TblProfile.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkill()
        {
            var values = db.TblSkill.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAbout()
        {
            var values = db.TblAbout.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialService()
        {
            var values = db.TblService.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialStatistic()
        {
            ViewBag.skill = db.TblSkill.ToList().Where(i => Convert.ToInt32(i.SkillValue) >= 70).Count();
            ViewBag.projects = db.TblProject.Count();
            ViewBag.testimonial = db.TblTestimonial.Count();
            ViewBag.services = db.TblService.Count();
            return PartialView();
        }

        public PartialViewResult PartialPortfolio()
        {
            var project = db.TblProject.ToList();
            return PartialView(project);
        }

        public PartialViewResult PartialTestimonial()
        {
            var testimonial = db.TblTestimonial.ToList();
            return PartialView(testimonial);
        }

        [HttpGet]
        public PartialViewResult PartialContact()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult PartialContact(TblContact v)
        {
            db.TblContact.Add(v);
            v.IsRead = false;
            v.SendMessageDate = DateTime.Now;
            db.SaveChanges();
            ViewBag.m = "okey";
            ViewBag.c = "show";
            return Json("Mesajınız Gönderildi");
        }

        public PartialViewResult PartialAddress()
        {
            var address = db.TblAddress.ToList();
            return PartialView(address);
        }
        public PartialViewResult PartialSocial()
        {
            var social = db.TblSocialMedia.Where(x=> x.Status==true).ToList();
            return PartialView(social);
        }

    }
}