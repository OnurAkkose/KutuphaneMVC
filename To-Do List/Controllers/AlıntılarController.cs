using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_Do_List.Models.Entity;

namespace To_Do_List.Controllers
{
    public class AlıntılarController : Controller
    {
        // GET: Alıntılar
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
        public ActionResult Index()
        {
            var alintilar = db.TBLALINTI.ToList();
            return View(alintilar);
        }
        [HttpGet]
        public ActionResult YeniAlinti()
        {
            List<SelectListItem> degerler = (from i in db.TBLKITAPLIK.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KitapAdi,
                                                 Value = i.KitapID.ToString()
                                             }).ToList();


            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniAlinti(TBLALINTI p1)
        {
            var alinti = db.TBLKITAPLIK.Where(m => m.KitapID == p1.TBLKITAPLIK.KitapID).FirstOrDefault();
            p1.TBLKITAPLIK = alinti;
            db.TBLALINTI.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}