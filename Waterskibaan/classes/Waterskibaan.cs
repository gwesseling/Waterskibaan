using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan.classes {
    public class Waterskibaan {

        public LijnenVoorraad LijnenVoorraad { get; set; }
        public Kabel Kabel { get; set; }

        public Waterskibaan() {
            this.Kabel = new Kabel();
            this.LijnenVoorraad = new LijnenVoorraad();

            for (int i = 0; i < 15; i++) {
                this.LijnenVoorraad.LijnToevoegenAanRij(new Lijn() {
                    Nummer = i
                });
            }
        }

        public void VerplaatsKabel() {
            this.Kabel.VerschuifLijnen();

            Lijn lijn = this.Kabel.VerwijderLijnVanKabel();

            if (lijn != null) {
                LijnenVoorraad.LijnToevoegenAanRij(lijn);
            }
        }

        public void SporterStart(Sporter s) {
            if (s.Skies == null || s.Zwemvest == null) {
                throw new Exception("Een sporter moet skies en een zwemvest hebben!");
            }

            if (this.Kabel.IsStartPositieLeeg()) {
                s.AantalRondesNogTeGaan = new Random().Next(1, 3);

                Lijn lijn = this.LijnenVoorraad.VerwijderdEersteLijn();        
                lijn.Sporter = s;
                lijn.PositieOpDeKabel = 0;

                this.Kabel.NeemLijnInGebruik(lijn);
            }
        }

        public override string ToString() {
            return $"{this.LijnenVoorraad}, Lijnen in gebruik: {this.Kabel}";
        }

    }
}
