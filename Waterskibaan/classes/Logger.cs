using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.classes.args;

namespace Waterskibaan.classes {
    class Logger {

        public Kabel Kabel { get; set; }
        public List<Sporter> bezoekers;

        public Logger(Kabel kabel) {
            this.bezoekers = new List<Sporter>();
            this.Kabel = kabel;
        }

        public void OnNieuwBezoeker(NieuweBezoekerArgs args) {
            Sporter s = args.Sporter;

            if (!this.bezoekers.Contains(s)) {
                this.bezoekers.Add(s);
            }
        }
    }
}
