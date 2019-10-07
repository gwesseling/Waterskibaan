using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Waterskibaan.classes.args;
using Waterskibaan.classes.wachtrij;

namespace Waterskibaan.classes {
    public class Game {

        private Timer timer;
        private int counter;

        public WachtrijInstructie WachtrijInstructie { get; set; }
        public InstructieGroep InstructieGroep { get; set; }
        public WachtrijStarten WachtrijStarten { get; set; }

        public Waterskibaan Waterskibaan { get; set; }

        public delegate void NieuwBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuwBezoekerHandler NieuweBezoeker;

        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        public Game() {
            this.Waterskibaan = new Waterskibaan();
            this.WachtrijInstructie = new WachtrijInstructie();
            this.InstructieGroep = new InstructieGroep();
            this.WachtrijStarten = new WachtrijStarten();
        }

        public void Initialize() {
            this.SetupTimer();

            this.NieuweBezoeker += this.WachtrijInstructie.OnNieuwBezoeker;
            this.InstructieAfgelopen += this.InstructieGroep.OnInstructieAfgelopen;
            this.InstructieAfgelopen += this.WachtrijStarten.OnInstructieAfgelopen;
        }

        private void SetupTimer() {
            this.timer = new Timer(1000);

            this.timer.Elapsed += this.OnTimedEvent;
            this.timer.Elapsed += this.OnNieweBezoeker;
            this.timer.Elapsed += this.OnInstructieAfgelopen;
            this.timer.Elapsed += this.OnVeplaatsKabel;

            this.timer.AutoReset = true;
            this.timer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e) {
            this.counter++;
        }

        private void OnNieweBezoeker(Object source, ElapsedEventArgs e) {
            if (this.counter % 3 == 0) {
                NieuweBezoekerArgs args = new NieuweBezoekerArgs() {
                    Sporter = new Sporter(MoveCollection.GetWillekeurigeMoves())
                };

                this.NieuweBezoeker(args);
            }
        }

        private void OnInstructieAfgelopen(Object source, ElapsedEventArgs e) {
            if (this.counter % 20 == 0) {
                InstructieAfgelopenArgs args = new InstructieAfgelopenArgs() {
                    SportersKlaar = this.InstructieGroep.SportersVerlatenRij(5),
                    NieuweSporters = this.WachtrijInstructie.SportersVerlatenRij(5)
                };

                this.InstructieAfgelopen(args);
            }
        }

        private void OnVeplaatsKabel(Object source, ElapsedEventArgs e) {
            if (this.counter % 4 == 0) {
                this.Waterskibaan.VerplaatsKabel();

                if (this.Waterskibaan.Kabel.IsStartPositieLeeg() && this.WachtrijStarten.GetAllSporters().Count > 0) {
                    Sporter sporter = this.WachtrijStarten.SportersVerlatenRij(1).First();
                    sporter.Skies = new Skies();
                    sporter.Zwemvest = new Zwemvest();

                    this.Waterskibaan.SporterStart(sporter);
                }
            }
        }
    }
}
