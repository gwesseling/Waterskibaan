using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.classes.args;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes.wachtrij {
    class WachtrijStarten : Wachtrij {

        public override int MAX_LENGTE_RIJ { get => 20; }

        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args) {
            foreach (Sporter s in args.SportersKlaar) {
                this.SporterNeemPlaatsInRij(s);
            }
        }

    }
}
