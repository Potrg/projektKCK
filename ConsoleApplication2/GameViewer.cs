using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{

    class GameViewer
    {
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
        public static void ClearCurrentConsoleLine(int currentLineCursor)
        {
            for (int i = currentLineCursor; i < currentLineCursor + 6; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', 200));
            }
        }
        public void wyswietl_wynik(int wynik)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            ClearCurrentConsoleLine(0);
            int hOffset=200;
            int vOffset=0;
            string wynik_elo = Convert.ToString(wynik);
            for (int i = wynik_elo.Length-1; i >= 0;i-- )
            {
                if (i % 3 == 2 && i < wynik_elo.Length - 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    int kropkomat = hOffset - 1;
                    int kropkomat2 = vOffset + 5;
                    Console.SetCursorPosition(kropkomat, kropkomat2);
                    Console.Write("*");

                }
                Console.ForegroundColor = ConsoleColor.Black;
                hOffset = hOffset - 11;
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
    }

//dodać funkcje wyświetlające węża oraz jedzenie.
}
