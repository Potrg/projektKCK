using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BufferHeight = 60;
            Console.BufferWidth = 200;
            Console.SetWindowSize(200, 60);
            Console.SetCursorPosition(13, 13);
            Console.Write("Witam Studenta!");
            Console.ReadKey();

            Console.SetCursorPosition(5, 5);
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            int OptionsCursorWidth = 20;
            int OptionsCursorHeigh = 0;


            Console.SetCursorPosition(OptionsCursorWidth, OptionsCursorHeigh++);//elo elo



            OptionsCursorHeigh = OptionsCursorHeigh + 5;
            Console.SetCursorPosition(OptionsCursorWidth, OptionsCursorHeigh++);
            Console.Write("  /$$$$$$  /$$$$$$$  /$$$$$$$$ /$$$$$$  /$$$$$$  /$$   /$$  /$$$$$$ \n"); Console.SetCursorPosition(OptionsCursorWidth, OptionsCursorHeigh++);
            Console.Write(" /$$__  $$| $$__  $$|__  $$__/|_  $$_/ /$$__  $$| $$$ | $$ /$$__  $$\n"); Console.SetCursorPosition(OptionsCursorWidth, OptionsCursorHeigh++);
            Console.Write("| $$  \\ $$| $$  \\ $$   | $$     | $$  | $$  \\ $$| $$$$| $$| $$  \\__/\n"); Console.SetCursorPosition(OptionsCursorWidth, OptionsCursorHeigh++);
            Console.Write("| $$  | $$| $$$$$$$/   | $$     | $$  | $$  | $$| $$ $$ $$|  $$$$$$ \n"); Console.SetCursorPosition(OptionsCursorWidth, OptionsCursorHeigh++);
            Console.Write("| $$  | $$| $$____/    | $$     | $$  | $$  | $$| $$  $$$$ \\____  $$\n"); Console.SetCursorPosition(OptionsCursorWidth, OptionsCursorHeigh++);
            Console.Write("| $$  | $$| $$         | $$     | $$  | $$  | $$| $$\\  $$$ /$$  \\ $$\n"); Console.SetCursorPosition(OptionsCursorWidth, OptionsCursorHeigh++);
            Console.Write("|  $$$$$$/| $$         | $$    /$$$$$$|  $$$$$$/| $$ \\  $$|  $$$$$$/\n"); Console.SetCursorPosition(OptionsCursorWidth, OptionsCursorHeigh++);
            Console.Write(" \\______/ |__/         |__/   |______/ \\______/ |__/  \\__/ \\______/\n"); Console.SetCursorPosition(OptionsCursorWidth, OptionsCursorHeigh++);
            Console.ReadKey();
        }
    }
}