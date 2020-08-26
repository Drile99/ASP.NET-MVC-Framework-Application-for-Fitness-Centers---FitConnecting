using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DomaciZadatak.Models
{
    public class ZaposleniBO
    {
        public int ZaposleniID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int DatRodj { get; set; }
        public string Pozicija { get; set; }
    }
}