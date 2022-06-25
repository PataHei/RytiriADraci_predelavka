using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RytiriADraci
{
    public class Tlupa
    {
        public Bojovnik[] Bojovnici;
        public int PocetZivychBojovniku;
        public int AktivniBojovnik; //bojovnik, ktery prave bojuje
        Random kostka;
        public string Jmeno;

        //KONSTRUKTORY

        /// <summary>
        /// Umozni vytvorit skupinu bojovniku.
        /// </summary>
        /// <param name="pocetBojovniku"></param>

        public Tlupa(int pocetBojovniku, string jmeno)
        {
            Bojovnici = new Bojovnik[pocetBojovniku];
            PocetZivychBojovniku = pocetBojovniku;
            kostka = new Random();
            AktivniBojovnik = VyberBojovnika();
            Jmeno = jmeno;

        }

        /// <summary>
        /// Zakladni tlupa tri bojovniku
        /// </summary>
        public Tlupa() : this(3, "zakladni tlupa")
        { }

        //METODY

        /// <summary>
        /// Prida bojovnika do pole bojovnici
        /// </summary>
        /// <param name="bojovnik"></param>
        public void PridejBojovnika(Bojovnik bojovnik)
        {
            for (int i = 0; i < Bojovnici.Length; i++)
            {
                if (Bojovnici[i] == null)
                {
                    Bojovnici[i] = bojovnik;
                    break;
                }
            }
        }
        /// <summary>
        /// Nacte bojovnika z pole bojovnici podle indexu
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Bojovnik NactiBojovnika(int index)
        {
            return Bojovnici[index];
        }

        /// <summary>
        /// Vymaze mrtveho bojovnika z pole bojovnici
        /// </summary>
        /// <param name="index">index bojovnika v poli bojovnici</param>
        public void OdeberBojovnika(int index)
        {
            Bojovnici[index] = null;
            return;
        }

        /// <summary>
        /// Seradi pole bojovnici podle poctu zivotu a spocita kolik zbylo zivich bojovniku
        /// </summary>
        void ZrevidujZiveBojovniky()
        {
            PocetZivychBojovniku = Bojovnici.Where(bojovnik => bojovnik != null).Count();
            Bojovnik[] tlupaZivych = Bojovnici.Select(bojovnik => bojovnik).Where(bojovnik => bojovnik != null).ToArray();
            Bojovnici = tlupaZivych.ToArray();

        }

        /// <summary>
        /// Zkontroluje zda bojovnik s indexem i s pole Tlupa.bojovnici je zivy a pokud ne aktualizuje pole bojovniku.
        /// </summary>
        /// <param name="i_bojovnik">index bojovnika v poli Tlupa.bojovnici</param>
        public void RedukujTlupuOmrtve(int i_bojovnik)
        {
            if (!Bojovnici[i_bojovnik].MuzuBojovat())
            {
                OdeberBojovnika(i_bojovnik);
                ZrevidujZiveBojovniky();
                if (PocetZivychBojovniku > 0)
                {
                    AktivniBojovnik = VyberBojovnika(); //nastavi nahradnika
                }
            }
        }

        /// <summary>
        /// Metoda vypise v konzoli cleny tlupy a jejich vlastnosti volanim metody PredstavSe() z tridy Bojovnik. 
        /// </summary>
        public void PredstavClenyTlupy()
        {
            for (int j = 0; j < PocetZivychBojovniku; j++)
            {
                string typInstance = Bojovnici[j].GetType().ToString();  //GetType vrati nazev tridy vcetne namespace: RytiriADraci.Drak
                int poziceTecky = typInstance.IndexOf('.'); //najde pozici tecky
                Bojovnici[j].PredstavSe(typInstance.Substring(poziceTecky + 1)); //Substring vybere s textu jen Drak, Rytir nebo jinou postavu co bude mit tridu
            }
        }

        //metody souvisejici se zapasem
        /// <summary>
        /// Vrati index nahodne vybraneho bojovnika s pole bojovnici
        /// </summary>
        /// <returns>int Index bojovnika v poli bojovnici</returns>
        public int VyberBojovnika()
        {
           return kostka.Next(PocetZivychBojovniku - 1);
        }

    }
}
