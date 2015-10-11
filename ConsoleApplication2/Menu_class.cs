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

        private void reset_menu()
        {
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
        public void highlight_menu(int position)
        {
            switch (position)
            {
                case 1:
                    reset_menu();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(0, 5);
                    Console.Write(start);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 2:
                    reset_menu();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(0, 20);
                    Console.Write(music_OFF);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 3:
                    reset_menu();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(0, 30);
                    Console.Write(scoreboard);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 4:
                    reset_menu();
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
        private void start_screen()
    { 
        String snaaake =
"                             SSSSSSSSSSSSSSS       NNNNNNNN        NNNNNNNN                     AAA                     KKKKKKKKK    KKKKKKK      EEEEEEEEEEEEEEEEEEEEEE\n "+
"                           SS:::::::::::::::S     N:::::::N       N::::::N                    A:::A                    K:::::::K    K:::::K      E::::::::::::::::::::E\n "+
"                          S:::::SSSSSS::::::S     N::::::::N      N::::::N                   A:::::A                   K:::::::K    K:::::K      E::::::::::::::::::::E\n "+
"                          S:::::S     SSSSSSS     N:::::::::N     N::::::N                  A:::::::A                  K:::::::K   K::::::K      EE::::::EEEEEEEEE::::E\n "+
"                          S:::::S                 N::::::::::N    N::::::N                 A:::::::::A                 KK::::::K  K:::::KKK        E:::::E       EEEEEE \n"+
"                          S:::::S                  N:::::::::::N   N::::::N                A:::::A:::::A                  K:::::K K:::::K           E:::::E              \n"+
"                           S::::SSSS               N:::::::N::::N  N::::::N               A:::::A A:::::A                 K::::::K:::::K            E::::::EEEEEEEEEE    \n"+
"                            SS::::::SSSSS          N::::::N N::::N N::::::N              A:::::A   A:::::A                K:::::::::::K             E:::::::::::::::E    \n"+
"                              SSS::::::::SS        N::::::N  N::::N:::::::N             A:::::A     A:::::A               K:::::::::::K             E:::::::::::::::E    \n"+
"                                 SSSSSS::::S       N::::::N   N:::::::::::N            A:::::AAAAAAAAA:::::A              K::::::K:::::K            E::::::EEEEEEEEEE    \n"+
"                                      S:::::S      N::::::N    N::::::::::N           A:::::::::::::::::::::A             K:::::K K:::::K           E:::::E              \n"+
"                                      S:::::S      N::::::N     N:::::::::N          A:::::AAAAAAAAAAAAA:::::A          KK::::::K  K:::::KKK        E:::::E       EEEEEE \n"+
"                          SSSSSSS     S:::::S      N::::::N      N::::::::N         A:::::A             A:::::A         K:::::::K   K::::::K      EE::::::EEEEEEEE:::::E \n"+
"                          S::::::SSSSSS:::::S      N::::::N       N:::::::N        A:::::A               A:::::A        K:::::::K    K:::::K      E::::::::::::::::::::E \n"+
"                          S:::::::::::::::SS       N::::::N        N::::::N       A:::::A                 A:::::A       K:::::::K    K:::::K      E::::::::::::::::::::E \n"+
"                           SSSSSSSSSSSSSSS         NNNNNNNN         NNNNNNN      AAAAAAA                   AAAAAAA      KKKKKKKKK    KKKKKKK      EEEEEEEEEEEEEEEEEEEEEE \n";

 
String any_key =        
"                                       _____                                        _                _                          _   _                    \n"+
"                                      | ___ \\                                      | |              | |                        | | (_)                  \n"+
"                                      | |_/ / __ ___  ___ ___    __ _ _ __  _   _  | | _____ _   _  | |_ ___     ___ ___  _ __ | |_ _ _ __  _   _  ___  \n"+
"                                      |  __/ '__/ _ \\/ __/ __|  / _` | '_ \\| | | | | |/ / _ \\ | | | | __/ _ \\   / __/ _ \\| '_ \\| __| | '_ \\| | | |/ _ \\ \n"+
"                                      | |  | | |  __/\\__ \\__ \\ | (_| | | | | |_| | |   <  __/ |_| | | || (_) | | (_| (_) | | | | |_| | | | | |_| |  __/ \n"+
"                                      \\_|  |_|  \\___||___/___/  \\__,_|_| |_|\\__, | |_|\\_\\___|\\__, |  \\__\\___/   \\___\\___/|_| |_|\\__|_|_| |_|\\__,_|\\___| \n"+
"                                                                             __/ |            __/ |                                                     \n"+
"                                                                            |___/            |___/                                                      \n";
    while (! Console.KeyAvailable) {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(0, 10);
        Console.Write(snaaake);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(0, 45);
        Console.Write(any_key);
        System.Threading.Thread.Sleep(1000);
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.SetCursorPosition(0, 10);
        Console.Write(snaaake);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(0, 45);
        System.Threading.Thread.Sleep(700);
        Console.Clear();
   }
    reset_menu();
    Console.ReadKey();
    highlight_menu(1);
    Console.ReadKey();
    highlight_menu(2);
    Console.ReadKey();
    highlight_menu(3);
    Console.ReadKey();
    highlight_menu(4);
    Console.ReadKey();
        
    }
    }
}







