using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan.classes {
    class Waterskibaan {

        private LijnenVoorraad lv;
        private Kabel kabel;

        public Waterskibaan() {
            this.kabel = new Kabel();
            this.lv = new LijnenVoorraad();

            for (int i = 0; i < 15; i++) {
                this.lv.LijnToevoegenAanRij(new Lijn());
            }
        }

        public void VerplaatsKabel() {
            this.kabel.VerschuifLijnen();

            Lijn lijn = this.kabel.VerwijderLijnVanKabel();

            if (lijn != null) {
                lv.LijnToevoegenAanRij(lijn);
            }
        }

        public override string ToString() {
            return $"{this.lv.ToString()}, Lijnen in gebruik: {this.kabel.ToString()}";
        }

    }
}
