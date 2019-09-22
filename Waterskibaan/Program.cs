using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.classes;

namespace Waterskibaan {
    class Program {
        static void Main(string[] args) {
            TestOpdracht3();
        }

        // TODO: add unit testing.
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
    }
}
