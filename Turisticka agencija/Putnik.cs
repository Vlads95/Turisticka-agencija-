using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turisticka_agencija
{
    public class Putnik
    {

        string brPasosa;
        string ime;
        DateTime datumRodjenja;
        string brTelefona;

        public Putnik(
            string brPasosa,
        string ime,
        DateTime datumRodjenja,
        string brTelefona 
            )
        {
            this.brPasosa = brPasosa;
            this.ime = ime;
            this.datumRodjenja = datumRodjenja;
            this.brTelefona = brTelefona;
        }

        public string BrPasosa { get => brPasosa; set => brPasosa = value; }
        public string Ime { get => ime; set => ime = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string BrTelefona { get => brTelefona; set => brTelefona = value; }
    }
}
