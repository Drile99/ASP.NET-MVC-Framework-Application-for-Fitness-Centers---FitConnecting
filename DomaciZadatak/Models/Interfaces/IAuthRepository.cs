using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomaciZadatak.Models.Interfaces
{
    interface IAuthRepository
    {
        bool IsValid(KorisnikBO userBO);

        void AddUser(KorisnikBO userBO);
    }
}

