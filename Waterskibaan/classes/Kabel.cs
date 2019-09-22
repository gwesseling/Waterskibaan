using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan.classes {
    class Kabel {
        private LinkedList<Lijn> _lijnen { get; set; } = new LinkedList<Lijn>();

        public bool IsStartPositieLeeg() {
            return this._lijnen.Count == 0 || this._lijnen.First.Value.PositieOpDeKabel != 0;
        }

        public void NeemLijnInGebruik(Lijn lijn) {
            if (this.IsStartPositieLeeg()) {
                this._lijnen.AddFirst(lijn);
            }
        }

        public void VerschuifLijnen() {
            Lijn lijn = null;

            foreach (Lijn l in this._lijnen) {
                l.PositieOpDeKabel = l.PositieOpDeKabel + 1;

                if (l.PositieOpDeKabel > 9) {
                    lijn = l;
                }
            }

            if (lijn != null) {
                this._lijnen.Remove(lijn);
                lijn.PositieOpDeKabel = 0;
                this._lijnen.AddFirst(lijn);
            }
        }

        public Lijn VerwijderLijnVanKabel() {
            foreach (Lijn lijn in this._lijnen) {
                if (lijn.PositieOpDeKabel == 9) {
                    this._lijnen.Remove(lijn);
                    return lijn;
                }
            }

            return null;
        }

        public override string ToString() {
            string s = "";

            foreach (Lijn lijn in this._lijnen) {
                s += lijn.PositieOpDeKabel;

                if (lijn != this._lijnen.Last.Value) {
                    s += "|";
                }
            }

            return s;
        }


    }
}
