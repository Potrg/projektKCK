using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConsoleApplication2
{
    class Menu_class
    {
        public bool muzik;// Kontolka do napisów a także do wyłączania muzyki 
        public Menu_class(bool muzik)
        {
            this.muzik = muzik;
        }
        int menu_state = 0;
        const String start =
"                                                                              $$$$$$\\ $$$$$$$$\\  $$$$$$\\  $$$$$$$\\ $$$$$$$$\\    \n" +
"                                                                             $$  __$$\\ __$$  __|$$  __$$\\ $$  __$$\\__$$  __|      \n" +
"                                                                             $$ /  \\__|  $$ |   $$ /  $$ |$$ |  $$ |  $$ |          \n" +
"                                                                             \\$$$$$$\\    $$ |   $$$$$$$$ |$$$$$$$  |  $$ |          \n" +
"                                                                              \\____$$\\   $$ |   $$  __$$ |$$  __$$|   $$ |      \n" +
"                                                                             $$\\   $$ |  $$ |   $$ |  $$ |$$ |  $$ |  $$ |      \n" +
"                                                                             \\$$$$$$  |  $$ |   $$ |  $$ |$$ |  $$ |  $$ |      \n" +
"                                                                              \\______/   \\__|   \\__|  \\__|\\__|  \\__|  \\__|      \n";

        const String scoreboard =
"                                                   /$$$$$$   /$$$$$$   /$$$$$$  /$$$$$$$  /$$$$$$$$ /$$$$$$$   /$$$$$$   /$$$$$$  /$$$$$$$  /$$$$$$$   \n" +
"                                                  /$$__  $$ /$$__  $$ /$$__  $$| $$__  $$| $$_____/| $$__  $$ /$$__  $$ /$$__  $$| $$__  $$| $$__  $$      \n" +
"                                                 | $$  \\__/| $$  \\__/| $$  \\ $$| $$  \\ $$| $$      | $$  \\ $$| $$  \\ $$| $$  \\ $$| $$  \\ $$| $$  \\ $$      \n" +
"                                                 |  $$$$$$ | $$      | $$  | $$| $$$$$$$/| $$$$$   | $$$$$$$ | $$  | $$| $$$$$$$$| $$$$$$$/| $$  | $$    \n" +
"                                                  \\____  $$| $$      | $$  | $$| $$__  $$| $$__/   | $$__  $$| $$  | $$| $$__  $$| $$__  $$| $$  | $$           \n" +
"                                                  /$$  \\ $$| $$    $$| $$  | $$| $$  \\ $$| $$      | $$  \\ $$| $$  | $$| $$  | $$| $$  \\ $$| $$  | $$       \n" +
"                                                 |  $$$$$$/|  $$$$$$/|  $$$$$$/| $$  | $$| $$$$$$$$| $$$$$$$/|  $$$$$$/| $$  | $$| $$  | $$| $$$$$$$/          \n" +
"                                                  \\______/  \\______/  \\______/ |__/  |__/|________/|_______/  \\______/ |__/  |__/|__/  |__/|_______/         \n";
        const String exit =
"                                                         $$$$$$$\\  $$\\   $$\\ $$$$$$\\ $$$$$$$$\\        $$$$$$\\   $$$$$$\\  $$\\      $$\\ $$$$$$$$\\       \n" +
"                                                         $$  __$$\\ $$ |  $$ |\\_$$  _|\\__$$  __|      $$  __$$\\ $$  __$$\\ $$$\\    $$$ |$$  _____|      \n" +
"                                                         $$ /  $$ |$$ |  $$ |  $$ |     $$ |         $$ /  \\__|$$ /  $$ |$$$$\\  $$$$ |$$ |            \n" +
"                                                         $$ |  $$ |$$ |  $$ |  $$ |     $$ |         $$ |$$$$\\ $$$$$$$$ |$$\\$$\\$$ $$ |$$$$$\\          \n" +
"                                                         $$ |  $$ |$$ |  $$ |  $$ |     $$ |         $$ |\\_$$ |$$  __$$ |$$ \\$$$  $$ |$$  __|         \n" +
"                                                         $$ $$\\$$ |$$ |  $$ |  $$ |     $$ |         $$ |  $$ |$$ |  $$ |$$ |\\$  /$$ |$$ |            \n" +
"                                                         \\$$$$$$ / \\$$$$$$  |$$$$$$\\    $$ |         \\$$$$$$  |$$ |  $$ |$$ | \\_/ $$ |$$$$$$$$\\       \n" +
"                                                          \\___$$$\\  \\______/ \\______|   \\__|          \\______/ \\__|  \\__|\\__|     \\__|\\________|      \n" +
"                                                              \\___|                                                                                   \n";
        const String music_ON =
"                                                         $$\\      $$\\ $$\\   $$\\  $$$$$$\\  $$$$$$\\  $$$$$$\\         $$$$$$\\  $$\\   $$\\        \n" +
"                                                         $$$\\    $$$ |$$ |  $$ |$$  __$$\\ \\_$$  _|$$  __$$\\       $$  __$$\\ $$$\\  $$ |       \n" +
"                                                         $$$$\\  $$$$ |$$ |  $$ |$$ /  \\__|  $$ |  $$ /  \\__|      $$ /  $$ |$$$$\\ $$ |      \n" +
"                                                         $$\\$$\\$$ $$ |$$ |  $$ |\\$$$$$$\\    $$ |  $$ |            $$ |  $$ |$$ $$\\$$ |      \n" +
"                                                         $$ \\$$$  $$ |$$ |  $$ | \\____$$\\   $$ |  $$ |            $$ |  $$ |$$ \\$$$$ |       \n" +
"                                                         $$ |\\$  /$$ |$$ |  $$ |$$\\   $$ |  $$ |  $$ |  $$\\       $$ |  $$ |$$ |\\$$$ |       \n" +
"                                                         $$ | \\_/ $$ |\\$$$$$$  |\\$$$$$$  |$$$$$$\\ \\$$$$$$  |       $$$$$$  |$$ | \\$$ |       \n" +
"                                                         \\__|     \\__| \\______/  \\______/ \\______| \\______/        \\______/ \\__|  \\__|        \n";
        const String music_OFF =
"                                                         $$\\      $$\\ $$\\   $$\\  $$$$$$\\  $$$$$$\\  $$$$$$\\         $$$$$$\\  $$$$$$$$\\ $$$$$$$$\\     \n" +
"                                                         $$$\\    $$$ |$$ |  $$ |$$  __$$\\ \\_$$  _|$$  __$$\\       $$  __$$\\ $$  _____|$$  _____| \n" +
"                                                         $$$$\\  $$$$ |$$ |  $$ |$$ /  \\__|  $$ |  $$ /  \\__|      $$ /  $$ |$$ |      $$ |         \n" +
"                                                         $$\\$$\\$$ $$ |$$ |  $$ |\\$$$$$$\\    $$ |  $$ |            $$ |  $$ |$$$$$\\    $$$$$\\         \n" +
"                                                         $$ \\$$$  $$ |$$ |  $$ | \\____$$\\   $$ |  $$ |            $$ |  $$ |$$  __|   $$  __|      \n" +
"                                                         $$ |\\$  /$$ |$$ |  $$ |$$\\   $$ |  $$ |  $$ |  $$\\       $$ |  $$ |$$ |      $$ |         \n" +
"                                                         $$ | \\_/ $$ |\\$$$$$$  |\\$$$$$$  |$$$$$$\\ \\$$$$$$  |       $$$$$$  |$$ |      $$ |          \n" +
"                                                         \\__|     \\__| \\______/  \\______/ \\______| \\______/        \\______/ \\__|      \\__|            \n";

        public void reset_menu(bool muzik)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 5);
            Console.Write(start);
            ClearCurrentConsoleLine(20);
            Console.SetCursorPosition(0, 20);
            if (muzik == true)
            {
                Console.Write(music_ON);
            }
            else
                Console.Write(music_OFF);

            Console.SetCursorPosition(0, 30);
            Console.Write(scoreboard);
            Console.SetCursorPosition(0, 40);
            Console.Write(exit);
        }
        public void highlight_menu(int position,bool muzik)
        {
            switch (position)
            {
                case 0:
                    reset_menu(muzik);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(0, 5);
                    Console.Write(start);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 1:
                    reset_menu(muzik);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(0, 20);
                    ClearCurrentConsoleLine(20);
                    Console.SetCursorPosition(0, 20);
                    if (muzik==true)
                    {
                        Console.Write(music_ON);
                    }
                    else if (muzik == false)
                        Console.Write(music_OFF);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 2:
                    reset_menu(muzik);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(0, 30);
                    Console.Write(scoreboard);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 3:
                    reset_menu(muzik);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(0, 40);
                    Console.Write(exit);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

            }
        }

    public void show_menu()
        {
            start_screen();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 5);
            Console.Write(start);
            Console.SetCursorPosition(0, 20);
            Console.Write(music_OFF);
            Console.SetCursorPosition(0, 30);
            Console.Write(scoreboard);
            Console.SetCursorPosition(0, 40);
            Console.Write(exit);
        }
    private void colorfull_snake()
    {
        String snake =
"                    WWWWWWWW                           WWWWWWWW\n" +
"                    W::::::W                           W::::::W\n" +
"                    W::::::W                           W::::::W\n" +
"                    W::::::W                           W::::::W\n" +
"                     W:::::W           WWWWW           W:::::W \n" +
"                      W:::::W         W:::::W         W:::::W  \n" +
"                       W:::::W       W:::::::W       W:::::W   \n" +
"                        W:::::W     W:::::::::W     W:::::W    \n" +
"                         W:::::W   W:::::W:::::W   W:::::W     \n" +
"                          W:::::W W:::::W W:::::W W:::::W      \n" +
"                           W:::::W:::::W   W:::::W:::::W       \n" +
"                            W:::::::::W     W:::::::::W        \n" +
"                             W:::::::W       W:::::::W         \n" +
"                              W:::::W         W:::::W          \n" +
"                               W:::W           W:::W           \n" +
"                                WWW             WWW            \n";
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(0, 9);
        Console.Write(snake);
        Console.SetCursorPosition(69, 9);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("     OOOOOOOOO     "); Console.SetCursorPosition(69, 10);
        Console.Write("   OO:::::::::OO   "); Console.SetCursorPosition(69, 11);
        Console.Write(" OO:::::::::::::OO "); Console.SetCursorPosition(69, 12);
        Console.Write("O:::::::OOO:::::::O"); Console.SetCursorPosition(69, 13);
        Console.Write("O::::::O   O::::::O"); Console.SetCursorPosition(69, 14);
        Console.Write("O:::::O     O:::::O"); Console.SetCursorPosition(69, 15);
        Console.Write("O:::::O     O:::::O"); Console.SetCursorPosition(69, 16);
        Console.Write("O:::::O     O:::::O"); Console.SetCursorPosition(69, 17);
        Console.Write("O:::::O     O:::::O"); Console.SetCursorPosition(69, 18);
        Console.Write("O:::::O     O:::::O"); Console.SetCursorPosition(69, 19);
        Console.Write("O:::::O     O:::::O"); Console.SetCursorPosition(69, 20);
        Console.Write("O::::::O   O::::::O"); Console.SetCursorPosition(69, 21);
        Console.Write("O:::::::OOO:::::::O"); Console.SetCursorPosition(69, 22);
        Console.Write(" OO:::::::::::::OO "); Console.SetCursorPosition(69, 23);
        Console.Write("   OO:::::::::OO   "); Console.SetCursorPosition(69, 24);
        Console.Write("     OOOOOOOOO     "); Console.SetCursorPosition(69, 25);
         Console.ForegroundColor = ConsoleColor.DarkGreen;
         Console.SetCursorPosition(95, 9);
         Console.Write("NNNNNNNN        NNNNNNNN"); Console.SetCursorPosition(95, 10);
         Console.Write("N:::::::N       N::::::N"); Console.SetCursorPosition(95, 11);
         Console.Write("N::::::::N      N::::::N"); Console.SetCursorPosition(95, 12);
         Console.Write("N:::::::::N     N::::::N"); Console.SetCursorPosition(95, 13);
         Console.Write("N::::::::::N    N::::::N"); Console.SetCursorPosition(95, 14);
         Console.Write("N:::::::::::N   N::::::N"); Console.SetCursorPosition(95, 15);
         Console.Write("N:::::::N::::N  N::::::N"); Console.SetCursorPosition(95, 16);
         Console.Write("N::::::N N::::N N::::::N"); Console.SetCursorPosition(95, 17);
         Console.Write("N::::::N  N::::N:::::::N"); Console.SetCursorPosition(95, 18);
         Console.Write("N::::::N   N:::::::::::N"); Console.SetCursorPosition(95, 19);
         Console.Write("N::::::N    N::::::::::N"); Console.SetCursorPosition(95, 20);
         Console.Write("N::::::N     N:::::::::N"); Console.SetCursorPosition(95, 21);
         Console.Write("N::::::N      N::::::::N"); Console.SetCursorPosition(95, 22);
         Console.Write("N::::::N       N:::::::N"); Console.SetCursorPosition(95, 23);
         Console.Write("N::::::N        N::::::N"); Console.SetCursorPosition(95, 24);
         Console.Write("NNNNNNNN         NNNNNNN"); Console.SetCursorPosition(95, 25);
        Console.SetCursorPosition(125, 9);
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.Write("   SSSSSSSSSSSSSSS "); Console.SetCursorPosition(125, 10);
        Console.Write(" SS:::::::::::::::S"); Console.SetCursorPosition(125, 11);
        Console.Write("S:::::SSSSSS::::::S"); Console.SetCursorPosition(125, 12);
        Console.Write("S:::::S     SSSSSSS"); Console.SetCursorPosition(125, 13);
        Console.Write("S:::::S            "); Console.SetCursorPosition(125, 14);
        Console.Write("S:::::S            "); Console.SetCursorPosition(125, 15);
        Console.Write(" S::::SSSS         "); Console.SetCursorPosition(125, 16);
        Console.Write("  SS::::::SSSSS    "); Console.SetCursorPosition(125, 17);
        Console.Write("    SSS::::::::SS  "); Console.SetCursorPosition(125, 18);
        Console.Write("       SSSSSS::::S "); Console.SetCursorPosition(125, 19);
        Console.Write("            S:::::S"); Console.SetCursorPosition(125, 20);
        Console.Write("            S:::::S"); Console.SetCursorPosition(125, 21);
        Console.Write("SSSSSSS     S:::::S"); Console.SetCursorPosition(125, 22);
        Console.Write("S::::::SSSSSS:::::S"); Console.SetCursorPosition(125, 23);
        Console.Write("S:::::::::::::::SS "); Console.SetCursorPosition(125, 24);
        Console.Write(" SSSSSSSSSSSSSSS   "); Console.SetCursorPosition(125, 25);
         Console.SetCursorPosition(151, 9);
         Console.ForegroundColor = ConsoleColor.DarkYellow;
         Console.Write("ZZZZZZZZZZZZZZZZZZZ");Console.SetCursorPosition(151, 10);
         Console.Write("Z:::::::::::::::::Z");Console.SetCursorPosition(151, 11);
         Console.Write("Z:::::::::::::::::Z");Console.SetCursorPosition(151, 12);
         Console.Write("Z:::ZZZZZZZZ:::::Z ");Console.SetCursorPosition(151, 13);
         Console.Write("ZZZZZ     Z:::::Z  ");Console.SetCursorPosition(151, 14);
         Console.Write("        Z:::::Z    ");Console.SetCursorPosition(151, 15);
         Console.Write("       Z:::::Z     ");Console.SetCursorPosition(151, 16);
         Console.Write("      Z:::::Z      ");Console.SetCursorPosition(151, 17);
         Console.Write("     Z:::::Z       ");Console.SetCursorPosition(151, 18);
         Console.Write("    Z:::::Z        ");Console.SetCursorPosition(151, 19);
         Console.Write("   Z:::::Z         ");Console.SetCursorPosition(151, 20);
         Console.Write("ZZZ:::::Z     ZZZZZ");Console.SetCursorPosition(151, 21);
         Console.Write("Z::::::ZZZZZZZZ:::Z");Console.SetCursorPosition(151, 22);
         Console.Write("Z:::::::::::::::::Z");Console.SetCursorPosition(151, 23);
         Console.Write("Z:::::::::::::::::Z");Console.SetCursorPosition(151, 24);
         Console.Write("ZZZZZZZZZZZZZZZZZZZ");Console.SetCursorPosition(151, 25);
    }
        private void start_screen()
    {

flash tekstmigotajacy = new flash();
Thread oThread = new Thread(new ThreadStart(tekstmigotajacy.start_screen));
colorfull_snake();
oThread.Start();
while (!oThread.IsAlive) ;

    while (! Console.KeyAvailable) {}Console.ReadKey(false);
    oThread.Abort();
    oThread.Join();
    Console.Clear();
    reset_menu(true);
    highlight_menu(0,true);
    menu_conroler();
    
        
    }
        public static void ClearCurrentConsoleLine(int currentLineCursor)
        {
            for (int i = currentLineCursor; i < currentLineCursor+8; i++)
			{
			 Console.SetCursorPosition(0, i);
             Console.Write(new string(' ', Console.WindowWidth+50));
			}
            
        }
        public void menu_conroler()
        {
            Snake snake = new Snake();
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.wczytaj();
            while (true)
            {
                ConsoleKeyInfo kb;
                    kb = Console.ReadKey(false);
                    switch (kb.Key)
                    { //react to input
                        case ConsoleKey.UpArrow:
                            switch (menu_state)
                            {
                                case 0:
                                    highlight_menu(3,muzik);
                                    menu_state = ((4 + menu_state - 1) % 4);
                                    break;
                                case 1:
                                    highlight_menu(0, muzik);
                                    menu_state = ((4 + menu_state - 1) % 4);
                                    break;
                                case 2:
                                    highlight_menu(1, muzik);
                                    menu_state = ((4 + menu_state - 1) % 4);
                                    break;
                                case 3:
                                    highlight_menu(2, muzik);
                                    menu_state = ((4 + menu_state - 1) % 4);
                                    break;
                            }
                            break;

                        case ConsoleKey.DownArrow:

                            switch (menu_state)
                            {
                                case 0:
                                    highlight_menu(1, muzik);
                                    menu_state = ((menu_state + 1) % 4);
                                    break;
                                case 1:
                                    highlight_menu(2, muzik);
                                    menu_state = ((menu_state + 1) % 4);
                                    break;
                                case 2:
                                    highlight_menu(3, muzik);
                                    menu_state = ((menu_state + 1) % 4);
                                    break;
                                case 3:
                                    highlight_menu(0, muzik);
                                    menu_state = ((menu_state + 1) % 4);
                                    break;
                            }
                            break;
                        case ConsoleKey.Enter:
                            switch (menu_state)
                            {
                                case 0:
                                    GameViewer view = new GameViewer();
                                    Console.Clear();
                                    view.wyswietl_wynik(0987651234);
                                    snake.muzik = this.muzik;
                                    snake.Snake_Init();
                                    //view.wyswietl_wynik(35489);
                                    Console.ReadKey(false);
                                    break;
                                case 1:
                                    if ((kb.Key == ConsoleKey.Enter) && (muzik == false))
                                    {
                                        muzik = true;// wlacz wlacz dzwieki + zmiana stanu DODAC FUNKCJE WYLACZENIA DZWIEKOW
                                        Console.Clear();
                                        highlight_menu(1, muzik);
                                        
                                    }
                                    else if ((kb.Key == ConsoleKey.Enter) && (muzik == true))
                                    {
                                        muzik = false;// wylacz wlacz dzwieki + zmiana stanu
                                        ClearCurrentConsoleLine(20);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.SetCursorPosition(0, 20);
                                        Console.Write(music_OFF);
                                       
                                    }
                                    break;
                                case 2:
                                    scoreboard.muzik = this.muzik;
                                    scoreboard.wypisz();
                                    break;
                                case 3:
                                    Environment.Exit(0);
                                    break;
                            }

                            break;
                    }     
            }
        }
    }
}







