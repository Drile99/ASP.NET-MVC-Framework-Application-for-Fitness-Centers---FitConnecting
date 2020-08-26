using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DomaciZadatak.Models.Interfaces;
using DomaciZadatak.Models.EFRepository;
using DomaciZadatak.Models;

namespace DomaciZadatak.Controllers
{
    public class AccountController : Controller
    {
        private IAuthRepository authRepository = new AuthRepository();
        // GET: Korisnik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(KorisnikBO user)
        {
            if (authRepository.IsValid(user))
            {
                FormsAuthentication.SetAuthCookie(user.Email, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Uneti podaci nisu validni.");
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(KorisnikBO user)
        {
            authRepository.AddUser(user);
            return RedirectToAction("Login");
        }
    }
}