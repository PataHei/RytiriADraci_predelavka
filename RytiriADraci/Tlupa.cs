using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RytiriADraci
{
    public class Tlupa
    {
        Bojovnik[] bojovnici;
        public int PocetZivychBojovniku;
        Random kostka;

        //KONSTRUKTORY

        /// <summary>
        /// Umozni vytvorit skupinu bojovniku.
        /// </summary>
        /// <param name="pocetBojovniku"></param>

        public Tlupa(int pocetBojovniku)
        {
            bojovnici = new Bojovnik[pocetBojovniku];
            PocetZivychBojovniku = pocetBojovniku;
            kostka = new Random();

        }

        /// <summary>
        /// Zakladni tlupa tri bojovniku
        /// </summary>
        public Tlupa() : this(3)
        { }

        //METODY

        /// <summary>
        /// Prida bojovnika do pole bojovnici
        /// </summary>
        /// <param name="bojovnik"></param>
        public void PridejBojovnika(Bojovnik bojovnik)
        {
            for (int i = 0; i < bojovnici.Length; i++)
            {
                if (bojovnici[i] == null)
                {
                    bojovnici[i] = bojovnik;
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
            return bojovnici[index];
        }

        /// <summary>
        /// Vymaze mrtveho bojovnika z pole bojovnici
        /// </summary>
        /// <param name="index">index bojovnika v poli bojovnici</param>
        public void OdeberBojovnika(int index)
        {
            bojovnici[index] = null;
            
            return;
        }
        /// <summary>
        /// Seradi pole bojovnici podle poctu zivotu a spocita kolik zbylo zivich bojovniku
        /// </summary>
        void ZrevidujZiveBojovniky()
        {
            bojovnici = bojovnici.OrderBy(bojovnik => bojovnik.PocetZivotu).ToArray(); //seradi bojovniky podle zivotu
            PocetZivychBojovniku = bojovnici.Where(bojovnik => bojovnik != null).Count(); //spocte zive bojovniky
        }

        /// <summary>
        /// Zkontroluje zda bojovnik s indexem i s pole Tlupa.bojovnici je zivy a pokud ne aktualizuje pole bojovniku.
        /// </summary>
        /// <param name="i_bojovnik">index bojovnika v poli Tlupa.bojovnici</param>
        public void RedukujTlupuOmrtve(int i_bojovnik)
        {
            if (!bojovnici[i_bojovnik].MuzuBojovat())
            {
                //Console.WriteLine("Drak je mrtev!!!") - uz dela get PocetZivotu;

                OdeberBojovnika(i_bojovnik);
                ZrevidujZiveBojovniky();
                //UkonciHruKdyzVymreTlupa(tlupaDraku);

            }
        }

        /// <summary>
        /// Metoda vypise v konzoli cleny tlupy a jejich vlastnosti volanim metody PredstavSe() z tridy Bojovnik. 
        /// </summary>
        public void PredstavClenyTlupy()
        {
            for (int j = 0; j < PocetZivychBojovniku; j++)
            {
                string typInstance = bojovnici[j].GetType().ToString();  //GetType vrati nazev tridy vcetne namespace: RytiriADraci.Drak
                int poziceTecky = typInstance.IndexOf('.'); //najde pozici tecky
                bojovnici[j].PredstavSe(typInstance.Substring(poziceTecky + 1)); //Substring vybere s textu jen Drak, Rytir nebo jinou postavu co bude mit tridu
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
