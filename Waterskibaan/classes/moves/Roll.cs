using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes.moves {
    class Roll: IMoves {
        public String Naam { get; } = "Roll";

        public int Uitvoeren() {
            return new Random().Next(0, 11) > 5 ? 5 : 0;
        }

    }
}
