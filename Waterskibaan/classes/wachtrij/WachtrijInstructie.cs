using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.classes.args;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes.wachtrij {
    class WachtrijInstructie : Wachtrij {

        public override int MAX_LENGTE_RIJ { get => 100; }

        public void OnNieuwBezoeker(NieuweBezoekerArgs args) {
            this.SporterNeemPlaatsInRij(args.Sporter);
        }

    }
}
