using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turisticka_agencija
{

    public enum Vrsta { Hotel, Hostel, Apartman}
  public  class Smestaj
    {


        protected string naziv;
        protected string destinacja;
        protected int udaljenost;
        protected Vrsta vrsta;


      public Smestaj(
         string naziv,
         string destinacja,
         int udaljenost,
         Vrsta vrsta 
            )
        {
            this.naziv = naziv;
            this.destinacja = destinacja;
            this.udaljenost = udaljenost;
            this.vrsta = vrsta; 

        
        }

        protected string Naziv { get => naziv; set => naziv = value; }
        protected string Destinacja { get => destinacja; set => destinacja = value; }
        protected int Udaljenost { get => udaljenost; set => udaljenost = value; }
        protected Vrsta Vrsta { get => vrsta; set => vrsta = value; }
    }
}
