using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;


namespace MvcKutuphane.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        DBKUTUPHANEEntities db = new DBKUTUPHANEEntities();//tablodaki propertylere ulaşmayı sağlıyor.
        public ActionResult Index()
        {
            var degerler = db.TBLHAREKET.Where(x => x.İSLEMDURUM == true).ToList();
            return View(degerler);
        }
    }
}