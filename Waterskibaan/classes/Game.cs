using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Threading;
using Waterskibaan.classes.args;
using Waterskibaan.classes.wachtrij;

namespace Waterskibaan.classes {
    public class Game {

        public DispatcherTimer Timer { get; set; }
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
            this.Timer = new DispatcherTimer();
            this.Timer.Interval = new TimeSpan(0,0, 1);

            this.Timer.Tick += this.OnTimedEvent;
            this.Timer.Tick += this.OnNieweBezoeker;
            this.Timer.Tick += this.OnInstructieAfgelopen;
            this.Timer.Tick += this.OnVeplaatsKabel;

            this.Timer.IsEnabled = true;
        }

        private void OnTimedEvent(Object source, EventArgs e) {
            this.counter++;
        }

        private void OnNieweBezoeker(Object source, EventArgs e) {
            if (this.counter % 3 == 0) {
                NieuweBezoekerArgs args = new NieuweBezoekerArgs() {
                    Sporter = new Sporter(MoveCollection.GetWillekeurigeMoves())
                };

                this.NieuweBezoeker(args);
            }
        }

        private void OnInstructieAfgelopen(Object source, EventArgs e) {
            if (this.counter % 20 == 0) {
                InstructieAfgelopenArgs args = new InstructieAfgelopenArgs() {
                    SportersKlaar = this.InstructieGroep.SportersVerlatenRij(5),
                    NieuweSporters = this.WachtrijInstructie.SportersVerlatenRij(5)
                };

                this.InstructieAfgelopen(args);
            }
        }

        private void OnVeplaatsKabel(Object source, EventArgs e) {
            if (this.counter % 4 == 0) {
                this.Waterskibaan.VerplaatsKabel();

                if (this.Waterskibaan.Kabel.IsStartPositieLeeg() && this.WachtrijStarten.GetAllSporters().Count > 0) {
                    Sporter sporter = this.WachtrijStarten.SportersVerlatenRij(1).First();
                    sporter.Skies = new Skies();
                    sporter.Zwemvest = new Zwemvest();

                    this.Waterskibaan.SporterStart(sporter);
                }

                Console.WriteLine("Kabel volgorde: " + this.Waterskibaan.Kabel);
            }
        }
    }
}
