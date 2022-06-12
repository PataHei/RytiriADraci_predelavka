using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RytiriADraci
{
    class Souboj
    {
        //bojovnici
        Bojovnik utocnik;
        Bojovnik napadeny;
        int napadenyZivotyPredUtokem;
        int velikostUtoku;

        public Souboj(Bojovnik utocnik, Bojovnik napadeny)
        {
            this.utocnik = utocnik;
            this.napadeny = napadeny;
            napadenyZivotyPredUtokem = napadeny.PocetZivotu;
            velikostUtoku = 0;
        }
        

                    
        /// <summary>
        /// Metoda kde se provede utok utocnika na napadeneho. Zapocte se velikost zasahu, ktery napadeny dostane. Vysledek se zapise v konzoli
        /// </summary>
        public void ProvedUtokAInformujOvysledku(out bool budeProtiUtok)
        {
            velikostUtoku = utocnik.Utoc(napadeny); //provede se zapas utocnik -> napadeny
            napadeny.Zasazen(velikostUtoku);
            utocnik.VypisEffektUtoku(velikostUtoku, napadenyZivotyPredUtokem, napadeny);
            budeProtiUtok = napadeny.BudeProtiUtok(velikostUtoku);
        }

        ~Souboj()
        {
            Console.WriteLine("Konec kola souboje............................................");
        }


    }
    
}

