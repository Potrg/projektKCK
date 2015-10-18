using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    struct Koordynaty// pozycje do kurde wszystkiego
    {
        public int row;
        public int col;
        public Koordynaty(int row, int col)
        {
            this.row = row;
            this.col = col;
        }
    }

    class Snake
    {
        enum kierunek : byte { prawo = 0, lewo = 1, dol = 2, gora = 3 };
        Queue<Koordynaty> snakeElements = new Queue<Koordynaty>();
        List<Koordynaty> przeszkody = new List<Koordynaty>();
        Random generator_liczb = new Random(); // random do losowania koordynat nowych smakołyków
        Koordynaty pokarm;
        public bool muzik = true;

        private void losuj_jedzenie()
        {
            //Koordynaty jedzenie;
            do
            {
                pokarm = new Koordynaty(generator_liczb.Next(8, Console.WindowHeight),
                    generator_liczb.Next(0, Console.WindowWidth));
            }
            while (snakeElements.Contains(pokarm) || przeszkody.Contains(pokarm));
            //return jedzenie;
        }

        public void pause()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 0);
            Console.Write("  PAUSE__CLICK_P_TO_CONTINUE_THE_GAME___||||___CLICK_Esc_TO_exit_THE_GAME___||||___PAUSE__CLICK_P_TO_CONTINUE_THE_GAME___||||___CLICK_Esc_TO_exit_THE_GAME___||||___PAUSE__CLICK_P_TO_CONTINUE_THE_GAME ");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo kl2 = Console.ReadKey(); // przerobić na switcha
                    if (kl2.Key == ConsoleKey.Escape)
                    {
                        Console.Clear();
                        Menu_class menu = new Menu_class(muzik);
                        menu.reset_menu(muzik);
                        menu.highlight_menu(0,muzik);
                        menu.menu_conroler();
                        //wejdz do głównego menu
                    }
                    if (kl2.Key == ConsoleKey.P)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.SetCursorPosition(0, 0);
                        Console.Write("########################################################################################################################################################################################################");
                        break;}}}}
        
        public void dodawanie_scian()
        {


            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Koordynaty temppos = new Koordynaty(0, i); przeszkody.Add(temppos);
                Koordynaty temppos2 = new Koordynaty(59, i); przeszkody.Add(temppos2);
            }

            for (int i = 0; i < Console.WindowHeight / 2; i++)
            {
                Koordynaty temppos = new Koordynaty(i, Console.WindowWidth - 1); przeszkody.Add(temppos);
                Koordynaty temppos2 = new Koordynaty(i, 0); przeszkody.Add(temppos2);
            }

        }

        public void narodziny_weza()
        {
            for (int i = 1; i <= 10; i++)
            {
                snakeElements.Enqueue(new Koordynaty(1, i));
            }
        }

        public void Snake_Init()
        {
            Console.CursorSize = 12;
            Console.BufferHeight = 60;
            Console.BufferWidth = 201;
            Console.SetWindowSize(200, 60);
            //Zmienne :o
            double sleepTime = 50;// jak długo wąż ma spać - decyduje o szybkości węża
            int kierunek_poruszania = (int)kierunek.prawo; // początkowy kierunek (by np wonsz nie wpadl na skałę)
            int licznik_karmienia_weza = 0;// odlicza czas od odtatniego karmienia
            int czas_usuniecia_jedzenia = 40000; // jak dłygo jedzenie pozostaje na planszy
            int punkty_ujemne = 0; // punkty ujemne za niezjedzone jesdzenie 
            licznik_karmienia_weza = Environment.TickCount;


            Koordynaty[] tablica_skretow = new Koordynaty[]
            {
                new Koordynaty(0, 1), // right
                new Koordynaty(0, -1), // left
                new Koordynaty(1, 0), // down
                new Koordynaty(-1, 0), // up
            };


            
            
            foreach (Koordynaty sciana in przeszkody)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(sciana.col, sciana.row);
                Console.Write("#");
            }

            narodziny_weza();
            losuj_jedzenie();
                    

            Console.SetCursorPosition(pokarm.col, pokarm.row);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("@");

            foreach (Koordynaty pozycja in snakeElements)
            {
                Console.SetCursorPosition(pozycja.col, pozycja.row);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("█");
            }


            while (true)
            {

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo kl = Console.ReadKey(false); // przerobić na switcha
                    switch (kl.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            if (kierunek_poruszania != (int)kierunek.prawo) kierunek_poruszania = (int)kierunek.lewo;
                            break;
                        case ConsoleKey.RightArrow:
                            if (kierunek_poruszania != (int)kierunek.lewo) kierunek_poruszania = (int)kierunek.prawo;
                            break;
                        case ConsoleKey.UpArrow:
                            if (kierunek_poruszania != (int)kierunek.dol) kierunek_poruszania = (int)kierunek.gora;
                            break;
                        case ConsoleKey.DownArrow:
                            if (kierunek_poruszania != (int)kierunek.gora) kierunek_poruszania = (int)kierunek.dol;
                            break;
                        case ConsoleKey.P:
                            pause();
                            break;
                    }

                }

                Koordynaty snakeHead = snakeElements.Last();
                Koordynaty nextDirection = tablica_skretow[kierunek_poruszania];

                Koordynaty snakeNewHead = new Koordynaty(snakeHead.row + nextDirection.row,
                    snakeHead.col + nextDirection.col);

                if (snakeNewHead.col < 0) snakeNewHead.col = Console.WindowWidth - 1;
                if (snakeNewHead.row < 0) snakeNewHead.row = Console.WindowHeight - 1;
                if (snakeNewHead.row >= Console.WindowHeight) snakeNewHead.row = 0;
                if (snakeNewHead.col >= Console.WindowWidth) snakeNewHead.col = 0;

                if (snakeElements.Contains(snakeNewHead) || przeszkody.Contains(snakeNewHead)) // Warunek kończoncy grę !
                {
                    //Console.SetCursorPosition(0, 0);
                    //Console.ForegroundColor = ConsoleColor.Red;  // wywołać gameogev();
                    //Console.WriteLine("Game over!");
                    int userPoints = (snakeElements.Count - 10) * 100 - punkty_ujemne;
                    if (userPoints < 0) userPoints = 0;
                    userPoints = Math.Max(userPoints, 0);
                    Console.WriteLine("Your points are: {0}", userPoints);
                    Thread.Sleep(2000);
                    Console.ReadKey(false);
                    return;
                }

                Console.SetCursorPosition(snakeHead.col, snakeHead.row);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("█");

                snakeElements.Enqueue(snakeNewHead);
                Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                Console.ForegroundColor = ConsoleColor.Gray;
                if (kierunek_poruszania == (int)kierunek.prawo) Console.Write(">");
                if (kierunek_poruszania == (int)kierunek.lewo) Console.Write("<");
                if (kierunek_poruszania == (int)kierunek.gora) Console.Write("^");
                if (kierunek_poruszania == (int)kierunek.dol) Console.Write("v");


                if (snakeNewHead.col == pokarm.col && snakeNewHead.row == pokarm.row)
                {
                    // feeding the snake
                    losuj_jedzenie();
                    licznik_karmienia_weza = Environment.TickCount;

                    Console.SetCursorPosition(pokarm.col, pokarm.row);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("@");
                }
                else
                {
                    // moving...
                    Koordynaty last = snakeElements.Dequeue();
                    Console.SetCursorPosition(last.col, last.row);
                    Console.Write(' ');
                }

                if (Environment.TickCount - licznik_karmienia_weza >= czas_usuniecia_jedzenia)
                {
                    punkty_ujemne = punkty_ujemne + 50;
                    Console.SetCursorPosition(pokarm.col, pokarm.row);
                    Console.Write(' ');
                    losuj_jedzenie();

                    licznik_karmienia_weza = Environment.TickCount;
                }

                Console.SetCursorPosition(pokarm.col, pokarm.row);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("@");

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }
    }
}
