using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Waterskibaan.classes;
using Waterskibaan.classes.args;
using Waterskibaan.interfaces;

namespace UI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private Game game;

        private int[,] locaties = {
            { 640, 470 },
            { 640, 224 }, 
            { 640, 33 }, 
            { 840, 33 }, 
            { 1056, 33 }, 
            { 1056, 224 }, 
            { 1056, 470},
            { 1056, 594},
            { 840, 594},
            { 640, 594},
        };

        private double[,] kabels = {
            { 47.5, 0},
            { 47.5, 0},
            { 50, 55},
            { 0, 53.5},
            { -68, 55},
            { -68, 0},
            { -68, 0},
            { -68, -56},
            { 0, -56},
            { 49, -58},
        };

        private List<UIElement> sportersInWachtrij = new List<UIElement>();
        private List<UIElement> sportersInInstructie = new List<UIElement>();
        private List<UIElement> sportersInStart = new List<UIElement>();
        private List<UIElement> sportersOpBaan = new List<UIElement>();
        private List<UIElement> lichtsteKleuren = new List<UIElement>();
        private List<UIElement> uniekeMoves = new List<UIElement>();

        public MainWindow() {
            InitializeComponent();

            this.game = new Game();
            this.game.Initialize();

            this.game.Timer.Tick += this.updateStats;
            this.game.NieuweBezoeker += RenderWachtrijInstructie;
            this.game.InstructieAfgelopen += RenderInstructies;
            this.game.VeplaatsKabel += RenderWachtrijStarten;
            this.game.VeplaatsKabel += RenderSportersOpBaan;
        }

        public void updateStats(Object source, EventArgs e) {
            clearElements(this.lichtsteKleuren);
            clearElements(this.uniekeMoves);

            LijnVoorraad.Text = "Lijnen in voorraad: " + this.game.Waterskibaan.LijnenVoorraad.GetAantalLijnen();
            Bezoekers.Text = "Totaal aantal bezoekers: " + this.game.Logger.AantalBezoekers();
            Score.Text = "Hoogste score: " + this.game.Logger.HoogsteScore();
            Rood.Text = "Aantal bezoekers met rode kleding: " + this.game.Logger.AantalSportersMetRodeKleding();
            Rondjes.Text = "Totaal aantal rondjes: " + this.game.Logger.TotaalRondjes();

            int x = 1122;
            int y = 179;

            List<System.Drawing.Color> kleuren = this.game.Logger.LichtsteKleuren();
            for (int i = 0; i < kleuren.Count(); i++) {
                Rectangle r = this.renderSporter(kleuren[i], x, y);
                this.lichtsteKleuren.Add(r);
                x += 30;

                if (i == 4) {
                    y = 209;
                    x = 1122;
                }
            }

            x = 1122;
            y = 311;

            List<IMoves> moves = this.game.Logger.Moves();

            for (int i = 0; i < moves.Count(); i++) {
                TextBlock tb = new TextBlock();
                tb.Text = (i + 1) + ". " + moves[i].Naam;

                Canvas.SetLeft(tb, x);
                Canvas.SetTop(tb, y);
                Canvas.Children.Add(tb);

                this.uniekeMoves.Add(tb);

                y += 30;
            }
        }

        public void RenderWachtrijInstructie(NieuweBezoekerArgs args) {
            this.RenderWachtrijInstructie();
        }

        public void RenderWachtrijInstructie() {
            List<Sporter> wachtrijInstructie = this.game.WachtrijInstructie.GetAllSporters();

            clearElements(this.sportersInWachtrij);
            int y = 370;
            int x = 315;

            foreach (Sporter s in wachtrijInstructie) {
                Rectangle r = this.renderSporter(s.KledingKleur, x, y);
                this.sportersInWachtrij.Add(r);

                y -= 30;

                if (y <= 70) {
                    y = 370;
                    x -= 30;
                }
            }
        }

        public void RenderInstructies(InstructieAfgelopenArgs args) {
            List<Sporter> instructie = args.NieuweSporters;

            clearElements(this.sportersInInstructie);
            int y = 464;
            int x = 224;

            foreach (Sporter s in instructie) {
                Rectangle r = this.renderSporter(s.KledingKleur, x, y);
                this.sportersInInstructie.Add(r);

                x -= 30;
            }

            this.RenderWachtrijInstructie();
        }

        public void RenderWachtrijStarten(VerplaatsKabelArgs args) {      
            List<Sporter> start = this.game.WachtrijStarten.GetAllSporters();

            clearElements(this.sportersInStart);
            int y = 192;
            int x = 495;

            foreach (Sporter s in start) {
                Rectangle r = this.renderSporter(s.KledingKleur, x, y);
                this.sportersInStart.Add(r);

                y += 30;
            }
        }

        public void RenderSportersOpBaan(VerplaatsKabelArgs args) {
            clearElements(this.sportersOpBaan);

            foreach (Lijn lijn in args.Lijnen) {
                Sporter s = lijn.Sporter;

                int x = locaties[lijn.PositieOpDeKabel, 0];
                int y = locaties[lijn.PositieOpDeKabel, 1];

                Line l = this.renderLine(x, y, 0, kabels[lijn.PositieOpDeKabel, 0], 0, kabels[lijn.PositieOpDeKabel, 1]);
                Rectangle r = this.renderSporter(s.KledingKleur, x, y);

                TextBlock number = new TextBlock();
                number.Text = "Lijn: " + lijn.Nummer.ToString();
                number.FontWeight = FontWeights.Bold;

                TextBlock move = new TextBlock();
                move.Text = "Huidige move: ";
                move.FontWeight = FontWeights.Bold;

                Canvas.SetLeft(number, x - 10);
                Canvas.SetTop(number, y + 25);
                Canvas.Children.Add(number);

                if (s.HuidigeMove != null) {
                    move.Text = "Huidige move: " + s.HuidigeMove.Naam;
                }

                Canvas.SetLeft(move, x - 40);
                Canvas.SetTop(move, y + 40);
                Canvas.Children.Add(move);

                this.sportersOpBaan.Add(r);
                this.sportersOpBaan.Add(l);
                this.sportersOpBaan.Add(number);
                this.sportersOpBaan.Add(move);
            }
        }

        public void clearElements(List<UIElement> elements) {
            foreach (UIElement e in elements) {
                if (Canvas.Children.Contains(e)) {
                    Canvas.Children.Remove(e);
                }
            }
        }

        public Line renderLine(double x, double y, double x1, double x2, double y1, double y2) {
            Line l = new Line();
            l.Stroke = new SolidColorBrush(Colors.Black);
            l.StrokeThickness = 1;
            l.X1 = x1;
            l.X2 = x2;
            l.Y1 = y1;
            l.Y2 = y2;

            Canvas.SetLeft(l, x + 12.5);
            Canvas.SetTop(l, y + 12.5);
            Canvas.Children.Add(l);

            return l;
        }

        public Rectangle renderSporter(System.Drawing.Color color, int x, int y) {
            Rectangle r = new Rectangle();
            r.Fill = new SolidColorBrush(Color.FromRgb(color.R, color.G, color.B));
            r.Height = 25;
            r.Width = 25;
            r.Stroke = new SolidColorBrush(Colors.Black);
            r.StrokeThickness = 1;

            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);
            Canvas.Children.Add(r);

            return r;
        }
    }
}
