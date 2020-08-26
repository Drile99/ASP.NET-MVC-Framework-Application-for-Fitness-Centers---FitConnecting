using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomaciZadatak.Models
{
    public class SalaBO
    {
        [Display(Name = "Šifra sale: ")]
        public int SalaID { get; set; }
        [Display(Name = "Kapacitet sale : ")]
        public int Kapacitet { get; set; }
    }
}