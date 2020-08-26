using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DomaciZadatak.Models
{
    public class KorisnikBO
    {
        [Display(Name ="JMBG")]
        [Required(ErrorMessage = "JMBG je potreban")]
        public long JMBG { get; set; }
        [Display(Name = "Ime")]
        [Required(ErrorMessage = "Ime je potrebno")]
        public string Ime { get; set; }
        [Display(Name = "Prezime")]
        [Required(ErrorMessage = "Prezime je potrebno")]
        public string Prezime { get; set; }
        [Display(Name = "Datum rodjenja")]
        [Required(ErrorMessage = "Datum rodjenja je potreban")]
        public DateTime DatumRodj { get; set; }
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail je potreban")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Lozinka je potrebna")]
        [Display(Name = "Lozinka")]
        [DataType(DataType.Password)]
        public string Lozinka { get; set; }
        [DisplayName("Potvrda lozinke")]
        [Required(ErrorMessage = "Molim vas potvrdite vasu lozinku.")]
        [DataType(DataType.Password)]
        [Compare("Lozinka")]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Rola")]
        public string Rola { get; set; }

    }
}