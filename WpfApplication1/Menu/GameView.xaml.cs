using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfSnake.Menu
{
    /// <summary>
    /// Interaction logic for GameMenu.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        internal bool muzik;

        public GameView()
        {
            InitializeComponent();
        }
        public void sciany(List<Koordynaty> przeszkody)
        {
            //Wyswietla sciany - przeszkody
            throw new NotImplementedException();

        }

        public void jedzenie(Koordynaty pokarm, int typ)
        {
            //wyswietla jedzenie i jedzenie specjalne 0=normal(yellow) 1=red 2=green  3=blue   4=white;
            throw new NotImplementedException();
        }
        internal void weza(Queue<Koordynaty> wonsz)
        {
            foreach (Koordynaty pozycja in wonsz) // cos takiego
            {
                Console.SetCursorPosition((int)pozycja.col, (int)pozycja.row);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("█");
            }
            //rysowanie wensza
            throw new NotImplementedException();
        }

        internal void game_over(int punkty)
        {
            MessageBox.Show("You Lose! Your score is ", "Game Over", MessageBoxButton.OK, MessageBoxImage.Hand);
            //okienko game over, wprwaoadzanie wyniku
            throw new NotImplementedException();
        }

        internal void usun_stara_glowe(Koordynaty aktualnaGlowa)
        {
            //nadpisywanie glowy cialem
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        internal void wyswietl_wynik(int v)
        {
            //wyswietla wynik podczas gry
            throw new NotImplementedException();
        }

        internal void usun_pokarm_lub_ogon(Koordynaty pokarm_specjalny)
        {
            // usuwa calkowicie z powierzchni gry
            throw new NotImplementedException();
        }

        // wyświetlanie
    }
}
