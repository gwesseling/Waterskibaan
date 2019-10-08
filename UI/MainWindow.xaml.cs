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

namespace UI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private Game game;

        private List<Rectangle> sportersInWachtrij = new List<Rectangle>();
        private List<Rectangle> sportersInInstructie = new List<Rectangle>();
        private List<Rectangle> sportersInStart = new List<Rectangle>();

        public MainWindow() {
            InitializeComponent();

            this.game = new Game();
            this.game.Initialize();

            this.game.NieuweBezoeker += RenderWachtrijInstructie;
            this.game.InstructieAfgelopen += RenderInstructies;
            this.game.Timer.Tick += RenderWachtrijStarten;   
        }

        public void RenderWachtrijInstructie(NieuweBezoekerArgs args) {
            List<Sporter> wachtrijInstructie = this.game.WachtrijInstructie.GetAllSporters();

            clearSporters(this.sportersInWachtrij);
            int y = 370;
            int x = 315;

            foreach (Sporter sporter in wachtrijInstructie) {
                Rectangle r = this.renderSporter(sporter, x, y);
                this.sportersInWachtrij.Add(r);

                y -= 30;

                if (y < 70) {
                    y = 370;
                    x -= 30;
                }
            }
            
        }

        public void RenderInstructies(InstructieAfgelopenArgs args) {
            List<Sporter> instructie = args.NieuweSporters;

            clearSporters(this.sportersInInstructie);
            int y = 464;
            int x = 224;

            foreach (Sporter sporter in instructie) {
                Rectangle r = this.renderSporter(sporter, x, y);
                this.sportersInInstructie.Add(r);

                x -= 30;
            }  
        }

        public void RenderWachtrijStarten(Object source, EventArgs args) {      
            List<Sporter> start = this.game.WachtrijStarten.GetAllSporters();

            clearSporters(this.sportersInStart);
            int y = 352;
            int x = 495;

            foreach (Sporter sporter in start) {
                Rectangle r = this.renderSporter(sporter, x, y);
                this.sportersInStart.Add(r);

                y += 30;
            }
        }

        public void clearSporters(List<Rectangle> rectangles) {
            foreach (Rectangle r in rectangles) {
                if (Canvas.Children.Contains(r)) {
                    Canvas.Children.Remove(r);
                }
            }
        }

        public Rectangle renderSporter(Sporter sporter, int x, int y) {
            Rectangle r = new Rectangle();
            r.Fill = new SolidColorBrush(Color.FromRgb(sporter.KledingKleur.R, sporter.KledingKleur.G, sporter.KledingKleur.B));
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
