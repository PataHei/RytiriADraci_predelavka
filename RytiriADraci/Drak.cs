using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RytiriADraci
{
    public class Drak : Bojovnik
    {
        public int PocetHlav //Drak je bojovnik jehoz pocet zivotu je dany poctem hlav
        {
            get
            {
                return PocetZivotu;
            }
            set
            {
                PocetZivotu = value;
            }
        }
        //KONSTRUKTORY
        //v2: drakovi naimplementujte konstruktor
        /*jeden konstruktor bere jako parametr pouze jméno a nastaví 10 životů/hlav a sílu 3
        druhý konstruktor má dva parametry jméno a počet životů/počet hlav a nastaví sílu 3
        třetí konstruktor má tři parametry jméno, počet životů/hlav a sílu*/
        /// <summary>
        /// Trida Drak ma tyto vlastnosti Jmeno, PocetHlav, Sila, nepovinne: Obratnost, Brneni
        /// jsou nastavene parametry 10 životů/hlav a sílu 3
        /// </summary>
        /// <param name="jmeno">pojmenuj si rytire</param>
        public Drak(string jmeno)
        {
            Jmeno = jmeno;
            PocetHlav = 10;
            Sila = 3;
            
        }
        /// <summary>
        /// Trida Drak ma tyto vlastnosti Jmeno, PocetHlav, Sila, nepovinne: Obratnost, Brneni
        /// Je nastavena sila 3
        /// </summary>
        /// <param name="jmeno">pojmenuj si rytire</param>
        /// <param name="pocetZivotu">int</param>
        public Drak(string jmeno, int pocetHlav)
        {
            Jmeno = jmeno;
            PocetHlav = pocetHlav;
            Sila = 3;
            
        }
        /// <summary>
        /// Trida Drak ma tyto vlastnosti Jmeno, PocetHlav, Sila, nepovinne: Obratnost, Brneni
        /// </summary>
        /// <param name="jmeno">pojmenuj si draka</param>
        /// <param name="pocetHlav">int</param>
        /// <param name="sila">int</param>
        /// 
        public Drak(string jmeno, int pocetHlav, int sila, int obratnost, int brneni)
        {
            Jmeno = jmeno;
            PocetHlav = pocetHlav;
            Sila = sila;
            Obratnost = obratnost;
            Brneni = brneni;
            
        }

        //METODY
         public void MrsknutiOcasem(Bojovnik souper)
        {
            souper.PocetZivotu -= 1; 
            Console.WriteLine($"Drak prastil {souper.Jmeno} po hlave ocasem. Proti tomu neni obrany.");
        }
      
    }
}
