namespace ObserverPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("▶ Press Enter to say hello,");
        Console.WriteLine("▶ Press 1 to create timer,");
        Console.WriteLine("and the other Keys for Input Trigger, Esc to exit.");

        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);  // trueでキーのエコーをオフにする
            if (keyInfo.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("bye.");
                break;
            }
            // Escキーでループを抜けてプログラムを終了

            switch (keyInfo.Key)
            {
                case ConsoleKey.Enter:
                    Console.WriteLine("Hello, World!");
                    break;
                case ConsoleKey.A:
                    Console.WriteLine("Press: A");
                    break;
                case ConsoleKey.RightArrow:
                    Console.WriteLine("Press: →");
                    break;
                case ConsoleKey.D0:
                    Console.WriteLine("Press: 0");
                    break;
                case ConsoleKey.D1:
                    Console.WriteLine("Press: 1 ... new Timer has been created!");
                    new WarningTimer().Start();

                    break;

                default:
                    break;
            }
        }
    }
}
