using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SnakeApp
{
    public class Scoreboard
    {

        public bool muzik;
        String tablica_wynikow= 
"                                                           ███████╗ ██████╗ ██████╗ ██████╗ ███████╗██████╗  ██████╗  █████╗ ██████╗ ██████╗ \n"+
"                                                           ██╔════╝██╔════╝██╔═══██╗██╔══██╗██╔════╝██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔══██╗\n"+
"                                                           ███████╗██║     ██║   ██║██████╔╝█████╗  ██████╔╝██║   ██║███████║██████╔╝██║  ██║\n"+
"                                                           ╚════██║██║     ██║   ██║██╔══██╗██╔══╝  ██╔══██╗██║   ██║██╔══██║██╔══██╗██║  ██║\n"+
"                                                           ███████║╚██████╗╚██████╔╝██║  ██║███████╗██████╔╝╚██████╔╝██║  ██║██║  ██║██████╔╝\n"+
"                                                           ╚══════╝ ╚═════╝ ╚═════╝ ╚═╝  ╚═╝╚══════╝╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ \n";
        public List<Player> listPlayer = new List<Player>();
        string path = @"C:\content\scoreboard.txt";
        /// <summary>
        /// dodaj - dodaje pojedyńczygo gracza do listy
        /// </summary>
        public void dodaj(Player player)
        {
            listPlayer.Add(player);
        }
        /// <summary>
        /// wczytaj - dodaje zwyciezcow z pliku do lisy
        /// </summary>
        public void wczytaj()
        { 
            if (File.Exists(path))
            {
                using (StreamReader personfile = new StreamReader(path))
                {
                    string line;
                    while ((line = personfile.ReadLine()) != null)
                    {
                        Player p = new Player();
                        string[] lineSplitted = line.Split(',');
                        p.name = lineSplitted[0];
                        p.score = int.Parse(lineSplitted[1]);
                        listPlayer.Add(p);
                    }
                    personfile.Close();
                }
            }
        }
        /// <summary>
        /// zapisuje liste do pliku
        /// </summary>
        public void zapisz()
        {  
            using (StreamWriter sw2 = new StreamWriter(path,false))
            {
                foreach (Player player in listPlayer)
                {
                        sw2.WriteLine(player.name + "," + player.score);
                }
                sw2.Close();
            }
            listPlayer.Clear();
        }
        private static void ClearCurrentConsoleLine(int hoffset, int voffset)
        {
            for (int i = voffset; i < voffset+19; i++)
            {
                Console.SetCursorPosition(hoffset, i);
                Console.Write("                                          ");
                Console.SetCursorPosition(hoffset + 43, i);
                Console.Write("                  ");
            }

        }
        /// <summary>
        /// Wypisuje na ekran UWAGA tylko dla consolowej aplikacji
        /// </summary>
        public void wypisz(bool muzyka)//funkcja tworzaca obraz - podmiana w nst projekcie
        { 
            wczytaj();
            Console.Clear();
            Console.SetCursorPosition(0, 10);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(tablica_wynikow);
            int hoffset = 68;
            int voffset = 26;
            Console.SetCursorPosition(hoffset, voffset++);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔══════════════════════════════════════════╦═══════════════════╗"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("╠───────────────Nick Gracza────────────────╬────────Wynik──────╣"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("╠══════════════════════════════════════════╬═══════════════════╣"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("║                                          ║                   ║"); Console.SetCursorPosition(hoffset, voffset++);
            Console.WriteLine("╚══════════════════════════════════════════╩═══════════════════╝"); Console.SetCursorPosition(hoffset, voffset++);
            List<Player> SortedList = listPlayer.OrderByDescending(o => o.score).ToList();
            hoffset = 70;
            voffset = 29;
            Console.ForegroundColor = ConsoleColor.Cyan;
            int przewijak = 0;
            for (int i = 0; i < SortedList.Count && i<19; i++)
            {
                Console.SetCursorPosition(hoffset, voffset);
                Console.WriteLine(SortedList[i].name); Console.SetCursorPosition(hoffset+45, voffset++);
                Console.WriteLine(SortedList[i].score);
            }
            voffset = 29;
                ConsoleKeyInfo kb;
                while (true)
                {
                    kb = Console.ReadKey(false);
                    switch (kb.Key)
                    { 
                        case ConsoleKey.DownArrow:
                            ClearCurrentConsoleLine(69, 29);
                            if (przewijak < SortedList.Count - 19) { przewijak++;}
                            for (int i = przewijak; i < SortedList.Count && i < 19 + przewijak; i++)
                            {
                                Console.SetCursorPosition(hoffset, voffset);
                                Console.WriteLine(SortedList[i].name); Console.SetCursorPosition(hoffset + 45, voffset++);
                                Console.WriteLine(SortedList[i].score);
                            }
                            voffset = 29;
                            break;
                        case ConsoleKey.UpArrow:
                            ClearCurrentConsoleLine(69, 29);
                            if (przewijak > 0)
                            { przewijak--; }
                            for (int i = przewijak; i < SortedList.Count && i < 19 + przewijak; i++)
                            {
                                Console.SetCursorPosition(hoffset, voffset);
                                Console.WriteLine(SortedList[i].name); Console.SetCursorPosition(hoffset + 45, voffset++);
                                Console.WriteLine(SortedList[i].score);
                            }
                            voffset = 29;
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            zapisz();
                            listPlayer.Clear();
                            Menu_class menu = new Menu_class(muzik);
                            menu.reset_menu(muzik);
                            menu.highlight_menu(0, muzik);
                            menu.menu_conroler(muzyka);
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            zapisz();
                            listPlayer.Clear();
                            menu = new Menu_class(muzik);
                            menu.reset_menu(muzik);
                            menu.highlight_menu(0, muzik);
                            menu.menu_conroler(muzyka);
                            break;
                    }

                }

        }

    }
}
