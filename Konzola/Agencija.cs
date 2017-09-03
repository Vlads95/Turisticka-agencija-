using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turisticka_agencija;
namespace Konzola
{
    class Agencija
    {


        string naziv;
        List<Aranzman> spisakAranzmana;

        public Agencija(string naziv)
        {
            this.naziv = naziv;
            spisakAranzmana = new List<Aranzman>();
        }

        public string Naziv { get => naziv; set => naziv = value; }
        public List<Aranzman> SpisakAranzmana { get => spisakAranzmana; set => spisakAranzmana = value; }



        //9. BROJEVI PASOSA PUTNIKA KOJI SU UPLATILI VISE OD JEDNOG ARANZMANA 
        public List<string> pasosiPutnika()
        {
            List<string> lista = new List<string>();

            foreach (Aranzman a in spisakAranzmana)
            {

                foreach (Putnik p in a.SpisakPutnika)
                {
                    int br = 0;

                    foreach (Aranzman a1 in spisakAranzmana)
                    {

                        foreach (Putnik p1 in a1.SpisakPutnika)
                        {
                            if (p.BrPasosa == p1.BrPasosa)
                            {
                                br++;
                            }

                        }


                    }

                    if (br > 1 && !lista.Contains(p.BrPasosa))
                    {
                        lista.Add(p.BrPasosa);
                    }

                }



            }

            return lista;

        }




        //11. DESTINACIJE ZA KOJE SE NUDI NAJVECI BROJ ARANZMANA 
        public List<string> destinacijeZaNajveciBrojAranzmana()
        {
            List<string> lista = new List<string>();
            int max = 0;

            foreach (Aranzman a in spisakAranzmana)
            {
                int br = 0;
                foreach (Aranzman a1 in spisakAranzmana)
                {
                    if (a.destinacija == a1.destinacija)
                    {
                        br++;
                    }
                    if (br > max) max = br;
                }
            }


            foreach (Aranzman a in spisakAranzmana)
            {
                int br = 0;
                foreach (Aranzman a1 in spisakAranzmana)
                {
                    if (a.destinacija == a1.destinacija)
                    {
                        br++;
                    }
                    if (br == max && !lista.Contains(a.destinacija)) lista.Add(a.destinacija);
                }
            }
            return lista;

        }

        //12. nazivi hotela na odredjenoj destinacji izmedju 2 i 4 zvezdice na kojima ne odseda  vise od  10 putnika preko 50 godina 
        public List<string> naziviHotela(string d)
        {
            List<string> lista = new List<string>();

            foreach (Aranzman a in spisakAranzmana)
            {
                if (a.destinacija == d && a.vrsta == Vrsta.Hotel)
                {
                    if (a.naziv.Contains("***") || a.naziv.Contains("**") || a.naziv.Contains("****"))
                    {

                        foreach (Putnik p in a.SpisakPutnika)
                        {
                            int br = 0;
                            if (p.DatumRodjenja.Year - DateTime.Today.Year > 50)
                            {
                                br++;
                            }

                            if (br > 10)
                            {
                                lista.Add(a.naziv);
                            }

                        }


                    }
                }

            }

            return lista;
        }




        /* 

              List<string> lista = new List<string>();
             foreach (Aranzman a in spisakAranzmana)
             {
                 foreach (Putnik p in a.SpisakPutnika)
                 {

                 }
             }

            return lista; 

     */

        //1. IMENA PUTNIKA KOJI PUTUJU ODREDJENOG DATUMA I ODSEDAJU U ODREDJENIJ VRSTI SMESTAJA 



        public List<string> imenaPutnika(DateTime d, Vrsta v)
        {

            List<string> lista = new List<string>();

            foreach (Aranzman a in spisakAranzmana)
            {
                if (a.DatumPolaska == d && a.vrsta == v)
                {
                    foreach (Putnik p in a.SpisakPutnika)
                    {
                        if (!lista.Contains(p.Ime)) lista.Add(p.Ime);

                    }
                }
            }


            return lista;
        }



