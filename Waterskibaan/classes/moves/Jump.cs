using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes.moves {
    class Jump : IMoves {

        public int Move() {
            return new Random().Next(0, 11) > 2 ? 2 : 0;
        }
    }
}
