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
            Random hodKostkou = new Random();

            //deklarace draku 
            Tlupa tlupaDraku = new Tlupa(3);
            tlupaDraku.PridejBojovnika(new Drak("Emil", 7, 7, 5, 1));
            tlupaDraku.PridejBojovnika(new Drak("Else", 7, 9, 3, 1));
            tlupaDraku.PridejBojovnika(new Drak("Elvis", 7, 9, 3, 1));

            tlupaDraku.PredstavClenyTlupy();

            //dekrarace ritiru
            Tlupa tlupaRytiru = new Tlupa(3);
            tlupaRytiru.PridejBojovnika(new Rytir("Jindra", 7, 7, 3, 3));
            tlupaRytiru.PridejBojovnika(new Rytir("Jindriska", 7, 4, 3, 3));
            tlupaRytiru.PridejBojovnika(new Rytir("Jindrisko", 7, 4, 3, 3));

            tlupaRytiru.PredstavClenyTlupy();

            UvedHru(); //vytiskne uvodni informaci o hre a jeji pravidlech

            //Rozlosovani pocatecniho souboje
            //Random hodKostkou = new Random(); //náhodne losuje kdo zacne 0: prvni tah ma rytir, 1: zacina drak
            int kdoJeNaRade = hodKostkou.Next(2);
            int iterujeBojovniky = kdoJeNaRade * 2 - 1; // bere hodnoty -1 a 1
            
            //vyber bojovniku
            int i_drak;
            int i_rytir;
            
            //prvni bojova dvojice
            VyberBojovouDvojici(tlupaDraku, tlupaRytiru, out i_drak, out i_rytir);
            Bojovnik[] bojovaDvojice = NastavUtocnikaAObrance(kdoJeNaRade, tlupaDraku, tlupaRytiru, i_rytir, i_drak);
            Tlupa[] bojoveTlupy = //NastavUtocnouAObranouTlupu(); - nebo udelat iterator
            //cyklus SOUBOJ
            while (true)

            {
                //provede se zapas Rytir -> Drak
                Souboj utokRytireNaDraka = new Souboj(bojovaDvojice[0], bojovaDvojice[1]);
                bool provedeSeProtiutok;
                utokRytireNaDraka.ProvedUtokAInformujOvysledku(out provedeSeProtiutok);

                //redukuje pocet draku o mrtve
                tlupaDraku.RedukujTlupuOmrtve(i_drak);
                UkonciHruKdyzVymreTlupa(tlupaDraku, tlupaRytiru);
                //prohodi roli utocnik a napadeny podle pravidel
                VyberBojovouDvojici(tlupaDraku, tlupaRytiru, out i_drak, out i_rytir);
                bojovaDvojice = NastavUtocnikaAObrance(IndexBojovnikaNaRade(provedeSeProtiutok, iterujeBojovniky), tlupaDraku, tlupaRytiru, i_rytir, i_drak);
            }

        }
        private static int IndexBojovnikaNaRade(bool budeProtiutok, int iterujeBojovniky)
        {
            if (!budeProtiutok)
            {
                iterujeBojovniky *= -1;
            }

            return iterujeBojovniky * 2 - 1;
        }
        private static Bojovnik[] NastavUtocnikaAObrance( int indexBojovnikaNaRade, Tlupa tlupaDraku, Tlupa tlupaRytiru, int i_rytir, int i_drak)
        {
            Bojovnik[] bojovaDvojice = new Bojovnik[2];
            switch (indexBojovnikaNaRade)
            {
                case 0:
                    bojovaDvojice[0] = tlupaRytiru.NactiBojovnika(i_rytir);
                    bojovaDvojice[1] = tlupaDraku.NactiBojovnika(i_drak);
                    break;
                case 1:
                    bojovaDvojice[0] = tlupaDraku.NactiBojovnika(i_drak);
                    bojovaDvojice[1] = tlupaRytiru.NactiBojovnika(i_rytir);
                    break;
            }
            return bojovaDvojice;
        }

        /// <summary>
        /// Nahodne vybere s kazde ze dvou ruznych bojovnych tlup tridy Tlupa jednoho soupere tridy Ritir nebo Drak
        /// </summary>
        /// <param name="hodKostkou">instance Random</param>
        /// <param name="tlupaDraku">Tlupa obsahujici bojovniky tridy Drak</param>
        /// <param name="tlupaRitiru">Tlupa obsahujici bojovniky tridy Ririr</param>
        /// <param name="i_drak">int index vylosovaneho draka z Tlupy draku</param>
        /// <param name="i_rytir">int index vylosovaneho ritire z Tlupy ritiru</param>
        private static void VyberBojovouDvojici(Tlupa tlupaDraku, Tlupa tlupaRitiru, out int i_drak, out int i_rytir)
        {
            Thread.Sleep(10);
            i_drak = tlupaDraku.VyberBojovnika();
            //int i_drak = hodKostkou.Next(bojovaSkupina.PocetZivychDraku - 1);//index draka co zacina
            //vyber prvniho rytire
            Thread.Sleep(10);
            i_rytir = tlupaRitiru.VyberBojovnika();
            //int i_rytir = hodKostkou.Next(bojovaSkupina.PocetZivychRytiru - 1);//index rytire co zacina
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

        private static void UkonciHruKdyzVymreTlupa(Tlupa napadeni, Tlupa utocnici)
        {
            if (napadeni.PocetZivychBojovniku <= 0) // pokud jeste zije nejaky drak, vybere se nahodne novy
            {
                Console.WriteLine("Konec. Napadeni padli");
                Console.ReadLine();
                return;
            }

            if (utocnici.PocetZivychBojovniku <= 0) // pokud jeste zije nejaky drak, vybere se nahodne novy
            {
                Console.WriteLine("Konec. Utocnici padli");
                Console.ReadLine();
                return;
            }

        }

    } 
}

