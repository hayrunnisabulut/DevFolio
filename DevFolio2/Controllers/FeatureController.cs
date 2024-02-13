using DevFolio2.Models;
using System.Linq;
using System.Web.Mvc;

namespace DevFolio2.Controllers
{
    public class FeatureController : Controller
    {
        DbDevFolioEntities db = new DbDevFolioEntities();
        // GET: feature
        public ActionResult FeatureList()
        {
            var values = db.TblFeature.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateFeature(TblFeature f)
        {
            db.TblFeature.Add(f);
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }

        public ActionResult DeleteFeature(int id)
        {
            var value = db.TblFeature.Find(id);
            db.TblFeature.Remove(value);
            db.SaveChanges();
            return RedirectToAction("FeatureList");
        }
        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = db.TblFeature.Find(id);
            return View(value);
        }
    }
}