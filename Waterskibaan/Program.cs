using System;
using Waterskibaan.classes;
using Waterskibaan.classes.wachtrij;

namespace Waterskibaan {
    class Program {
        static void Main(string[] args) {
            TestOpdracht12();
        }

        private static void TestOpdracht2() {
            Kabel k = new Kabel();

            Console.WriteLine(k.IsStartPositieLeeg());

            k.NeemLijnInGebruik(new Lijn());
            k.VerschuifLijnen();
            k.NeemLijnInGebruik(new Lijn());
            k.VerschuifLijnen();
            k.NeemLijnInGebruik(new Lijn());
            k.VerschuifLijnen();
            k.VerschuifLijnen();
            k.VerschuifLijnen();
            k.VerschuifLijnen();
            k.VerschuifLijnen();
            k.VerschuifLijnen();
            k.VerschuifLijnen();
            k.VerschuifLijnen();

            Console.WriteLine("Lijnen op de kabel: " + k.ToString());

            Console.WriteLine("Lijn: " + k.VerwijderLijnVanKabel().PositieOpDeKabel);

            Console.WriteLine("Lijnen op de kabel: " + k.ToString());

            k = new Kabel();

            Console.WriteLine("Lijnen op de kabel: " + k.ToString());
        }

        private static void TestOpdracht3() {
            LijnenVoorraad lv = new LijnenVoorraad();
            lv.LijnToevoegenAanRij(new Lijn());
            lv.LijnToevoegenAanRij(new Lijn());
            lv.LijnToevoegenAanRij(new Lijn());
            lv.LijnToevoegenAanRij(new Lijn());

            Console.WriteLine(lv.ToString());

            Console.WriteLine("Lijn: " + lv.VerwijderdEersteLijn().PositieOpDeKabel);

            Console.WriteLine(lv.ToString());
        }

        private static void TestOpdracht8() {
            Waterskibaan.classes.Waterskibaan ws = new Waterskibaan.classes.Waterskibaan();

            Sporter s = new Sporter(MoveCollection.GetWillekeurigeMoves());

            ws.SporterStart(s);
        }

        private static void TestOpdracht10() {
            Sporter s1 = new Sporter(MoveCollection.GetWillekeurigeMoves());
            Sporter s2 = new Sporter(MoveCollection.GetWillekeurigeMoves());

            WachtrijInstructie ws = new WachtrijInstructie();

            ws.SporterNeemPlaatsInRij(s1);
            ws.SporterNeemPlaatsInRij(s2);

            Console.WriteLine(ws);

            foreach (Sporter s in ws.GetAllSporters()) {
                Console.WriteLine(s);
            }

            ws.SportersVerlatenRij(1);

            Console.WriteLine(ws);

            ws.SportersVerlatenRij(5);

            Console.WriteLine(ws);


        }

        private static void TestOpdracht11() {
            Game game = new Game();
            game.Initialize();
            
            // keeps the console running.
            Console.ReadLine();
        }

        private static void TestOpdracht12() {
            Game game = new Game();
            game.Initialize();

            // keeps the console running.
            Console.ReadLine();
        }
    }
}
