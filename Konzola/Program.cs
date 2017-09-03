using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turisticka_agencija;
namespace Konzola
{
    class Program
    {


        string naziv;
        List<Aranzman> spisakAranzmana;

        public Program(string naziv)
        {
            this.naziv = naziv;
            spisakAranzmana = new List<Aranzman>();
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public List<Aranzman> SpisakAranzmana { get => spisakAranzmana; set => spisakAranzmana = value; }

        static void Main(string[] args)
        {
        }
    }
}
