using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DomaciZadatak.Models;
using DomaciZadatak.Models.Interfaces;
using DomaciZadatak.Models.LinqSql;

namespace DomaciZadatak.Controllers
{
    public class UplataController : Controller
    {
        KorisniciDataContext kDC = new KorisniciDataContext();
        private IKorisnikRepository korisnikRepository = new KorisnikSqlRepository();
        // GET: Uplata
        public ActionResult Index()
        {
            List<Aktivnost> aktivnosti = new List<Aktivnost>();
            foreach(Aktivnost a in kDC.Aktivnosts)
            {
                aktivnosti.Add(a);
            }
            ViewBag.Usluge = aktivnosti;
            return View();
        }
        [HttpPost]
        public ActionResult IndexPost()
        {
            UplataBO uplataBO = new UplataBO();
            uplataBO.AktivnostID = Convert.ToInt32(Request.Form["Aktivnosti"].ToString());
            uplataBO.JMBG= kDC.Korisniks.FirstOrDefault(t=>t.Email == FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name).JMBG;
            uplataBO.Cene = Convert.ToInt32(Request.Form["Cena"].ToString());
            korisnikRepository.DodajUplatu(uplataBO);
            return RedirectToAction("Index");
        }
        public ActionResult GetCena(int id)
        {
            string cena;
            Aktivnost akt = new Aktivnost();
            akt = kDC.Aktivnosts.First(x => x.AktivnostID == id);
            cena = Convert.ToString(akt.Cena);
          
            return Json(cena, JsonRequestBehavior.AllowGet);

        }
    }
}