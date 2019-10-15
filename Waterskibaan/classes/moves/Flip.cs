using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes.moves {
    class Flip : IMoves {
        public String Naam { get; } = "Flip";

        public int Uitvoeren() {
            return new Random().Next(0, 11) > 4 ? 10 : 0;
        }
    }
}
