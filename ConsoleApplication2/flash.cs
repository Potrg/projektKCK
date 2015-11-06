using System;

namespace SnakeApp
{
    class flash
    {
        public static void ClearCurrentConsoleLine(int currentLineCursor)
        {
            for (int i = currentLineCursor; i < currentLineCursor + 8; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(new string(' ', Console.WindowWidth));
            }

        }
        public void start_screen()
        {

            String any_key =
            "                                         _____                                        _                _                          _   _                    \n" +
            "                                        | ___ \\                                      | |              | |                        | | (_)                  \n" +
            "                                        | |_/ / __ ___  ___ ___    __ _ _ __  _   _  | | _____ _   _  | |_ ___     ___ ___  _ __ | |_ _ _ __  _   _  ___  \n" +
            "                                        |  __/ '__/ _ \\/ __/ __|  / _` | '_ \\| | | | | |/ / _ \\ | | | | __/ _ \\   / __/ _ \\| '_ \\| __| | '_ \\| | | |/ _ \\ \n" +
            "                                        | |  | | |  __/\\__ \\__ \\ | (_| | | | | |_| | |   <  __/ |_| | | || (_) | | (_| (_) | | | | |_| | | | | |_| |  __/ \n" +
            "                                        \\_|  |_|  \\___||___/___/  \\__,_|_| |_|\\__, | |_|\\_\\___|\\__, |  \\__\\___/   \\___\\___/|_| |_|\\__|_|_| |_|\\__,_|\\___| \n" +
            "                                                                               __/ |            __/ |                                                     \n" +
            "                                                                              |___/            |___/                                                      \n";
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ClearCurrentConsoleLine(40);
                Console.SetCursorPosition(0, 40);
                Console.Write(any_key);
                System.Threading.Thread.Sleep(1000);
                ClearCurrentConsoleLine(40);
                System.Threading.Thread.Sleep(700);

            }
        }
    }
}
