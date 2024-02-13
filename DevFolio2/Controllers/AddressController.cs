using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevFolio2.Models;

namespace DevFolio2.Controllers
{
    public class AddressController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: Address
        public ActionResult AddressInfo()
        {
            var values = db.TblAddress.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult UpdateAddress(int id)
        {
            var value = db.TblAddress.Find(id);
            return View(value);
        }
    }
}