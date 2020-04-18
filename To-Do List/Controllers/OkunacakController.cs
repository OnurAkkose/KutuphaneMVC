using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_Do_List.Models.Entity;

namespace To_Do_List.Controllers
{
    public class OkunacakController : Controller
    {
        // GET: Okunacak
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
        public ActionResult Index()
        {
            var okunacaklar = db.TBLOKUNACAK.ToList();
            return View(okunacaklar);
        }
        [HttpGet]
        public ActionResult OkunacakKitap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult OkunacakKitap(TBLOKUNACAK p1)
        {
            db.TBLOKUNACAK.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}