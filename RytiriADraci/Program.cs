using System;
using System.Threading;

/*
Rytir a drak

Jak bude fungovat útok rytíře:
na začátku hodí kostkou a určí aktuální sílu útoku v rozsahu 0 až síla
pokud bude mít drak hlavy, metoda ubere počet hlav podle aktuální síly útoku a vypíše informaci o útoku
pokud už žádné hlavy mít nebude, nic nedělá
pokud drakovi ubere poslední hlavu, vypíše informaci, že porazil draka
Jak bude fungovat útok draka:
na začátku hodí kostkou a určí aktuální sílu útoku v rozsahu 0 až síla
pokud bude mít rytíř životy, metoda ubere životy podle aktuální síly útoku a vypíše informaci o útoku
pokud už žádné životy nebudou, nic nedělá
pokud ubere poslední život, vypíše informaci, že porazil rytíře
V programu vytvořte 1 rytíře a 1 draka, je na vás, kolik dáte rytíři životů, drakovi hlav a jakou sílu (můžete využít generátor náhodných čísel i pro to)


Rozšíření: pokud použijete brnění a obratnost z předchozího příkladu, můžete zkusit vymyslet složitější souboj - např. pokud je síla útoku menší než brnění, útok se nepovede. Pokud je Obratnost soupeře vyšší než síla útoku, provede protiútok :-) Program si můžete zkomplikovat dle libosti :-) 
    
VERZE3: Tento úkol je variace na již předchozí. Pokud máte souboj s jedním rytířem a drakem, obě třídy můžete rovnou využít a jen upravit hlavní část programu.
Vytvořte souboj rytíře a draků:
vytvořte třídu rytíř, který bude mít tři vlastnosti, a to jméno, životy a sílu
vytvořte třídu drak, která bude mít tři vlastnosti, a to jméno, počet hlav a sílu
drakovi naimplementuje metodu MuzuBojovat, která vrátí true, pokud má drak ještě aspoň 1 hlavu
rytířovi naimplementujte metodu MuzuBojovat, která vrátí true, pokud má rytíř aspoň 1 život

rytířovi naimplementujte metodu Útoč, která bude mít jako vstupní parametr draka
- na začátku hodí kostkou a určí aktuální sílu útoku v rozsahu 0 až síla
- pokud bude mít drak hlavy, metoda ubere počet hlav podle aktuální síly útoku a vypíše informaci o útoku
- pokud už žádné hlavy mít nebude, nic nedělá
- pokud drakovi ubere poslední hlavu, vypíše informaci, že porazil draka
drakovi naimplementujte metodu Útoč, která bude mít jako vstupní parametr Rytíře
- na začátku hodí kostkou a určí aktuální sílu útoku v rozsahu 0 až síla
- pokud bude mít rytíř životy, metoda ubere životy podle aktuální síly útoky a vypíše informaci o útoku
- pokud už žádné životy nebudou, nic nedělá
- pokud ubere poslední život, vypíše informaci, že porazil rytíře

rytířovi i drakovi naimplementujte konstruktory
- jeden konstruktor bere jako parametr pouze jméno a nastaví 10 životů/hlav a sílu 3
- druhý konstruktor má dva parametry jméno a počet životů/počet hlav a nastaví sílu 3
- třetí konstruktor má tři parametry jméno, počet životů/hlav a sílu
v programu vytvořte 1 rytíře a pole 3 draků, je na vás, kolik dáte rytíři životů, a kolik drakům hlav a jakou sílu (můžete využít generátor náhodných čísel i pro to)

použijte generátor náhodných čísel Random na náhodné házení kostkou:
Random generatorNahodnychCisel = new Random();
int nahodneCislo = generatorNahodnychCisel.Next(3);
// vraci nahodne cislo od 0, ale mensi než zadané, tj. cislo < 3
v cyklu vždy vyberte náhodně draka, na kterého bude rytíř útočit a proveďte útok, pokud bude drak již poražen, rytíř si může odpočinout
poté vyberte náhodně draka, který bude útočit na rytíře, pokud se vybere již poražený drak, draci si dávají pauzu
jestli necháte prvního útočit rytíře nebo draky je na vás
nechejte na sebe střídavě útočit rytíře a draky tak dlouho, dokud nezůstane jen rytíř a nebo jej draci nezdolají.
Informaci o souboji vždy vypište podobně, jako na přechozím zadání.
BONUS: vytvořte pole s rytíři a proveďte boj dvou armád, nahodile vybírejte z obou tak dlouho, dokud jedna nezvítězí 🙂
 
 
 */
