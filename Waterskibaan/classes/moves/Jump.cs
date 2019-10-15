using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes.moves {
    class Jump : IMoves {
        public String Naam { get; } = "Jump";

        public int Uitvoeren() {
            return new Random().Next(0, 11) > 1 ? 2 : 0;
        }
    }
}
