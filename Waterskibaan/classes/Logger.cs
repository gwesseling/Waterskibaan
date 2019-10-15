using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waterskibaan.classes.args;
using Waterskibaan.interfaces;

namespace Waterskibaan.classes {
    public class Logger {
        private Kabel Kabel { get; set; }
        public List<Sporter> bezoekers;

        public Logger(Kabel kabel) {
            this.bezoekers = new List<Sporter>();
            this.Kabel = kabel;
        }

        public int AantalBezoekers() {
            return this.bezoekers.Count();
        }

        public int AantalSportersMetRodeKleding() {
            return this.bezoekers.Where(i => this.ColorsAreClose(System.Drawing.Color.FromArgb(255, 0, 0), i.KledingKleur, 100)).Count();
        }

        public int HoogsteScore() {
            return this.bezoekers.Count() > 0 ? this.bezoekers.Max(i => i.BehaaldePunten) : 0;
        }

        public int TotaalRondjes() {
           return this.bezoekers.Select(i => i.AantalRondes).Sum();
        }

        public List<System.Drawing.Color> LichtsteKleuren() {
            return this.bezoekers.OrderByDescending(i => ColorValue(i.KledingKleur)).Take(10).Select(i => i.KledingKleur).ToList();
        }

        public List<IMoves> Moves() {
            List<IMoves> moves = new List<IMoves>();
            List<Sporter> sporters = this.Kabel._lijnen.Select(i => i.Sporter).ToList();

            sporters.ForEach(s => s.Moves.ForEach(m => {
                if (!moves.Contains(m))
                    moves.Add(m);
            }));

            return moves.OrderBy(i => i.Naam).ToList();
        }

        private int ColorValue(System.Drawing.Color color) {
            return (color.R ^ 2) + (color.G ^ 2) + (color.B ^ 2);
        }

        private bool ColorsAreClose(System.Drawing.Color a, System.Drawing.Color z, int treshold = 50) {
            int r = (int)a.R - z.R,
                g = (int)a.G - z.G,
                b = (int)a.B - z.B;
            return (r * r + g * g + b * b) <= treshold * treshold;
        }

        public void OnNieuwBezoeker(NieuweBezoekerArgs args) {
            Sporter s = args.Sporter;

            if (!this.bezoekers.Contains(s)) {
                this.bezoekers.Add(s);
            }
        }
    }
}
