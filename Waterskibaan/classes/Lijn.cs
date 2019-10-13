using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan.classes {
    public class Lijn {
        public int Nummer { get; set; }
        public int PositieOpDeKabel { get; set; } = 0;
        public Sporter Sporter { get; set; }
    }
}
