using System;

namespace SnakeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.CursorSize = 12;
            Console.BufferHeight = 60;
            Console.BufferWidth = 200;
            Console.SetWindowSize(200, 60);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(0, 0);
            Menu_class menu = new Menu_class(true);
            menu.show_menu();       
            Console.ReadKey(false);
        }
    }
}
