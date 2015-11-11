using SnakeApp;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using WPFSnake;
using System;
using System.Windows.Threading;

namespace WpfSnake.Menu
{
    /// <summary>
    /// Interaction logic for GameMenu.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        //Canvas canvas = new Canvas();
        internal bool muzik;
        public GameView()
        {
            InitializeComponent();
            
        }
        //Snake wonsz;
        public int lvl, speed;
        public Key klucz = Key.None;
        //Thread oThread;
        public GameView(int lvl, int speed, bool muzik)
        {
           // wonsz = new Snake(lvl, speed, muzik);
            this.muzik = muzik;
            this.speed = speed;
            this.lvl = lvl;
            InitializeComponent();
            usun_stara_glowe(new Koordynaty(10, 20));
            //wonsz.Snake_Init();
            //wonsz.snakeLoop();
            // oThread = new Thread(wonsz.snakeLoop);
            // oThread.SetApartmentState(ApartmentState.STA);
            //oThread.Start();
            //while (!oThread.IsAlive);
            
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
            //Ellipse newEllipse = new Ellipse();
            //newEllipse.Fill = Brushes.Green;
            //newEllipse.Width = 6;
            //newEllipse.Height = 6;

            //Canvas.SetTop(newEllipse, wonsz.Dequeue().row);
            //Canvas.SetLeft(newEllipse, wonsz.Dequeue().col);

            //int count = canvas.Children.Count;
            //canvas.Children.Add(newEllipse);


            //// Restrict the tail of the snake
            //if (count > 100)
            //{
            //    canvas.Children.RemoveAt(count - 100 + 9);
            //}

            //foreach (Koordynaty pozycja in wonsz) // cos takiego
            //{
            //    //Console.SetCursorPosition((int)pozycja.col, (int)pozycja.row);
            //    //Console.ForegroundColor = ConsoleColor.DarkGray;
            //    //Console.Write("█");
            //}
            ////rysowanie wensza
            ////throw new NotImplementedException();
        }

        internal void game_over(int punkty,bool muzik)
        {
            
            GameOver gameover = new GameOver(punkty, muzik);
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
            //oThread.Suspend();
            MessageBoxResult result1 = MessageBox.Show("Gra jest wstrzymana, czy chesz kontynuować?", "PAUZA", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result1 == MessageBoxResult.No)
            {
                //odpal główne menu
                //oThread.Abort();
                Switcher.Switch(new MainMenu(muzik,false));
            }
            else
            {
               // oThread.Resume();
                return;
            }

    

        }
        internal void zmien_kierunek_glowy(Koordynaty nowaGlowa, int kierunek_poruszania)
        {
            // tylko jesli glowa bedzie jakims krztaletem
            //throw new NotImplementedException();
        }

        internal void wyswietl_wynik(int v)
        {
            scoreshow.Content = v.ToString();
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
            panel.Focus();

        }

        private void UserControl_KeyUp(object sender, KeyEventArgs e)
        {
            klucz = e.Key;
        }

        private void Right_Click(object sender, RoutedEventArgs e)
        {

        }

        private void upbutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lefybutton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void downbutton_Click(object sender, RoutedEventArgs e)
        {

        }

        public Key klawisz_mi_daj()
        {
            return klucz;
        }
        // wyświetlanie
    }
}
