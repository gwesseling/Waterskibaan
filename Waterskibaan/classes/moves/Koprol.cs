using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes.moves {
    class Koprol : IMoves {
        public string Naam { get; } = "Koprol";

        public int Uitvoeren() {
            return new Random().Next(0, 11) > 4 ? 8 : 0;
        }
    }
}
