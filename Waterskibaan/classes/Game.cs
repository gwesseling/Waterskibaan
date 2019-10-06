using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Waterskibaan.classes.args;
using Waterskibaan.classes.wachtrij;

namespace Waterskibaan.classes {
    class Game {

        private Timer timer;
        private int counter;

        private WachtrijInstructie wachtrijInstructie;
        private InstructieGroep instructieGroep;
        private WachtrijStarten wachtrijStarten;

        private Waterskibaan ws;

        public delegate void NieuwBezoekerHandler(NieuweBezoekerArgs args);
        public event NieuwBezoekerHandler NieuweBezoeker;

        public delegate void InstructieAfgelopenHandler(InstructieAfgelopenArgs args);
        public event InstructieAfgelopenHandler InstructieAfgelopen;

        public Game() {
            this.ws = new Waterskibaan();
            this.wachtrijInstructie = new WachtrijInstructie();
            this.instructieGroep = new InstructieGroep();
            this.wachtrijStarten = new WachtrijStarten();
        }

        public void Initialize() {
            this.SetupTimer();

            this.NieuweBezoeker += this.wachtrijInstructie.OnNieuwBezoeker;
            this.InstructieAfgelopen += this.instructieGroep.OnInstructieAfgelopen;
            this.InstructieAfgelopen += this.wachtrijStarten.OnInstructieAfgelopen;
        }

        public void SetupTimer() {
            this.timer = new Timer(1000);

            this.timer.Elapsed += this.OnTimedEvent;
            this.timer.Elapsed += this.OnNieweBezoeker;
            this.timer.Elapsed += this.OnInstructieAfgelopen;
            this.timer.Elapsed += this.OnVeplaatsKabel;

            this.timer.AutoReset = true;
            this.timer.Enabled = true;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e) {
            this.counter++;
        }

        public void OnNieweBezoeker(Object source, ElapsedEventArgs e) {
            if (this.counter % 3 == 0) {
                NieuweBezoekerArgs args = new NieuweBezoekerArgs() {
                    Sporter = new Sporter(MoveCollection.GetWillekeurigeMoves())
                };

                this.NieuweBezoeker(args);
            }
        }

        public void OnInstructieAfgelopen(Object source, ElapsedEventArgs e) {
            if (this.counter % 20 == 0) {
                InstructieAfgelopenArgs args = new InstructieAfgelopenArgs() {
                    SportersKlaar = this.instructieGroep.SportersVerlatenRij(5),
                    NieuweSporters = this.wachtrijInstructie.SportersVerlatenRij(5)
                };

                this.InstructieAfgelopen(args);
            }
        }

        public void OnVeplaatsKabel(Object source, ElapsedEventArgs e) {
            if (this.counter % 4 == 0) {
                this.ws.VerplaatsKabel();

                if (this.ws.Kabel.IsStartPositieLeeg() && this.wachtrijStarten.GetAllSporters().Count > 0) {
                    Sporter sporter = this.wachtrijStarten.SportersVerlatenRij(1).First();
                    sporter.Skies = new Skies();
                    sporter.Zwemvest = new Zwemvest();

                    this.ws.SporterStart(sporter);
                }
            }
        }
    }
}
