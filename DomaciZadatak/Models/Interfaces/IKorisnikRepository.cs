using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomaciZadatak.Models.Interfaces
{
    public interface IKorisnikRepository
    {
        List<KorisnikBO> ListAll();

        KorisnikBO GetById(int korisnikid);

        void Dodaj(KorisnikBO korisnik);

        void Update(KorisnikBO korisnik);

        void Obrisi(KorisnikBO korisnik);

        void DodajUplatu(UplataBO uplataBO);
    }
}
