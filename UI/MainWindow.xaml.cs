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
        private DispatcherTimer timer;

        private Dictionary<Sporter, Rectangle> sportersInWachtrij = new Dictionary<Sporter, Rectangle>();


        private List<Sporter> prevInWachtrij = new List<Sporter>();

        private int y = 370;
        private int x = 315;

        public MainWindow() {
            InitializeComponent();

            this.game = new Game();
            this.game.Initialize();

            timer = new DispatcherTimer(DispatcherPriority.Normal);
            timer.Interval = TimeSpan.FromMilliseconds(25);
            timer.Tick += this.render;
            timer.IsEnabled = true;

           
        }

        public void render(object sender, EventArgs e) {
            List<Sporter> wachtrijInstructie = this.game.WachtrijInstructie.GetAllSporters();

            if (!prevInWachtrij.Equals(wachtrijInstructie)) {
                Console.WriteLine("Render");

                foreach (Sporter sporter in wachtrijInstructie) {
                    if (!this.sportersInWachtrij.ContainsKey(sporter)) {
                        Rectangle r = this.renderSporter(sporter, x, y);
                        this.sportersInWachtrij.Add(sporter, r);

                        y -= 30;

                        if (y < 40) {
                            y = 370;
                            x -= 30;
                        }
                    }
                }

                prevInWachtrij = wachtrijInstructie;
            }

  /*          foreach (Sporter sporter in this.game.wa)*/
        }

        public Rectangle renderSporter(Sporter sporter, int x, int y) {
            Rectangle r = new Rectangle();
            r.Fill = new SolidColorBrush(Color.FromRgb(sporter.KledingKleur.R, sporter.KledingKleur.G, sporter.KledingKleur.B));
            r.Height = 25;
            r.Width = 25;

            Canvas.SetLeft(r, x);
            Canvas.SetTop(r, y);
            Canvas.Children.Add(r);

            return r;
        }
    }
}
