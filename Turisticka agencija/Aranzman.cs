using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turisticka_agencija
{


    public class Aranzman : Smestaj

    {

        DateTime datumPolaska;
        double cena;
        int maxBrPutnika;
        List<Putnik> spisakPutnika;

        public Aranzman(
            DateTime datumPolaska,
        double cena,
        int maxBrPutnika, string naziv,
         string destinacja,
         int udaljenost,
         Vrsta vrsta) :base(naziv, destinacja,udaljenost,vrsta)
        {
            this.datumPolaska = datumPolaska;
            this.cena = cena;
            this.maxBrPutnika = maxBrPutnika;
            spisakPutnika = new List<Putnik>();
        }

        public DateTime DatumPolaska { get => datumPolaska; set => datumPolaska = value; }
        public double Cena { get => cena; set => cena = value; }
        public int MaxBrPutnika { get => maxBrPutnika; set => maxBrPutnika = value; }
        public List<Putnik> SpisakPutnika { get => spisakPutnika; set => spisakPutnika = value; }
    }
}
