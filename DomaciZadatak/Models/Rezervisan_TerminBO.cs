using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomaciZadatak.Models
{
    public class Rezervisan_TerminBO
    {
        [Display(Name = "Šifra termina: ")]
        [Required(ErrorMessage = "Morate uneti šifru termina!")]
        public int TerminID { get; set; }
        [Display(Name = "Šifra sale: ")]
        [Required(ErrorMessage = "Morate uneti šifru sale!")]
        public int SalaID { get; set; }
        [Display(Name = "Datum: ")]
        [Required(ErrorMessage = "Morate uneti datum!")]
        public DateTime DatumVreme { get; set; }
        [Display(Name = "Šifra aktivnosti: ")]
        [Required(ErrorMessage = "Morate uneti šifru aktivnosti!")]
        public int AktivnostID { get; set; }
        [Display(Name = "JMBG: ")]
        [Required(ErrorMessage = "Morate uneti JMBG!")]
        public long JMBG { get; set; }
    }
}