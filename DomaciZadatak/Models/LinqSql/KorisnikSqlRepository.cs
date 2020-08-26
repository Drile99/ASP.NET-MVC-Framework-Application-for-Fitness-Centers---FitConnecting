using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using DomaciZadatak.Models.Interfaces;

namespace DomaciZadatak.Models.LinqSql
{
    public class KorisnikSqlRepository : IKorisnikRepository
    {
        private KorisniciDataContext kDC = new KorisniciDataContext();
        public void Dodaj(KorisnikBO korisnik)
        {
            Korisnik korisnikSql = new Korisnik();
            korisnikSql.JMBG = korisnik.JMBG;
            korisnikSql.Ime = korisnik.Ime;
            korisnikSql.Prezime = korisnik.Prezime;
            korisnikSql.DatumRodj = korisnik.DatumRodj;
            korisnikSql.Email = korisnik.Email;
            korisnikSql.Lozinka = korisnik.Lozinka;
            kDC.Korisniks.InsertOnSubmit(korisnikSql);
 
            kDC.SubmitChanges();
        }

        public void DodajUplatu(UplataBO uplataBO)
        {
            Uplata uplata = new Uplata()
            {
                AktivnostID = uplataBO.AktivnostID,
                Cene = uplataBO.Cene,
                Datum = DateTime.Now,
                JMBG = uplataBO.JMBG

            };
            kDC.Uplatas.InsertOnSubmit(uplata);
            kDC.SubmitChanges();
        }

        public KorisnikBO GetById(int korisnikid)
        {
            throw new NotImplementedException();
        }

        public List<KorisnikBO> ListAll()
        {
            List<KorisnikBO> korisniks = new List<KorisnikBO>();
            foreach (Korisnik k in kDC.Korisniks)
            {
                KorisnikBO korisnikBO = new KorisnikBO();
                korisnikBO.JMBG = k.JMBG;
                korisnikBO.Ime = k.Ime;
                korisnikBO.Prezime = k.Prezime;
                korisnikBO.Email = k.Email;
                korisnikBO.DatumRodj = Convert.ToDateTime(k.DatumRodj);
                korisnikBO.Lozinka = k.Lozinka;
                korisniks.Add(korisnikBO);
            }
            
            return korisniks;
        }

        public void Obrisi(KorisnikBO korisnik)
        {
            throw new NotImplementedException();
        }

        public void Update(KorisnikBO korisnik)
        {
            throw new NotImplementedException();
        }
    }
}