        //2. SVE DESTINACIJE ZA KOJE SE NUDE ARANZMANI SA ODREDJENIM DATUMIM POLASKA  


        public List<string> destinacijeZaDatum(DateTime datum)
        {

            List<string> lista = new List<string>();

            foreach (Aranzman a in spisakAranzmana)
            {
                if (a.DatumPolaska == datum && !lista.Contains(a.destinacija))
                {
                    lista.Add(a.destinacija);
                }
            }

            return lista;

        }



        //3. TERMINI ZA DATI HOTEL KOJI SU RASPRODATI 

        public List<DateTime> terminiZaDatiHotel(Smestaj s)
        {


            List<DateTime> lista = new List<DateTime>();
            foreach (Aranzman a in spisakAranzmana)
            {
                if (a.naziv == s.naziv && a.MaxBrPutnika == a.SpisakPutnika.Count() && !lista.Contains(a.DatumPolaska))
                {
                    lista.Add(a.DatumPolaska);
                }

            }

            return lista;

        }
        //4. BROJ SLOBODNIH MESTA U DATOM TERMINU NA DATOJ DESTINACIJI U BILO KOJOJ VRSTU SMESTAJA 
        public int brSlobodnih(string destinacija, DateTime datum)
        {
            int br = 0;


            foreach (Aranzman a in spisakAranzmana)
            {
                if (a.destinacija == destinacija && a.DatumPolaska == datum)
                {
                    br += a.MaxBrPutnika - a.SpisakPutnika.Count();
                }
            }



            return br;
        }

        // 5

        public string najpopularnijaDestinacija()
        {
            List<string> listaDestinacija = new List<string>();
            int maxPosecenost = 0;
            string maxDestinacija = "";



            foreach (Aranzman a in spisakAranzmana)
            {
                if (!listaDestinacija.Contains(a.destinacija))
                {
                    listaDestinacija.Add(a.destinacija);
                }
            }


            foreach (string s in listaDestinacija)
            {
                int br = 0;
                foreach (Aranzman a in spisakAranzmana)
                {
                    if (a.destinacija == s)
                    {
                        br += a.SpisakPutnika.Count();
                    }

                }

                if (br > maxPosecenost)
                {
                    maxPosecenost = br;
                    maxDestinacija = s;

                }

            }





            return maxDestinacija;

        }

        //6.POSLEDNJI DATUM POLASKA ZA DATU DESTINACIJU 
        public DateTime poslednjiDatum (string d)
        {
            DateTime maxDatum = DateTime.MinValue;

            foreach (Aranzman a in spisakAranzmana)
            {
                if (a.destinacija==d && a.DatumPolaska>maxDatum)
                {
                    maxDatum = a.DatumPolaska;
                }
                
            }

            return maxDatum;


        }



     // 7. udaljenost od plaze i naziv smestaja u kome je odseo odredjeni putnik
        public string nazivIUdaljenostZaPutnika(Putnik putnik)
        {
            string odgovor = "";
            List<string> lista = new List<string>();
            foreach (Aranzman a in spisakAranzmana)
            {
                foreach (Putnik p in a.SpisakPutnika)
                {
                    if (p.BrPasosa==putnik.BrPasosa)
                    {
                        odgovor += a.naziv + "" + a.udaljenost;
                    }

                }
            }

            return odgovor;


        }


        //8.

        public List<Aranzman> aranzmaniKojiNisuProsliAImaFree()
        {
            DateTime danas = DateTime.Now;

            List<Aranzman> lista = new List<Aranzman>();
            foreach (Aranzman a in spisakAranzmana)
            {
                if (a.DatumPolaska> danas  && (a.MaxBrPutnika-a.SpisakPutnika.Count()>0) && !lista.Contains(a))
                {
                    lista.Add(a);
                }
            }

            return lista;



        }

        //11. 

        static void Main(string[] args)
        {
        }
    }
}
