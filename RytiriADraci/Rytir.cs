using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace RytiriADraci
{
    public class Rytir : Bojovnik
    {
        
        //KONSTRUKTORY
        //v2: rytířovi naimplementujte konstruktor
        /*jeden konstruktor bere jako parametr pouze jméno a nastaví 10 životů/hlav a sílu 3
        druhý konstruktor má dva parametry jméno a počet životů/počet hlav a nastaví sílu 3
        třetí konstruktor má tři parametry jméno, počet životů/hlav a sílu*/
        /// <summary>
        /// Trida Rytir ma tyto vlastnosti Jmeno, PocetZivotu, Sila, nepovinne: Obratnost, Brneni
        /// jsou nastavene parametry 10 životů/hlav a sílu 3
        /// </summary>
        /// <param name="jmeno">pojmenuj si rytire</param>
        public Rytir(string jmeno)
            : this(jmeno, 10)
        {
        }
        /// <summary>
        /// Trida Rytir ma tyto vlastnosti Jmeno, PocetZivotu, Sila, nepovinne: Obratnost, Brneni
        /// Je nastavena sila 3
        /// </summary>
        /// <param name="jmeno">pojmenuj si rytire</param>
        /// <param name="pocetZivotu">int</param>
        public Rytir(string jmeno, int pocetZivotu)
            : this(jmeno, pocetZivotu, 3, 3, 2)
        {
        }
        /// <summary>
        /// Trida Rytir ma tyto vlastnosti Jmeno, PocetZivotu, Sila, nepovinne: Obratnost, Brneni
        /// </summary>
        /// <param name="jmeno">pojmenuj si rytire</param>
        /// <param name="pocetZivotu">int</param>
        /// <param name="sila">int</param>
        public Rytir(string jmeno, int pocetZivotu, int sila, int obratnost, int brneni)

        {
            Jmeno = jmeno;
            PocetZivotu = pocetZivotu;
            Sila = sila;
            Obratnost = obratnost;
            Brneni = brneni;
        }
    
    }
}
