using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomaciZadatak.Models
{
    public class ZahtevOpremaBO
    {
        [Display(Name = "Šifra opreme: ")]
        [Required(ErrorMessage = "Morate uneti šifru opreme!")]
        public int OpremaID { get; set; }
        [Display(Name = "JMBG : ")]
        [Required(ErrorMessage = "Morate uneti JMBG!")]
        public int JMBG { get; set; }
        [Display(Name = "Količina : ")]
        [Required(ErrorMessage = "Morate uneti količinu!")]
        public int Kolicina { get; set; }
    }
}