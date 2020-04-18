using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using To_Do_List.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace To_Do_List.Controllers
{
    public class KitaplıkController : Controller
    {
        // GET: Kitaplık
        MvcKütüphaneEntities db = new MvcKütüphaneEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var kitaplar = db.TBLKITAPLIK.ToList();
            var kitaplar = db.TBLKITAPLIK.ToList().ToPagedList(sayfa, 6);
            return View(kitaplar);
        }
        public ActionResult GüncelleGetir(int id)
        {
            var kitap = db.TBLKITAPLIK.Find(id);
            return View("GüncelleGetir", kitap);

        }
        public ActionResult Güncelle(TBLKITAPLIK p1)
        {
            var kitap = db.TBLKITAPLIK.Find(p1.KitapID);
            kitap.KitapAdi = p1.KitapAdi;
            kitap.KitapYazari = p1.KitapYazari;
            db.SaveChanges();
            return RedirectToAction("Index");

                
        }
        [HttpGet]
        public ActionResult yeniKitap()

        {
            List<SelectListItem> degerler = (from i in db.TBLYAZAR.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.YazarAdi,
                                                 Value = i.YazarID.ToString()
                                             }).ToList();


            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult yeniKitap(TBLKITAPLIK p1)
        {
            var ktp = db.TBLYAZAR.Where(m => m.YazarID == p1.TBLYAZAR.YazarID).FirstOrDefault();
            p1.TBLYAZAR = ktp;
            db.TBLKITAPLIK.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}