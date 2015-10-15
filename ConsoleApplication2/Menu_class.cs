using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ConsoleApplication2
{
    class Menu_class
    {
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

        private void reset_menu(bool muzik)
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
                    else
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
"                                 SSSSSSSSSSSSSSS \n" +
"                               SS:::::::::::::::S\n" +
"                              S:::::SSSSSS::::::S\n" +
"                              S:::::S     SSSSSSS\n" +
"                              S:::::S            \n" +
"                              S:::::S            \n" +
"                               S::::SSSS         \n" +
"                                SS::::::SSSSS    \n" +
"                                  SSS::::::::SS  \n" +
"                                     SSSSSS::::S \n" +
"                                          S:::::S\n" +
"                                          S:::::S\n" +
"                              SSSSSSS     S:::::S\n" +
"                              S::::::SSSSSS:::::S\n" +
"                              S:::::::::::::::SS \n" +
"                               SSSSSSSSSSSSSSS   \n";
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(0, 9);
        Console.Write(snake);
        Console.SetCursorPosition(54, 9);
        Console.ForegroundColor = ConsoleColor.DarkCyan;
         Console.Write("NNNNNNNN        NNNNNNNN");Console.SetCursorPosition(54, 10);
         Console.Write("N:::::::N       N::::::N");Console.SetCursorPosition(54, 11);
         Console.Write("N::::::::N      N::::::N");Console.SetCursorPosition(54, 12);
         Console.Write("N:::::::::N     N::::::N");Console.SetCursorPosition(54, 13);
         Console.Write("N::::::::::N    N::::::N");Console.SetCursorPosition(54, 14);
         Console.Write("N:::::::::::N   N::::::N");Console.SetCursorPosition(54, 15);
         Console.Write("N:::::::N::::N  N::::::N");Console.SetCursorPosition(54, 16);
         Console.Write("N::::::N N::::N N::::::N");Console.SetCursorPosition(54, 17);
         Console.Write("N::::::N  N::::N:::::::N");Console.SetCursorPosition(54, 18);
         Console.Write("N::::::N   N:::::::::::N");Console.SetCursorPosition(54, 19);
         Console.Write("N::::::N    N::::::::::N");Console.SetCursorPosition(54, 20);
         Console.Write("N::::::N     N:::::::::N");Console.SetCursorPosition(54, 21);
         Console.Write("N::::::N      N::::::::N");Console.SetCursorPosition(54, 22);
         Console.Write("N::::::N       N:::::::N");Console.SetCursorPosition(54, 23);
         Console.Write("N::::::N        N::::::N");Console.SetCursorPosition(54, 24);
         Console.Write("NNNNNNNN         NNNNNNN");Console.SetCursorPosition(54, 25);
         Console.ForegroundColor = ConsoleColor.DarkGreen;
         Console.SetCursorPosition(83, 9);
         Console.Write("               AAA               ");Console.SetCursorPosition(83, 10);
         Console.Write("              A:::A              ");Console.SetCursorPosition(83, 11);
         Console.Write("             A:::::A             ");Console.SetCursorPosition(83, 12);
         Console.Write("            A:::::::A            ");Console.SetCursorPosition(83, 13);
         Console.Write("           A:::::::::A           ");Console.SetCursorPosition(83, 14);
         Console.Write("          A:::::A:::::A          ");Console.SetCursorPosition(83, 15);
         Console.Write("         A:::::A A:::::A         ");Console.SetCursorPosition(83, 16);
         Console.Write("        A:::::A   A:::::A        ");Console.SetCursorPosition(83, 17);
         Console.Write("       A:::::A     A:::::A       ");Console.SetCursorPosition(83, 18);
         Console.Write("      A:::::AAAAAAAAA:::::A      ");Console.SetCursorPosition(83, 19);
         Console.Write("     A:::::::::::::::::::::A     ");Console.SetCursorPosition(83, 20);
         Console.Write("    A:::::AAAAAAAAAAAAA:::::A    ");Console.SetCursorPosition(83, 21);
         Console.Write("   A:::::A             A:::::A   ");Console.SetCursorPosition(83, 22);
         Console.Write("  A:::::A               A:::::A  ");Console.SetCursorPosition(83, 23);
         Console.Write(" A:::::A                 A:::::A ");Console.SetCursorPosition(83, 24);
         Console.Write("AAAAAAA                   AAAAAAA");Console.SetCursorPosition(83, 25);
        Console.SetCursorPosition(121, 9);
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
         Console.Write("KKKKKKKKK    KKKKKKK");Console.SetCursorPosition(121, 10);
         Console.Write("K:::::::K    K:::::K");Console.SetCursorPosition(121, 11);
         Console.Write("K:::::::K    K:::::K");Console.SetCursorPosition(121, 12);
         Console.Write("K:::::::K   K::::::K");Console.SetCursorPosition(121, 13);
         Console.Write("KK::::::K  K:::::KKK");Console.SetCursorPosition(121, 14);
         Console.Write("  K:::::K K:::::K   ");Console.SetCursorPosition(121, 15);
         Console.Write("  K::::::K:::::K    ");Console.SetCursorPosition(121, 16);
         Console.Write("  K:::::::::::K     ");Console.SetCursorPosition(121, 17);
         Console.Write("  K:::::::::::K     ");Console.SetCursorPosition(121, 18);
         Console.Write("  K::::::K:::::K    ");Console.SetCursorPosition(121, 19);
         Console.Write("  K:::::K K:::::K   ");Console.SetCursorPosition(121, 20);
         Console.Write("KK::::::K  K:::::KKK");Console.SetCursorPosition(121, 21);
         Console.Write("K:::::::K   K::::::K");Console.SetCursorPosition(121, 22);
         Console.Write("K:::::::K    K:::::K");Console.SetCursorPosition(121, 23);
         Console.Write("K:::::::K    K:::::K");Console.SetCursorPosition(121, 24);
         Console.Write("KKKKKKKKK    KKKKKKK");Console.SetCursorPosition(121, 25);
         Console.SetCursorPosition(149, 9);
         Console.ForegroundColor = ConsoleColor.DarkYellow;
         Console.Write("EEEEEEEEEEEEEEEEEEEEEE");Console.SetCursorPosition(149, 10);
         Console.Write("E::::::::::::::::::::E");Console.SetCursorPosition(149, 11);
         Console.Write("E::::::::::::::::::::E");Console.SetCursorPosition(149, 12);
         Console.Write("EE::::::EEEEEEEEE::::E");Console.SetCursorPosition(149, 13);
         Console.Write("  E:::::E       EEEEEE");Console.SetCursorPosition(149, 14);
         Console.Write("  E:::::E             ");Console.SetCursorPosition(149, 15);
         Console.Write("  E::::::EEEEEEEEEE   ");Console.SetCursorPosition(149, 16);
         Console.Write("  E:::::::::::::::E   ");Console.SetCursorPosition(149, 17);
         Console.Write("  E:::::::::::::::E   ");Console.SetCursorPosition(149, 18);
         Console.Write("  E::::::EEEEEEEEEE   ");Console.SetCursorPosition(149, 19);
         Console.Write("  E:::::E             ");Console.SetCursorPosition(149, 20);
         Console.Write("  E:::::E       EEEEEE");Console.SetCursorPosition(149, 21);
         Console.Write("EE::::::EEEEEEEE:::::E");Console.SetCursorPosition(149, 22);
         Console.Write("E::::::::::::::::::::E");Console.SetCursorPosition(149, 23);
         Console.Write("E::::::::::::::::::::E");Console.SetCursorPosition(149, 24);
         Console.Write("EEEEEEEEEEEEEEEEEEEEEE");Console.SetCursorPosition(149, 25);

    
    
    
    
    }
        private void start_screen()
    { 
       
String any_key =
"                                            _____                                        _                _                          _   _                    \n" +
"                                           | ___ \\                                      | |              | |                        | | (_)                  \n" +
"                                           | |_/ / __ ___  ___ ___    __ _ _ __  _   _  | | _____ _   _  | |_ ___     ___ ___  _ __ | |_ _ _ __  _   _  ___  \n" +
"                                           |  __/ '__/ _ \\/ __/ __|  / _` | '_ \\| | | | | |/ / _ \\ | | | | __/ _ \\   / __/ _ \\| '_ \\| __| | '_ \\| | | |/ _ \\ \n" +
"                                           | |  | | |  __/\\__ \\__ \\ | (_| | | | | |_| | |   <  __/ |_| | | || (_) | | (_| (_) | | | | |_| | | | | |_| |  __/ \n" +
"                                           \\_|  |_|  \\___||___/___/  \\__,_|_| |_|\\__, | |_|\\_\\___|\\__, |  \\__\\___/   \\___\\___/|_| |_|\\__|_|_| |_|\\__,_|\\___| \n" +
"                                                                                  __/ |            __/ |                                                     \n" +
"                                                                                 |___/            |___/                                                      \n";
    while (! Console.KeyAvailable) {
        colorfull_snake();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(0, 40);
        Console.Write(any_key);
        System.Threading.Thread.Sleep(1000);
        Console.Clear();
        colorfull_snake();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(0, 40);
        System.Threading.Thread.Sleep(700);
        Console.Clear();
   }
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
        private void menu_conroler()
        {
            bool muzik = true;// Kontolka do napisów a także do wyłączania muzyki 
            while (true)
            {
                ConsoleKeyInfo kb;
                //kb = Console.ReadKey(true); //read the keyboard
                do
                {
                    kb = Console.ReadKey(false); //read the keyboard
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
                                    view.wyswietl_wynik(0987651234);
                                    System.Threading.Thread.Sleep(1000);
                                    view.wyswietl_wynik(35489);
                                    Console.ReadKey();
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
                                    //odpal tablice wynikow
                                    break;
                                case 3:
                                    Environment.Exit(0);
                                    //wyłącz grę odpal napisy koncowe
                                    break;
                            }

                            break;
                    }
                } while (kb.Key != ConsoleKey.Enter);
                

                
            }
        }
    }
}







