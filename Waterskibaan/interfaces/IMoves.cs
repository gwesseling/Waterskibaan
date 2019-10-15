using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterskibaan.interfaces {
    public interface IMoves {
        string Naam { get; }
        int Uitvoeren();
    }
}
