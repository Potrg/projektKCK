using ConsoleApplication2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.BufferHeight = 60;
            Console.BufferWidth = 200;
            Console.SetWindowSize(200, 60);
     

            Console.ForegroundColor = ConsoleColor.Cyan;
            int OptionsCursorWidth = 0;
            int OptionsCursorHeigh = 0;
            Console.SetCursorPosition(OptionsCursorWidth, OptionsCursorHeigh);

            Menu_class menu = new Menu_class();
            menu.show_menu(OptionsCursorHeigh);
            
            Console.ReadKey();
        }
    }
}
