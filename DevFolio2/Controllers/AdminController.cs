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
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult Login()
        {
            var value = db.TblAdmin.Find(1);
            if ("19PEACte" == value.Password)
            {
                return RedirectToAction("Admin");
            }
            else
            {
                return RedirectToAction("Admin");
            }
        }
    }
}