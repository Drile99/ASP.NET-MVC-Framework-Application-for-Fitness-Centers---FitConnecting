using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomaciZadatak.Models
{
    public class AktivnostBO
    {
        [Display(Name = "Šifra aktivnosti: ")]
        [Required(ErrorMessage = "Morate uneti šifru aktivnosti!")]
        public int AktivnostID { get; set; }
        [Display(Name = "Naziv aktivnosti: ")]
        [Required(ErrorMessage = "Morate uneti naziv aktivnosti!")]
        public string Naziv { get; set; }
        [Display(Name = "Cena aktivnosti: ")]
        [Required(ErrorMessage = "Morate uneti cenu aktivnosti!")]
        public int Cena { get; set; }

    }
}