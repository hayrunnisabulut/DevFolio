using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio2.Models;

namespace DevFolio2.Controllers
{
    public class ProjectController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();

        public void CategoryList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in db.TblCategory.ToList())
            {
                items.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryID.ToString() });
            }
            ViewBag.Category_List = items;
        }

        public ActionResult ProjectList()
        {
            var values = db.TblProject.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            CategoryList();
            return View();
        }

        [HttpPost]
        public ActionResult CreateProject(TblProject p)
        {
            string a = Request.Form["plan"].ToString();
            p.ProjectCategory = Convert.ToInt32(a);
            p.CreateDate = Convert.ToDateTime(p.CreateDate);
            db.TblProject.Add(p);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProject.Find(id);
            db.TblProject.Remove(value);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            CategoryList();
            var value = db.TblProject.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProject s)
        {
            var value = db.TblProject.Find(s.ProjectID);
            value.ProjectTitle = s.ProjectTitle;
            value.CoverImageUrl = s.CoverImageUrl;
            string a = Request.Form["plan"].ToString();
            value.ProjectCategory = Convert.ToInt32(a);
            value.CreateDate = Convert.ToDateTime(s.CreateDate);
            db.SaveChanges();
            return RedirectToAction("ProjectList");
        }
    }
}