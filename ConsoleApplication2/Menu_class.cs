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
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        public bool muzik;// Kontolka do napisów a także do wyłączania muzyki 
        public Menu_class(bool muzik)
        {
            this.muzik = muzik;
        }
        int menu_state = 0;
        int lvl_state=0;
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
        String lvl1 =
"  ____   " +
" |    |  " +
"  |   |  " +
"  |   |  " +
"  |   |  " +
"  |   |  " +
"  |___|  ";
String lvl2 =
" _______ " +
"|       |" +
"|____   |" +
" ____|  |" +
"| ______|" +
"| |_____ " +
"|_______|";

String lvl3 =

" _______ " +
"|       |" +
"|___    |" +
" ___|   |" +
"|___    |" +
" ___|   |" +
"|_______|";

String LVL =
"                                                                       ___      _______  __   __  _______  ___     \n" +
"                                                                      |   |    |       ||  | |  ||       ||   |    \n" +
"                                                                      |   |    |    ___||  |_|  ||    ___||   |    \n" +
"                                                                      |   |    |   |___ |       ||   |___ |   |    \n" +
"                                                                      |   |___ |    ___||       ||    ___||   |___ \n" +
"                                                                      |       ||   |___  |     | |   |___ |       |\n" +
"                                                                      |_______||_______|  |___|  |_______||_______|\n";
        String walls =                                            
"                                                                       _     _  _______  ___      ___      _______ \n" +
"                                                                      | | _ | ||   _   ||   |    |   |    |       |\n" +
"                                                                      | || || ||  |_|  ||   |    |   |    |  _____|\n" +
"                                                                      |       ||       ||   |    |   |    | |_____ \n" +
"                                                                      |       ||       ||   |___ |   |___ |_____  |\n" +
"                                                                      |   _   ||   _   ||       ||       | _____| |\n" +
"                                                                      |__| |__||__| |__||_______||_______||_______|\n";
                                                                       
