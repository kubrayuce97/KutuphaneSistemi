using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;


namespace MvcKutuphane.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();//tablodaki propertylere ulaşmayı sağlıyor.
        //sayfalı bir tasarım için
        public ActionResult Index()
        {
            //   var degerler = db.TBLUYELER.ToList();
            var degerler = db.TBLUYELER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UyeEkle(TBLUYELER p)
        {//bos kayıt yapmaz.
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBLUYELER.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyeSil(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            db.TBLUYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var uyeler = db.TBLUYELER.Find(id);
            return View("UyeGetir", uyeler);
        }
        public ActionResult UyeGuncelle(TBLUYELER p)
        {
            var uyeler = db.TBLUYELER.Find(p.ID);
            uyeler.AD = p.AD;
            uyeler.SOYAD = p.SOYAD;
            uyeler.MAIL = p.MAIL;
            uyeler.KULLANICIADI = p.KULLANICIADI;
            uyeler.SIFRE = p.SIFRE;
            uyeler.OKUL = p.OKUL;
            uyeler.TELEFON = p.TELEFON;
            uyeler.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeKitapGecmis(int id)
        {
            var ktpgcms = db.TBLHAREKET.Where(x => x.UYE == id).ToList();
            var uyekit = db.TBLUYELER.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.u1 = uyekit;
            return View(ktpgcms);
        }
    }
}