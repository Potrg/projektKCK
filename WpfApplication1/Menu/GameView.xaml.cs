using SnakeApp;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WPFSnake;

namespace WpfSnake.Menu
{
    /// <summary>
    /// Interaction logic for GameMenu.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        //Canvas canvas = new Canvas();
        public Key klawisz;
        internal bool muzik;
        public GameView()
        {
            InitializeComponent();
            
        }
        public GameView(int lvl, int speed, bool muzik)
        {
            InitializeComponent();
            Snake wonsz = new Snake(lvl, speed, muzik);
            wonsz.Snake_Init();
            usun_stara_glowe(new Koordynaty(10, 20));
            this.muzik = muzik;
        }
        public void sciany(List<Koordynaty> przeszkody)
        {
            //Wyswietla sciany - przeszkody
            //throw new NotImplementedException();

        }

        public void jedzenie(Koordynaty pokarm, int typ)
        {
            //wyswietla jedzenie i jedzenie specjalne 0=normal(yellow) 1=red 2=green  3=blue   4=white;
            //throw new NotImplementedException();
        }
        internal void weza(Queue<Koordynaty> wonsz)
        {
            Ellipse newEllipse = new Ellipse();
            newEllipse.Fill = Brushes.Green;
            newEllipse.Width = 6;
            newEllipse.Height = 6;

            Canvas.SetTop(newEllipse, wonsz.Dequeue().row);
            Canvas.SetLeft(newEllipse, wonsz.Dequeue().col);

            int count = canvas.Children.Count;
            canvas.Children.Add(newEllipse);


            // Restrict the tail of the snake
            if (count > 100)
            {
                canvas.Children.RemoveAt(count - 100 + 9);
            }

            foreach (Koordynaty pozycja in wonsz) // cos takiego
            {
                //Console.SetCursorPosition((int)pozycja.col, (int)pozycja.row);
                //Console.ForegroundColor = ConsoleColor.DarkGray;
                //Console.Write("█");
            }
            //rysowanie wensza
            //throw new NotImplementedException();
        }

        internal void game_over(int punkty,bool muzik)
        {
            GameOver gameover = new GameOver(punkty,muzik);
            gameover.Show();
            //okienko game over, wprwaoadzanie wyniku
        }

        internal void usun_stara_glowe(Koordynaty aktualnaGlowa)
        {
            
            //nadpisywanie glowy cialem
            //throw new NotImplementedException();
        }

        internal void pauza()
        {
            MessageBoxResult result1 = MessageBox.Show("Gra jest wstrzymana, czy chesz kontynuować?", "PAUZA", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result1 == MessageBoxResult.No)
            {
                //odpal główne menu
            }
            else return;

        }
        internal void zmien_kierunek_glowy(Koordynaty nowaGlowa, int kierunek_poruszania)
        {
            // tylko jesli glowa bedzie jakims krztaletem
            //throw new NotImplementedException();
        }

        internal void wyswietl_wynik(int v)
        {
            scoreshow.Text = v.ToString();
            //wyswietla wynik podczas gry
        }

        internal void usun_pokarm_lub_ogon(Koordynaty pokarm_specjalny)
        {
            // usuwa calkowicie z powierzchni gry
            //throw new NotImplementedException();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ((PageSwitcher)this.Parent).ResizeMode = ResizeMode.NoResize;
            string elo = Canvas.WidthProperty.ToString();

        }

        private void UserControl_KeyUp(object sender, KeyEventArgs e)
        {
            klawisz = e.Key;
        }
        // wyświetlanie
    }
}
