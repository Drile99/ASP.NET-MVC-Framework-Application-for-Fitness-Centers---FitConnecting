using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomaciZadatak.Models;
using DomaciZadatak.Models.Interfaces;
using DomaciZadatak.Models.LinqSql;

namespace DomaciZadatak.Controllers
{
    public class KorisnikController : Controller
    {
        private IKorisnikRepository korisnikRepository;
        // GET: Korisnik

        public KorisnikController()
        {
            korisnikRepository = new KorisnikSqlRepository();
        }

        public ActionResult Index()
        {
            List<KorisnikBO> korisniks = korisnikRepository.ListAll();
            return View(korisniks);
        }
    }
}