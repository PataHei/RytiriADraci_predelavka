using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RytiriADraci
{
    public class Bojovnik
    {
        public string Jmeno { get; set; }
        int pocetZivotu;
        public int PocetZivotu {
            get 
            {
                return pocetZivotu;
            }
            set 
            { 
                if (value < 0)
                {
                    pocetZivotu = 0;
                }
                else
                {
                    pocetZivotu = value;
                }
            }
        }
        int sila;
        public int Sila 
        {
            get
            {
                return sila;
            }
            set
            {
                if (value < 0)
                {
                    sila = 0;
                }
                else
                {
                    sila = value;
                }
            }
        }
        int obratnost;
        public int Obratnost 
        {
            get
            {
                return obratnost;
            }
            set
            {
                if (value < 0)
                {
                    obratnost = 0;
                }
                else
                {
                    obratnost = value;
                }
            }
        }
        int brneni;
        public int Brneni 
        {
            get
            {
                return brneni;
            }
            set
            {
                if (value < 0)
                {
                    brneni = 0;
                }
                else
                {
                    brneni = value;
                }
            }
        } 

        
        //Constructor
        /// <summary>
        /// Scela volitelny bojovnik
        /// </summary>
        /// <param name="jmeno">string jmeno bojovnika</param>
        /// <param name="pocetZivotu">int pocet zivotu</param>
        /// <param name="sila">int sila uderu</param>
        /// <param name="obratnost">int schopnost uhybat utoku</param>
        /// <param name="brneni">int ucinnost pasivni obrany</param>
        public Bojovnik(string jmeno, int pocetZivotu, int sila, int obratnost, int brneni)
            :this()
        {
            Jmeno = jmeno;
            PocetZivotu = pocetZivotu;
            Sila = sila;
            Obratnost = obratnost;
            Brneni = brneni;
        }

        /// <summary>
        /// Bojovnik se silou 3 a 10 zivoty
        /// </summary>
        /// <param name="jmeno">pojmenuj si rytire</param>
        /// <param name="pocetZivotu">int</param>
        public Bojovnik(string jmeno)
            :this()
        {
            Jmeno = jmeno;
            PocetZivotu = 10;
            Sila = 3;

        }
        /// <summary>
        /// zakladni bojovnik s 10 zivoty, silou 2, obratnosti 1 a Brnenim 1. Konstruktor obsahuje instanci Random HodKostkou
        /// </summary>
        public Bojovnik()
        {
            Jmeno = "bojovnik";
            PocetZivotu = 10;
            Sila = 2;
            Obratnost = 1;
            Brneni = 1;

        }

        //METODY
        /// <summary>
        /// Vytiskne v konzoli informace o bojovnikovi
        /// </summary>
        /// <param name="potomekBojovnika">jmeno tridy, ktera je potomkem bojovnika</param>
        public void PredstavSe(string potomekBojovnika)
        {
            Console.WriteLine($"{potomekBojovnika} {Jmeno}\n Ma pocet zivotu: {PocetZivotu}, silu {Sila}, obratnost {Obratnost} a brneni {Brneni}. ");
        }

        /// <summary>
        /// Vrati informaci zda ma bojovnik vic jak 0 zivotu. Extension metoda
        /// </summary>
        /// <returns>true pokud ma vice nez nula zivotu</returns>
        public bool MuzuBojovat()
        {
            if (PocetZivotu <= 0)
            {
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// abstraktni metoda utoc musi obsahovat kod vykonavajici utok bojovnika na soupere
        /// </summary>
        /// <param name="souper">Bojovnik</param>
        /// <returns>int hodnota utoku = o kolik souper dostal ran</returns>
        public int Utoc(Bojovnik souper)
        {
            //Console.WriteLine("Útočím na draka " + drak.Jmeno + "!");
            Random hodKostkou = new Random();
            int utok = hodKostkou.Next(Sila + 1);
            Console.WriteLine(Jmeno + ": Sila utoku je " + utok + ". " + souper.Jmeno + " ma obranu " + souper.Brneni);
            if (utok == 0)
            {
                Console.WriteLine(Jmeno + " si dava pauzu.");
            }
            return utok;
        }

        /// <summary>
        /// Vyhodnoti do jake miry byl bojovnik zasazen
        /// </summary>
        /// <param name="zasah">int poctu efektivnich ran od bestie</param>
        /// <returns>Pocet zivotu ulozeny v PocetZivotu</returns>
        public int Zasazen(int zasah)
        {
            if (zasah > 0) // overi zda byl proveden utok a pak spocte efekt utoku podle obraneho cisla
            {
                int zraneni = zasah - Brneni;
                if (zraneni <= 0)
                {
                    Console.WriteLine("Smula! Utok byl vykryt");
                }
                else
                {
                    PocetZivotu -= zraneni;
                }
            }

            // Console.WriteLine("Stratil jsem " + zasah + " zivoty!");

            if (PocetZivotu <= 0)
            {
                Console.WriteLine(Jmeno + ": Jsem poražen ...");
                PocetZivotu = 0;

            }
            return PocetZivotu;
        }

        /// <summary>
        /// Vypise v konzoli vysledek utoku bojovnika na protivnika 
        /// </summary>
        /// <param name="utok">int sila utoku</param>
        /// <param name="ZivotyNepritelePredUtokem">int pocet zivotu</param>
        /// <param name="souper">Bojovnik na ktereho se utoci</param>
        public void VypisEffektUtoku(int utok, int ZivotyNepritelePredUtokem, Bojovnik souper) //Vypíse vysledek utoku Rytire na draka
        {
            if (utok == 0) // vypis podmineny silou utoku
            {
                Console.WriteLine($"{Jmeno}({PocetZivotu}) -> {souper.Jmeno}({souper.PocetZivotu}) => {souper.Jmeno} neutrpel zasah.");
            }

            else
            {
                Console.WriteLine($"{Jmeno}({PocetZivotu}) -> {souper.Jmeno}({ZivotyNepritelePredUtokem}) => {souper.Jmeno}({souper.PocetZivotu})");
            }
        }

        /// <summary>
        /// Vypocte zda protivnik po utoku vrati uder
        /// </summary>
        /// <param name="utok">int sila utoku</param>
        /// <returns>true pokud probehne protiutok</returns>
        public bool JeSchopenProtiutoku(int utok) //jde rytir do protiutoku? Dostane pripadne utok navic
        {
            //if (utok < Obratnost)
            //{ Console.WriteLine(Jmeno + " jde do protiutoku. Rytiri maji tah navic."); }
            //proti utok je ovlivnen dalsimi pravidli, ktere tato metoda nezohlednuje

            return utok < Obratnost;
        }


    }
}