/// <summary>
/// Vytvoř třídu Rytíř, který bude mít vlastnosti: jméno, počet životů, sílu, obratnost a brnění
/// </summary>

//Vytvoř třídu Drak, který bude mít vlastnosti: jméno, počet hlav, sílu, obratnost a brnění
//v2: vytvořte třídu drak, která bude mít tři vlastnosti, a to jméno, počet hlav a sílu (podobně využijte předchozí)

namespace RytiriADraci

{
    /// <summary>
    /// bojiste - zde se odehrava souboj
    /// </summary>
    public class Program
    {

        public static void Main(string[] args)
        {
            UvedHru(); //vytiskne uvodni informaci o hre a jeji pravidlech

            //Vytvoreni postav_______________________________________________
            //deklarace draku 
            Tlupa tlupaDraku = new Tlupa(3, "Draci");
            tlupaDraku.PridejBojovnika(new Drak("Emil", 7, 7, 5, 1));
            tlupaDraku.PridejBojovnika(new Drak("Else", 7, 9, 3, 1));
            tlupaDraku.PridejBojovnika(new Drak("Elvis", 7, 9, 3, 1));

            tlupaDraku.PredstavClenyTlupy();

            //dekrarace ritiru
            Tlupa tlupaRytiru = new Tlupa(3, "Rytiri");
            tlupaRytiru.PridejBojovnika(new Rytir("Jindra", 7, 7, 3, 3));
            tlupaRytiru.PridejBojovnika(new Rytir("Jindriska", 7, 4, 3, 3));
            tlupaRytiru.PridejBojovnika(new Rytir("Jindrisko", 7, 4, 3, 3));

            tlupaRytiru.PredstavClenyTlupy();

            //dvojice bojovych tlup: bojoveTlupy[0] = utocnik, bojoveTlupy[1] = napadeny
            Tlupa[] bojoveTlupy = new Tlupa[2] { tlupaDraku, tlupaRytiru }; 
            //_______________________________________________________________________

            //Rozlosovani pocatecniho souboje
            int kteraTlupaJeNaRadeSUtokem = LosujKteraTlupaZacina(); // drzi informaci o tom ktera ze dvou tlup bojuje

            //LosujBojovouDvojiciZtlup(tlupaDraku, tlupaRytiru); //vyvere index bojovnika pro boj s kazde tlupy - provadi se jiz pri vytvareni instance tlupy

            //usporadana dvojice bojovniku: dvojiceBojovniku[0] = utocnik, dvojiceBojovniku[1] = napadeny
            Bojovnik[] dvojiceBojovniku = NastavUtocnikaAObrance();

            //parametry k boji
            bool provedeSeProtiutok = false;

            int pocetKol = 0;
            //cyklus SOUBOJ
            while (true)

            {
                pocetKol += 1;
                Console.WriteLine($"Kolo {pocetKol}.");
                //vytvori se instance souboje
                using (Souboj souboj = new Souboj(dvojiceBojovniku[0], dvojiceBojovniku[1]))
                {
                    souboj.ProvedUtokAInformujOvysledku(out provedeSeProtiutok);
                    int[] tlupyCoSeBrani = KteraTlupaSeBrani();
                    //redukuje napadenou tlupu o mrtve
                    bojoveTlupy[tlupyCoSeBrani[0]].RedukujTlupuOmrtve(bojoveTlupy[tlupyCoSeBrani[0]].AktivniBojovnik);
                    if (UkonciHruKdyzVymreNejakaTlupa(bojoveTlupy))
                    {
                        break;
                    }
                    //prohodi roli utocnik a napadeny podle pravidel
                    ZmenIndexTlupyNarade();
                    LosujBojovouDvojiciZtlup(bojoveTlupy);
                    dvojiceBojovniku = NastavUtocnikaAObrance();
                }
   
            }

            int[] KteraTlupaSeBrani()
            {
                int[] kdoSeBrani = new int[bojoveTlupy.Length - 1];
                int j = 0;
                for (int i = 0; i < bojoveTlupy.Length; i++)
                {
                    if( i != kteraTlupaJeNaRadeSUtokem)
                    {
                        kdoSeBrani[j] = i;
                        j += 1;
                    }
                }
                return kdoSeBrani;
            }

            Bojovnik[] NastavUtocnikaAObrance()
            {
                Bojovnik[] bojovaDvojice = new Bojovnik[2];
                switch (kteraTlupaJeNaRadeSUtokem)
                {
                    case 0:
                        bojovaDvojice[0] = tlupaRytiru.NactiBojovnika(tlupaRytiru.AktivniBojovnik);
                        bojovaDvojice[1] = tlupaDraku.NactiBojovnika(tlupaDraku.AktivniBojovnik);
                        break;
                    case 1:
                        bojovaDvojice[0] = tlupaDraku.NactiBojovnika(tlupaDraku.AktivniBojovnik);
                        bojovaDvojice[1] = tlupaRytiru.NactiBojovnika(tlupaRytiru.AktivniBojovnik);
                        break;
                }
                return bojovaDvojice;
            }

            /// <summary>
            /// Metoda vraci index tlupy, ktere bude v dalsim kole bojovat. Medota pocita jen se dvema tlupama.
            /// </summary>
            /// <param name="budeProtiutok">pokud je protiutok True, index AktualniTlupyNaRade ne nemeni</param>
            /// <param name="indexAktualniTlupyNaRade">index tlupy, ktera prave bojuje</param>
            /// <returns>int index bojove tlupy, ktera bude bojovat</returns>
            void ZmenIndexTlupyNarade()
            {
                if (!provedeSeProtiutok)
                {
                    kteraTlupaJeNaRadeSUtokem = ((-1*(kteraTlupaJeNaRadeSUtokem*2 - 1))+1)/2; //0,1 hodnota se prevedou na -1,1, prohodi se a pak se zas vrati na 0,1 
                }

            }
        }
        /// <summary>
        /// metoda nahodne vybira zacinajici tlupu
        /// </summary>
        /// <param name="pocetTlup"></param>
        /// <returns>intex tlupy int(0 - pocetTlup-1)</returns>
        private static int LosujKteraTlupaZacina(int pocetTlup = 2)
        {
            int kdoJeNaRade;
            Random hodKostkou = new Random(); //náhodne losuje kdo zacne, napr: 0- prvni tah ma rytir, 1- zacina drak
            kdoJeNaRade = hodKostkou.Next(pocetTlup);
            return kdoJeNaRade;
        }

