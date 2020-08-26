using DomaciZadatak.Models;
using DomaciZadatak.Models.EFRepository;
using DomaciZadatak.Models.Interfaces;
using DomaciZadatak.Models.LinqSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DomaciZadatak.Controllers
{
    [Authorize (Roles ="Admin")]
    public class AdminController : Controller
    {
        KorisniciDataContext kDC = new KorisniciDataContext();
        // GET: Admin
        public ActionResult Index()
        {
            List<AktivnostBO> aktivnosts = new List<AktivnostBO>();
            foreach(Aktivnost a in kDC.Aktivnosts)
            {
                AktivnostBO aktivnostBO = new AktivnostBO();
                aktivnostBO.AktivnostID = a.AktivnostID;
                aktivnostBO.Naziv = a.Naziv;
                aktivnostBO.Cena = a.Cena;
                aktivnosts.Add(aktivnostBO);
            }
            return View(aktivnosts);
        }
        public ActionResult DodavanjeAktivnosti()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DodavanjeAktivnosti(AktivnostBO aktivnostBO)
        {
            Aktivnost aktivnost = new Aktivnost();
            aktivnost.Cena = aktivnostBO.Cena;
            aktivnost.Naziv = aktivnostBO.Naziv;
            kDC.Aktivnosts.InsertOnSubmit(aktivnost);
            kDC.SubmitChanges();
            return RedirectToAction("DodavanjeAktivnosti");
        }

        public ActionResult Delete(int id)
        {
            Aktivnost aktivnost = new Aktivnost();
            aktivnost = kDC.Aktivnosts.FirstOrDefault(t => t.AktivnostID == id);
            kDC.Aktivnosts.DeleteOnSubmit(aktivnost);
            kDC.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DodajKorisnika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DodajKorisnika(KorisnikBO userBO)
        {
            Korisnik user = new Korisnik()
            {
                Ime = userBO.Ime,
                Lozinka = userBO.Lozinka,
                Prezime = userBO.Prezime,
                DatumRodj = userBO.DatumRodj,
                Email = userBO.Email,
                JMBG = userBO.JMBG,
            };
            kDC.Korisniks.InsertOnSubmit(user);
            UserRole userRole = new UserRole();
            userRole.RoleID = kDC.Roles.FirstOrDefault(t=>t.Naziv== userBO.Rola).RoleID;
            userRole.UserID = userBO.JMBG;
            kDC.UserRoles.InsertOnSubmit(userRole);
            kDC.SubmitChanges();
            return RedirectToAction("DodajKorisnika");
        }

        public ActionResult ListaKorisnika()
        {
            List<KorisnikBO> korisniks = new List<KorisnikBO>();
            foreach (Korisnik a in kDC.Korisniks)
            {
                KorisnikBO korisnikBO = new KorisnikBO();
                korisnikBO.Ime = a.Ime;
                korisnikBO.Lozinka = a.Lozinka;
                korisnikBO.Prezime = a.Prezime;
                korisnikBO.DatumRodj = Convert.ToDateTime(a.DatumRodj);
                korisnikBO.Email = a.Email;
                korisnikBO.JMBG = a.JMBG;
                korisniks.Add(korisnikBO);
            }
            return View(korisniks);
        }
        public ActionResult ObrisiKorisnika(long id)
        {
            Korisnik a = new Korisnik();
            a = kDC.Korisniks.FirstOrDefault(t => t.JMBG == id);
            KorisnikBO korisnikBO = new KorisnikBO();
            korisnikBO.Ime = a.Ime;
            korisnikBO.Lozinka = a.Lozinka;
            korisnikBO.Prezime = a.Prezime;
            korisnikBO.DatumRodj = Convert.ToDateTime(a.DatumRodj);
            korisnikBO.Email = a.Email;
            korisnikBO.JMBG = a.JMBG;
            return View(korisnikBO);
        }
        [HttpPost]
        public ActionResult ObrisiKorisnika(long id,FormCollection collection)
        {
            Korisnik korisnik = new Korisnik();
            korisnik = kDC.Korisniks.FirstOrDefault(t => t.JMBG == id);
            kDC.Korisniks.DeleteOnSubmit(korisnik);
            kDC.SubmitChanges();
            return RedirectToAction("ListaKorisnika");

        }
    }
}