using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.classes;

namespace Waterskibaan.interfaces {
    interface IWachtrij {

        void SporterNeemPlaatsInRij(Sporter sporter);

        List<Sporter> GetAllSporters();

        List<Sporter> SportersVerlatenRij(int aantal);

    }
}
