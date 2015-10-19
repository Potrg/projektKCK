using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{

    class GameViewer
    {
        enum kierunek : byte 
        { 
            prawo = 0, 
            lewo = 1, 
            dol = 2, 
            gora = 3 
        };
        public bool muzik;
        private void rysuj_wynik(int liczba, int hOffset, int vOffset)
        {
            Console.SetCursorPosition(hOffset, vOffset++);
            switch (liczba)
            {
                case 1:
                    Console.Write(" ____ "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("/_   |"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write(" |   |"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write(" |   |"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write(" |___|"); Console.SetCursorPosition(hOffset, vOffset++);
                    break;
                case 2:
                    Console.Write("________  "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("\\_____  \\ "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write(" /  ____/ "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("/       \\ "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("\\_______ \\"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("        \\/"); Console.SetCursorPosition(hOffset, vOffset++);
                    break;
                case 3:
                    Console.Write("________  "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("\\_____  \\ "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("  _(__  < "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write(" /       \\"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("/______  /"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("       \\/ "); Console.SetCursorPosition(hOffset, vOffset++);
                    break;
                case 4:
                    Console.Write("   _____  "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("  /  |  | "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write(" /   |  |_"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("/    ^   /"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("\\____   | "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("     |__| "); Console.SetCursorPosition(hOffset, vOffset++);
                    break;
                case 5:
                    Console.Write("  ________"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write(" |   ____/"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write(" |____  \\ "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write(" /       \\"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("/______  /"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("       \\/ "); Console.SetCursorPosition(hOffset, vOffset++);
                    break;
                case 6:
                    Console.Write("  ________"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write(" /  _____/"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("/   __  \\ "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("\\  |__\\  \\"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write(" \\_____  /"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("       \\/ "); Console.SetCursorPosition(hOffset, vOffset++);
                    break;
                case 7:
                    Console.Write("_________ "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("\\______  \\"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("    /    /"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("   /    / "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("  /____/  "); Console.SetCursorPosition(hOffset, vOffset++);
                    break;
                case 8:
                    Console.Write("  ______  "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write(" /  __  \\ "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write(" >      < "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("/   --   \\"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("\\______  /"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("       \\/ "); Console.SetCursorPosition(hOffset, vOffset++);
                    break;
                case 9:
                    Console.Write(" ________ "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("/   __   \\"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("\\____    /"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("   /    / "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("  /____/  "); Console.SetCursorPosition(hOffset, vOffset++);
                    break;
                case 0:
                    Console.Write("_______   "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("\\   _  \\  "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("/  /_\\  \\ "); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("\\  \\_/   \\"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write(" \\_____  /"); Console.SetCursorPosition(hOffset, vOffset++);
                    Console.Write("       \\/ "); Console.SetCursorPosition(hOffset, vOffset++);
                    break;
            }
        }
        private static void Clear_line_of_numbers(int currentLineCursor, int elo) /// przystosowane do czyszczenia wyników
        {
            for (int i = currentLineCursor; i < currentLineCursor + elo; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', 200));
            }
        }
        public void wyswietl_wynik(int wynik)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Clear_line_of_numbers(0,6);
            int hOffset=200;
            int vOffset=0;

            string wynik_elo = Convert.ToString(wynik);
            // dodawanie kropki do wyniku - żeby ładnie wyglądało
            for (int i = wynik_elo.Length-1; i >= 0;i-- )
            {
                hOffset = hOffset - 11;
                Console.ForegroundColor = ConsoleColor.Black;
                
                switch (wynik_elo[i])
                {
                    case '0':
                        rysuj_wynik(0, hOffset, vOffset);
                        break;
                    case '1':
                        hOffset = hOffset + 4;
                        rysuj_wynik(1, hOffset, vOffset);
                        break;
                    case '2':
                        rysuj_wynik(2, hOffset, vOffset);
                        break;
                    case '3':
                        rysuj_wynik(3, hOffset, vOffset);
                        break;
                    case '4':
                        rysuj_wynik(4, hOffset, vOffset);
                        break;
                    case '5':
                        rysuj_wynik(5, hOffset, vOffset);
                        break;
                    case '6':
                        rysuj_wynik(6, hOffset, vOffset);
                        break;
                    case '7':
                        rysuj_wynik(7, hOffset, vOffset);
                        break;
                    case '8':
                        rysuj_wynik(8, hOffset, vOffset);
                        break;
                    case '9':
                        rysuj_wynik(9, hOffset, vOffset);
                        break;
                }
            }
            Console.ResetColor();
        }

        public void jedzenie(Koordynaty pokarmmm,int color)
        {
            Console.SetCursorPosition(pokarmmm.col, pokarmmm.row);
            if (color==0)Console.ForegroundColor = ConsoleColor.Yellow;
            if (color == 1) Console.ForegroundColor = ConsoleColor.Red;
            if (color == 2) Console.ForegroundColor = ConsoleColor.Green;
            if (color == 3) Console.ForegroundColor = ConsoleColor.Blue;
            if (color == 4) Console.ForegroundColor = ConsoleColor.White;

            Console.Write("@");
            Console.SetCursorPosition(pokarmmm.col, pokarmmm.row);
        }
        public void sciany(List<Koordynaty> przeszkody)
        {
            foreach (Koordynaty sciana in przeszkody)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(sciana.col, sciana.row);
                Console.Write("#");
            }
        }
        public void weza(Queue<Koordynaty> wonsz)
        {
            foreach (Koordynaty pozycja in wonsz)
            {
                Console.SetCursorPosition(pozycja.col, pozycja.row);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("█");
            }
        }

        public void usun_stara_glowe(Koordynaty snakeHead)
        {
            Console.SetCursorPosition(snakeHead.col, snakeHead.row);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("█");
        }

        public void zmien_kierunek_glowy(Koordynaty snakeNewHead, int kierunek_poruszania)
        {
            Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
            Console.ForegroundColor = ConsoleColor.Gray;
            if (kierunek_poruszania == (int)kierunek.prawo) Console.Write(">");
            if (kierunek_poruszania == (int)kierunek.lewo) Console.Write("<");
            if (kierunek_poruszania == (int)kierunek.gora) Console.Write("^");
            if (kierunek_poruszania == (int)kierunek.dol) Console.Write("v");
        }

        public void usun_pokarm_lub_ogon(Koordynaty pokarm)
        {
            Console.SetCursorPosition(pokarm.col, pokarm.row);
            Console.Write(" ");
        }

        public void game_over(int wynik)
    {
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        player.SoundLocation = "loose.wav";
        if (muzik == true)
        {
            player.PlayLooping();
        }
        Console.Clear();
        for (int i = 0, j= 0 ; i < 25; i++)
        {
            if (i >= j) Clear_line_of_numbers(i - j, 7); if (j<6) j++;
            if (i > 3) { Console.SetCursorPosition(75, i - 4); Console.Write("  ____                         ___                 "); }
            if (i > 2) { Console.SetCursorPosition(75, i - 3); Console.Write(" / ___| __ _ _ __ ___   ___   / _ \\__   _____ _ __ "); }
            if (i > 1) { Console.SetCursorPosition(75, i - 2); Console.Write("| |  _ / _` | '_ ` _ \\ / _ \\ | | | \\ \\ / / _ \\ '__|"); }
            if (i > 0) { Console.SetCursorPosition(75, i - 1); Console.Write("| |_| | (_| | | | | | |  __/ | |_| |\\ V /  __/ |   ");}
            if (i > -1) {Console.SetCursorPosition(75, i);    Console.Write(" \\____|\\__,_|_| |_| |_|\\___|  \\___/  \\_/ \\___|_|   ");}
            Thread.Sleep(60);                                                                                              
        }
        Console.ForegroundColor = ConsoleColor.DarkGray;
        int hoffset = 78;
        int voffset = 30;
        Console.SetCursorPosition(hoffset, voffset++);
        Console.WriteLine("╔══════════════════════════════════════════╗"); Console.SetCursorPosition(hoffset, voffset++);
        Console.WriteLine("╠─────────────Podaj swoje imię─────────────╣"); Console.SetCursorPosition(hoffset, voffset++);
        Console.WriteLine("╠══════════════════════════════════════════╣"); Console.SetCursorPosition(hoffset, voffset++);
        Console.WriteLine("║                                          ║"); Console.SetCursorPosition(hoffset, voffset++);
        Console.WriteLine("╠══════════════════════════════════════════╣"); Console.SetCursorPosition(hoffset, voffset++);
        Console.WriteLine("╠───────────────Twój wynik to──────────────╣"); Console.SetCursorPosition(hoffset, voffset++);
        Console.WriteLine("║                                          ║"); Console.SetCursorPosition(hoffset, voffset++);
        Console.WriteLine("╚══════════════════════════════════════════╝"); Console.SetCursorPosition(hoffset + 20, 36);
        Console.Write(wynik);
        Console.SetCursorPosition(hoffset+2, 33);
        Console.ForegroundColor = ConsoleColor.White;
        Console.CursorVisible=true;
        string name = Console.ReadLine();
        Console.CursorVisible = false;
        Scoreboard scoreboard = new Scoreboard();
        if (name != "")
        {
            Player winner = new Player();
            winner.name = name;
            winner.score = wynik;
            scoreboard.dodaj(winner);
        }
        Thread.Sleep(500);
        player.Stop();
        scoreboard.muzik = this.muzik;
        scoreboard.wypisz(true);
    }

    }


//dodać funkcje wyświetlające węża oraz jedzenie.
}
