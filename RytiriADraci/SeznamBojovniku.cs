using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RytiriADraci
{
    public class SeznamBojovniku
    {
        Rytir[] rytiri;
        public int PocetZivychRytiru;
        Drak[] draci;
        public int PocetZivychDraku;

        /// <summary>
        /// Umozni vytvorit skupinu rytiru a skupinu draku.
        /// </summary>
        /// <param name="pocetRytiru"></param>
        /// <param name="pocetDraku"></param>
        public SeznamBojovniku(int pocetRytiru, int pocetDraku)
        {
            rytiri = new Rytir[pocetRytiru];
            PocetZivychRytiru = pocetRytiru;
            draci = new Drak[pocetDraku];
            PocetZivychDraku = pocetDraku;
        }
        /// <summary>
        /// Zakladni tlupa tri postav
        /// </summary>
        public SeznamBojovniku() : this(3, 3)
        { }

        public void PridejRytire(Rytir rytir)
        {
            for (int i = 0; i < rytiri.Length; i++)
            {
                if (rytiri[i] == null)
                {
                    rytiri[i] = rytir;
                    break;
                }
            }
        }
        public Rytir NactiRytire(int index)
        {
            return rytiri[index];
        }
        public void OdeberRytire(int index)
        {
            rytiri[index] = null;
            return;
        }

        public void PridejDraka(Drak drak)
        {
            for (int i = 0; i < draci.Length; i++)
            {
                if (draci[i] == null)
                { 
                    draci[i] = drak;
                    break;
                }
            }
        }
        public Drak NactiDraka(int index)
        { 
            return draci[index];
        }
        /// <summary>
        /// Smaze draka ze seznamu a odecte jednoho draka z PoctuZivychDraku
        /// </summary>
        /// <param name="index">index draka</param>
        public void OdeberDraka(int index)
        {
            draci[index] = null;
            //Array.FindAll(Draci, drak => drak != null);
            return;
        }

        public void SeradZiveDraky()
        {
            Drak[] zivyDraci = new Drak[draci.Length]; //pomocny seznam
            int j =0; //pomocni inkrement
            for (int i = 0; i < draci.Length; i++)
            {
                if (draci[i] == null) continue;
                
                if (draci[i].MuzuBojovat())
                {
                    zivyDraci[j] = draci[i];
                    j++;
                  
                }

            }
            PocetZivychDraku = j;
            draci = zivyDraci;
           }
        public void SeradZiveRytire()
        {
            Rytir[] zivyRytiri = new Rytir[rytiri.Length]; //pomocny seznam
            int j = 0; //pomocni inkrement
            for (int i = 0; i < rytiri.Length; i++)
            {
                if (rytiri[i] == null) continue;

                if (rytiri[i].MuzuBojovat())
                {
                    zivyRytiri[j] = rytiri[i];
                    j++;

                }

            }
            PocetZivychRytiru = j;
            rytiri = zivyRytiri;
        }

    }
}
