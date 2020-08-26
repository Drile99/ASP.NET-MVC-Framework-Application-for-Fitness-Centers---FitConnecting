using DomaciZadatak.Models.Interfaces;
using DomaciZadatak.Models.LinqSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomaciZadatak.Models.EFRepository
{
    public class AuthRepository : IAuthRepository
    {
        private KorisniciDataContext kDC = new KorisniciDataContext();
        public void AddUser(KorisnikBO userBO)
        {
            if (IsValid(userBO)) return;

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
            userRole.RoleID = 1;
            userRole.UserID = userBO.JMBG;
            kDC.UserRoles.InsertOnSubmit(userRole);
            kDC.SubmitChanges();

        }

        public bool IsValid(KorisnikBO userBO)
        {
            bool isValid = kDC.Korisniks.Any(t => t.Email == userBO.Email && t.Lozinka == userBO.Lozinka);
            return isValid;
        }
    }
}