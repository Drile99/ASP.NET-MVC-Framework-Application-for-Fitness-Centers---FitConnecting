using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomaciZadatak.Models
{
    public class UplataBO
    {
        [Display(Name = "Šifra uplate : ")]
        public int IDUsluge { get; set; }
        [Display(Name = "Cena : ")]
        public int Cene { get; set; }
        [Display(Name = "Datum : ")]
        public DateTime Datum { get; set; }
        [Display(Name = "JMBG : ")]
        public long JMBG { get; set; }
        [Display(Name = "Šifra aktivnosti : ")]
        public int AktivnostID { get; set; }

    }
}