String start2 =
"                                                                           _______  _______  _______  ______   _______ \n" +
"                                                                          |       ||       ||   _   ||    _ | |       |\n" +
"                                                                          |  _____||_     _||  |_|  ||   | || |_     _|\n" +
"                                                                          | |_____   |   |  |       ||   |_||_  |   |  \n" +
"                                                                          |_____  |  |   |  |       ||    __  | |   |  \n" +
"                                                                           _____| |  |   |  |   _   ||   |  | | |   |  \n" +
"                                                                          |_______|  |___|  |__| |__||___|  |_| |___|  \n";
                                                  
        
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
        player.SoundLocation = "1.wav";
        player.Play();
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
    menu_conroler(false);
    
        
    }
        public void restart_LVL(int lvl, int speed)
        {
            //Console.Clear();
            Console.BufferHeight = 60;
            Console.BufferWidth = 200;
            Console.SetWindowSize(200, 60);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 15);
            Console.Write(start2);
            Console.SetCursorPosition(0, 25);
            Console.WriteLine(walls);
            
            int pom = 0;
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    Console.SetCursorPosition(120 + i, 25 + j);
                    if (lvl==0)Console.WriteLine(lvl1[pom]);
                    if (lvl == 1) Console.WriteLine(lvl2[pom]);
                    if (lvl == 2) Console.WriteLine(lvl3[pom]);                 
                    pom++;
                }
            }
            Console.SetCursorPosition(0, 35);
            Console.WriteLine(LVL);

            pom = 0;
            for (int j = 0; j < 7; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    Console.SetCursorPosition(120 + i, 35 + j);   
                    if (speed == 100) Console.WriteLine(lvl1[pom]);
                    if (speed == 80) Console.WriteLine(lvl2[pom]);
                    if (speed == 60) Console.WriteLine(lvl3[pom]);
                    pom++;
                }
            }
            pom = 0;
            Console.SetCursorPosition(0, 45);
        }
        public void highlight_LVL(int position, int lvl, int speed)
        {
            Console.SetCursorPosition(0, 0);//zmiana
            switch (position)
            {
                case 0:
                    restart_LVL(lvl, speed);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(0, 15);//zmiana
                    Console.Write(start2);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 1:
                    restart_LVL(lvl, speed);
                    Console.ForegroundColor = ConsoleColor.Red;                   
                    Clearlvl(25);
                    Console.SetCursorPosition(0, 25);
                    Console.WriteLine(walls);
                    int pom = 0;

                    for (int j = 0; j < 7; j++)
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            Console.SetCursorPosition(120 + i, 25 + j);
                            if (lvl == 0) Console.WriteLine(lvl1[pom]);
                            if (lvl == 1) Console.WriteLine(lvl2[pom]);
                            if (lvl == 2) Console.WriteLine(lvl3[pom]);
                            pom++;
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 2:
                    restart_LVL(lvl, speed);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(0, 35);
                    Console.WriteLine(LVL);
                    
                    pom = 0;
                    for (int j = 0; j < 7; j++)
                    {
                        for (int i = 0; i < 9; i++)
                        {
                            Console.SetCursorPosition(120 + i, 35 + j);
                            if (speed == 100) Console.WriteLine(lvl1[pom]);
                            if (speed == 80) Console.WriteLine(lvl2[pom]);
                            if (speed == 60) Console.WriteLine(lvl3[pom]);
                            pom++;
                        }
                    }
                    pom = 0;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                    
            }
        }
        public static void Clearlvl(int currentLineCursor)
        {
            for (int i = currentLineCursor; i < currentLineCursor + 8; i++)
            {
                Console.SetCursorPosition(120, i);
                Console.Write(new string(' ', 9));
            }

        }
        public static void ClearCurrentConsoleLine(int currentLineCursor)
        {
            for (int i = currentLineCursor; i < currentLineCursor+8; i++)
			{
			 Console.SetCursorPosition(0, i);
             Console.Write(new string(' ', Console.WindowWidth+50));
			}
            
        }
        public void menu_LVL()
        {
            Console.BufferHeight = 61;
            Console.BufferWidth = 201;
            Console.SetWindowSize(200, 60);
            int lvl=0;
            int speed=100;
            //sciany(lvl);
            lvl_state = 0;
            restart_LVL(lvl, speed);
            highlight_LVL(0, lvl, speed);
            while (true)
            {
                ConsoleKeyInfo kb;
                kb = Console.ReadKey(false);
                switch (kb.Key)
                { //react to input
                    case ConsoleKey.UpArrow:
                        switch (lvl_state)
                        {
                            case 0:                           
                                highlight_LVL(2, lvl, speed);
                                lvl_state = ((3 + lvl_state - 1) % 3);
                                break;
                            case 1:
                                highlight_LVL(0, lvl, speed);                               
                                lvl_state = ((3 + lvl_state - 1) % 3);
                                break;
                            case 2:
                                highlight_LVL(1, lvl, speed);
                                lvl_state = ((3 + lvl_state - 1) % 3);
                                break;
                        }
                        break;

                    case ConsoleKey.DownArrow:

                        switch (lvl_state)
                        {
                            case 0:
                                highlight_LVL(1, lvl, speed);
                                lvl_state = ((lvl_state + 1) % 3);
                                break;
                            case 1:
                                highlight_LVL(2, lvl, speed);
                                lvl_state = ((lvl_state + 1) % 3);
                                break;
                            case 2:
                                highlight_LVL(0, lvl, speed);
                                lvl_state = ((lvl_state + 1) % 3);
                                break;  
                        }
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        reset_menu(muzik);
                        highlight_menu(0, muzik);
                        menu_conroler(false);
                        break;
                }
                if (kb.Key == ConsoleKey.Enter)
                {
                    if (lvl_state == 0)
                    {
                        Snake snake = new Snake(lvl,speed);
                        GameViewer view = new GameViewer();
                        Console.Clear();
                        view.wyswietl_wynik(0);
                        snake.muzik = this.muzik;
                        snake.Snake_Init();
                    }
                    if (lvl_state == 1) // rysowanie scian
                    {
                        
                       // sciany(lvl);
                        if (lvl == 0) { lvl = 1; }//sciany(0); }
                        else if (lvl == 1) { lvl = 2; }//sciany(1); }
                        else if (lvl == 2) { lvl = 0; }//sciany(2); }
                        highlight_LVL(1, lvl, speed);
                                          
                    }
                    if (lvl_state == 2)
                    {
                        {
                            if (speed == 100) speed = 80;
                            else if (speed == 80) speed = 60;
                            else if (speed == 60) speed = 100;
                            highlight_LVL(2, lvl, speed);
                        }
                    }
                }
            }
        }
        private void sciany(int elo)
        {           
            Console.SetCursorPosition(0, 7);
            Console.WriteLine("                                                                                                                                                                                                        ");
            Console.SetCursorPosition(0, Console.WindowHeight-7);
            Console.WriteLine("                                                                                                                                                                                                        ");
            for (int i = 7; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine(' ');
                Console.SetCursorPosition(Console.WindowWidth - 1, i);
                Console.WriteLine(' ');
            }

            if (elo == 2)
            {
                Console.SetCursorPosition(0, 7);
                Console.WriteLine(new string('#', Console.WindowWidth));
                Console.SetCursorPosition(0, Console.WindowHeight - 1);
                Console.WriteLine(new string('#', Console.WindowWidth));
                for (int i = 0; i < 60; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine('#');
                    Console.SetCursorPosition(Console.WindowWidth - 7, i);
                    Console.WriteLine('#');
                }
            }
            else if (elo == 1)
            {
                Console.SetCursorPosition(0, 7);
                Console.WriteLine("########################################################################################################################################################################################################");
                Console.SetCursorPosition(0, Console.WindowHeight -7);
                Console.WriteLine("########################################################################################################################################################################################################");
                for (int i = 7; i < 30; i++)
                {
                    Console.SetCursorPosition(0, i);
                    Console.Write('#');
                    Console.SetCursorPosition(Console.WindowWidth - 7, i);
                    Console.Write('#');
                }
            }
        }
        public void menu_conroler(bool play)
        {
            if (play == true && muzik==true)
            {
                player.SoundLocation = "1.wav";
                player.Play();
            }
            Scoreboard scoreboard = new Scoreboard();
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
                                    Console.Clear();
                                    menu_LVL();
                                    break;
                                case 1:
                                    if ((kb.Key == ConsoleKey.Enter) && (muzik == false))
                                    {
                                        player.SoundLocation = "1.wav";
                                        player.Play();
                                        player.Play();
                                        muzik = true;// wlacz wlacz dzwieki + zmiana stanu DODAC FUNKCJE WYLACZENIA DZWIEKOW
                                        Console.Clear();
                                        highlight_menu(1, muzik);                                       
                                    }
                                    else if ((kb.Key == ConsoleKey.Enter) && (muzik == true))
                                    {
                                        player.Stop();
                                        muzik = false;// wylacz wlacz dzwieki + zmiana stanu
                                        ClearCurrentConsoleLine(20);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.SetCursorPosition(0, 20);
                                        Console.Write(music_OFF);
                                       
                                    }
                                    break;
                                case 2:
                                    scoreboard.muzik = this.muzik;
                                    scoreboard.wypisz(false);
                                    break;
                                case 3:
                                    Environment.Exit(0);
                                    break;
                            }
                            break;
                        case ConsoleKey.Escape:
                            Environment.Exit(0);
                            break;
                    }     
            }
        }
    }
}







