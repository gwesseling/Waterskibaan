using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes {
    public class Kabel {
        public LinkedList<Lijn> _lijnen { get; set; }

        public Kabel() {
            this._lijnen = new LinkedList<Lijn>();
        }

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
            Random r = new Random();

            foreach (Lijn l in this._lijnen) {
                Sporter sporter = l.Sporter;
                sporter.HuidigeMove = null;

                if (sporter.Moves.Count > 0) {
                    int c = r.Next(4);
   
                    if (c == 0) {
                        int mv = r.Next(sporter.Moves.Count);
                        IMoves m = sporter.Moves[mv];
                        int score = m.Uitvoeren();
                        sporter.HuidigeMove = m;
                        sporter.BehaaldePunten += score;
                    }
                }

                if (l.PositieOpDeKabel >= 0 && l.PositieOpDeKabel < 10) {
                    l.PositieOpDeKabel++;
                }

                if (l.PositieOpDeKabel == 10 && sporter.AantalRondesNogTeGaan > 1) {
                    sporter.AantalRondesNogTeGaan--;
                    sporter.AantalRondes++;
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
                if (lijn.PositieOpDeKabel == 10 && lijn.Sporter.AantalRondesNogTeGaan == 1) {
                    lijn.Sporter.AantalRondes++;
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
