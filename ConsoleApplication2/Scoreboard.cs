using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Scoreboard
    {
        List<Player> listPlayer = new List<Player>();
        string path = "scoreboard.txt";
        public void wczytaj()
        {
            if (File.Exists(path))
            {
                using (StreamReader personfile = new StreamReader(path,false))
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
            //File.Delete(path);
        }
        public void zapisz()
        {
            File.Delete(path);
            using (StreamWriter sw2 = new StreamWriter(path,false))
            {
                foreach (Player player in listPlayer)
                {
                        sw2.WriteLine(player.name + "," + player.score);
                }
                sw2.Close();
            }
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
        public void wypisz()
        {
            wczytaj();
            Console.Clear();
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
            File.Delete(path);
            zapisz();

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
                            Menu_class menu = new Menu_class();
                            menu.highlight_menu(0, menu.muzik);
                            menu.menu_conroler();
                            break;
                    }

                }

        }

    }
}
