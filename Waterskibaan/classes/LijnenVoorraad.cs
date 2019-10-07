using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan.classes {
    public class LijnenVoorraad {
        private Queue<Lijn> _lijnen;

        public LijnenVoorraad() {
            this._lijnen = new Queue<Lijn>();
        }

        public void LijnToevoegenAanRij(Lijn lijn) {
            this._lijnen.Enqueue(lijn);
        }

        public Lijn VerwijderdEersteLijn() {
            if (this.GetAantalLijnen() > 0) {
                return this._lijnen.Dequeue();
            }

            return null;
        }

        public int GetAantalLijnen() {
            return _lijnen.Count;
        }

        public override string ToString() {
            return this.GetAantalLijnen() + " lijnen op voorraad";
        }
    }
}
