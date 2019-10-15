using System;
using System.Collections.Generic;
using System.Drawing;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes {
    public class Sporter {
        public int AantalRondes { get; set; } = 0;
        public int AantalRondesNogTeGaan { get; set; } = 0;
        public Zwemvest Zwemvest { get; set; }
        public Skies Skies { get; set; }
        public Color KledingKleur { get; set; }
        public List<IMoves> Moves { get; set; }
        public int BehaaldePunten { get; set;  } = 0;
        public IMoves HuidigeMove { get; set; }

        public Sporter(List<IMoves> moves) {
            Random random = new Random();

            this.Moves = moves;
            this.KledingKleur = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
        }

    }
}
