using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes {
    abstract class Wachtrij : IWachtrij {

        public virtual int MAX_LENGTE_RIJ { get => 5; }
        private Queue<Sporter> wachtrij;

        public Wachtrij() {
            this.wachtrij = new Queue<Sporter>();
        }

        public void SporterNeemPlaatsInRij(Sporter sporter) {
            if (this.wachtrij.Count < this.MAX_LENGTE_RIJ) {
                this.wachtrij.Enqueue(sporter);
            }
        }

        public List<Sporter> GetAllSporters() {
            Sporter[] sporters = this.wachtrij.ToArray();
            return sporters.ToList();
        }

        public List<Sporter> SportersVerlatenRij(int aantal) {
            List<Sporter> sporters = new List<Sporter>();

            for (int i = 0; i < aantal; i++) {
                if (this.wachtrij.Count > 0) {
                    sporters.Add(this.wachtrij.Dequeue());
                }
            }

            return sporters;
        }

        public override string ToString() {
            return $"{this.wachtrij.Count} sporter(s) in de wachtrij.";
        }
    }
}
