using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio2.Models;

namespace DevFolio2.Controllers
{
    public class AdminController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Admin
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(TblAdmin t)
        {
            var value = db.TblAdmin.Find(1);
            if ("hb016523" == value.Username && "19PEACte" == value.Password)
            {
                return RedirectToAction("Dashboard","AdminLayout");
            }
            else
            {
                return RedirectToAction("Admin");
            }
        }
    }
}