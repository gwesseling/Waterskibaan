using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes {
    abstract class Wachtrij : IWachtrij {

        public virtual int MAX_LENGTE_RIJ { get => 0; }
        private Queue<Sporter> wachtrij;

        public Wachtrij() {
            this.wachtrij = new Queue<Sporter>();
        }

        public void SporterNeemPlaatsInRij(Sporter sporter) {
            if (this.wachtrij.Count < 5) {
                this.wachtrij.Enqueue(sporter);
            }
        }

        public List<Sporter> GetAllSporters() {
            Sporter[] sporters = this.wachtrij.ToArray();
            return sporters.ToList();
        }

        public List<Sporter> SportersVerlatenRij(int aantal) {

            for (int i = 0; i < aantal; i++) {
                if (this.wachtrij.Count > 0) {
                    this.wachtrij.Dequeue();
                }
            }

            return this.GetAllSporters();
        }

        public override string ToString() {
            return $"Er staan {this.wachtrij.Count} sporters in de wachtrij.";
        }
    }
}
