using DomaciZadatak.Models;
using DomaciZadatak.Models.LinqSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DomaciZadatak.Controllers
{
    [Authorize(Roles = "Trener")]
    public class TrenerController : Controller
    {
        KorisniciDataContext kDC = new KorisniciDataContext();
        // GET: Trener
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RezervacijaTermina()
        {
            List<Aktivnost> aktivnosti = new List<Aktivnost>();
            foreach (Aktivnost a in kDC.Aktivnosts)
            {
                aktivnosti.Add(a);
            }
            ViewBag.Aktivnosti = aktivnosti;
            List<Sala> sale = new List<Sala>();
            foreach (Sala s in kDC.Salas)
            {
                sale.Add(s);
            }
            ViewBag.Sale = sale;
            return View();
        }
        [HttpPost]
        public ActionResult RezervacijaTerminaPost(Rezervisan_TerminBO rezervisan_TerminBO)
        {
            Drzi drzi = new Drzi();
            Rezervisan_Termin rezervisan_Termin = new Rezervisan_Termin();
            rezervisan_Termin.DatumVreme = rezervisan_TerminBO.DatumVreme;
            rezervisan_Termin.AktivnostID = Convert.ToInt32(Request.Form["Aktivnosti"].ToString());
            rezervisan_Termin.JMBG = kDC.Korisniks.FirstOrDefault(t => t.Email == FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name).JMBG;
            rezervisan_Termin.SalaID = Convert.ToInt32(Request.Form["Sale"].ToString());
          
            drzi.JMBG = rezervisan_Termin.JMBG;
            drzi.AktivnostID = rezervisan_Termin.AktivnostID;
            kDC.Rezervisan_Termins.InsertOnSubmit(rezervisan_Termin);
            kDC.Drzis.InsertOnSubmit(drzi);
            kDC.SubmitChanges();
            return RedirectToAction("RezervacijaTermina");
        }

        public ActionResult OtkazivanjeTermina()
        {
            List<Rezervisan_Termin> rezervisan_Termini = new List<Rezervisan_Termin>();
            foreach (Rezervisan_Termin rt in kDC.Rezervisan_Termins)
            {
                rezervisan_Termini.Add(rt);
            }
            ViewBag.Termini = rezervisan_Termini;
            return View();
        }
        public ActionResult OtkazivanjeTerminaId(int id)
        {
            Rezervisan_Termin rezervisan_Termin = new Rezervisan_Termin();
            rezervisan_Termin = kDC.Rezervisan_Termins.FirstOrDefault(t => t.TerminID == id);
            Rezervisan_TerminBO rezervisan_TerminBO = new Rezervisan_TerminBO();
            rezervisan_TerminBO.TerminID = rezervisan_Termin.TerminID;
            rezervisan_TerminBO.SalaID = rezervisan_Termin.SalaID;
            rezervisan_TerminBO.JMBG = rezervisan_Termin.JMBG;
            rezervisan_TerminBO.AktivnostID = rezervisan_Termin.AktivnostID;
            rezervisan_TerminBO.DatumVreme = rezervisan_Termin.DatumVreme;
            return PartialView("_OtkazivanjeTermina", rezervisan_TerminBO);
        }
        //public ActionResult AzuriranjeTermina()
        //{
        //    List<Rezervisan_Termin> rezervisan_Termini = new List<Rezervisan_Termin>();
        //    foreach (Rezervisan_Termin rt in kDC.Rezervisan_Termins)
        //    {
        //        rezervisan_Termini.Add(rt);
        //    }
        //    ViewBag.Termini = rezervisan_Termini;
        //    return View();
        //}
        //public ActionResult AzuriranjeTerminaId(int id)
        //{
        //    Rezervisan_Termin rezervisan_Termin = new Rezervisan_Termin();
        //    rezervisan_Termin = kDC.Rezervisan_Termins.FirstOrDefault(t => t.TerminID == id);
        //    Rezervisan_TerminBO rezervisan_TerminBO = new Rezervisan_TerminBO();
        //    rezervisan_TerminBO.TerminID = rezervisan_Termin.TerminID;
        //    rezervisan_TerminBO.SalaID = rezervisan_Termin.SalaID;
        //    rezervisan_TerminBO.JMBG = rezervisan_Termin.JMBG;
        //    rezervisan_TerminBO.AktivnostID = rezervisan_Termin.AktivnostID;
        //    rezervisan_TerminBO.DatumVreme = rezervisan_Termin.DatumVreme;
        //    return PartialView("_AzuriranjeTermina", rezervisan_TerminBO);
        //}
        //[HttpPost]
        //public ActionResult Index(Rezervisan_TerminBO model)
        //{
        //    Rezervisan_Termin rezervisan_Termin = new Rezervisan_Termin();
        //    rezervisan_Termin = kDC.Rezervisan_Termins.FirstOrDefault(t => t.TerminID == model.TerminID);
        //    rezervisan_Termin.TerminID = model.TerminID;
        //    rezervisan_Termin.SalaID = model.SalaID;
        //    rezervisan_Termin.JMBG = model.JMBG;
        //    rezervisan_Termin.AktivnostID = model.AktivnostID;
        //    rezervisan_Termin.DatumVreme = model.DatumVreme;
        //    kDC.SubmitChanges();
        //    return RedirectToAction("AzuriranjeTermina");
        //}
        public ActionResult BrisanjeTermina(int id)
        {
            Rezervisan_Termin rezervisan_Termin = new Rezervisan_Termin();
            rezervisan_Termin = kDC.Rezervisan_Termins.FirstOrDefault(t => t.TerminID == id);
            kDC.Rezervisan_Termins.DeleteOnSubmit(rezervisan_Termin);
            kDC.SubmitChanges();
            return RedirectToAction("OtkazivanjeTermina");
        }
        public ActionResult DodavanjeOpreme()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DodavanjeOpreme( ZahtevOpremaBO zahtevOpremaBO)
        {
            ZahtevOprema zahtevOprema = new ZahtevOprema();
            zahtevOprema.JMBG = kDC.Korisniks.FirstOrDefault(t => t.Email == FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name).JMBG;
            zahtevOprema.Kolicina = zahtevOpremaBO.Kolicina;
            zahtevOprema.OpremaID = zahtevOpremaBO.OpremaID;
            kDC.ZahtevOpremas.InsertOnSubmit(zahtevOprema);
            kDC.SubmitChanges();
            return RedirectToAction("DodavanjeOpreme");
        }
    }
}