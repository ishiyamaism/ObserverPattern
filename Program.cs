﻿namespace ObserverPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("▶ Press Enter to say hello,");
        Console.WriteLine("▶ Press 1 to create timer,");
        Console.WriteLine("and the other Keys for Input Trigger, Esc to exit.");

        // メインタイマー起動
        WarningTimerMain.Start();

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("bye.");
                break;
            }
            // Escキーでプログラムを終了

            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    Console.WriteLine("Hello, timer!");
                    break;
                case ConsoleKey.D1:
                    Console.WriteLine("Press: 1 ... new Timer has been created!");
                    new WarningTimerSub().Start();

                    break;

                default:
                    break;
            }
        }
    }
}
