using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.classes.args;

namespace Waterskibaan.classes.wachtrij {
    class InstructieGroep : Wachtrij {

        public override int MAX_LENGTE_RIJ { get => 5; }

        public void OnInstructieAfgelopen(InstructieAfgelopenArgs args) {
            foreach (Sporter s in args.NieuweSporters) {
                this.SporterNeemPlaatsInRij(s);
            }
        }

    }
}