        /// <summary>
        /// Nahodne vybere s kazde ze dvou ruznych bojovnych tlup tridy Tlupa jednoho soupere tridy Ritir nebo Drak
        /// </summary>
        /// <param name="hodKostkou">instance Random</param>
        /// <param name="tlupaDraku">Tlupa obsahujici bojovniky tridy Drak</param>
        /// <param name="tlupaRytiru">Tlupa obsahujici bojovniky tridy Ririr</param>
        /// <param name="i_drak">int index vylosovaneho draka z Tlupy draku</param>
        /// <param name="i_rytir">int index vylosovaneho ritire z Tlupy ritiru</param>
        private static void LosujBojovouDvojiciZtlup(Tlupa[] bojoveTlupy)
        {
            //TODO predelat na for
            bojoveTlupy[0].AktivniBojovnik = bojoveTlupy[0].VyberBojovnika();
            bojoveTlupy[1].AktivniBojovnik = bojoveTlupy[1].VyberBojovnika();
        }

        /// <summary>
        /// Vytiskne v konzoli uvodni informace ke hre
        /// </summary>
        private static void UvedHru()
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Pravidla:\n" + "1) Utoci jeden drak na jednoho rytire a naopak. V utoku se stridaji. Silu utoku redukuje obrane cislo napadeneho\n" +
                "2) Napadeny bojovnik muze vykonat protiutok podle sily obratnosti. Protiutok je miren na utocnika.\n" +
                    "Pokud branici se bojovnik umrel je nahodne vybran nahradnik." +
                    "3) Hra konci az vymre jedna z bojovych skupin. Ta prezivsi vyhrava.");

            Console.WriteLine("=============================================================");
        }

        private static bool UkonciHruKdyzVymreNejakaTlupa(Tlupa[] tlupy)
        {
            foreach (Tlupa item in tlupy)
            { 
                if (item.PocetZivychBojovniku <= 0) // pokud jeste zije nejaky drak, vybere se nahodne novy
                {
                    Console.WriteLine($"Konec. Tlupa {item.Jmeno} vymrela");
                    Console.ReadLine();
                    return true;
                }
            }
            return false;
        }

    } 
}

