namespace ObserverPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("▶ Press Enter to say hello,");
        Console.WriteLine("▶ Press 1 to create observer,");
        Console.WriteLine("and the other Keys for Input Trigger, Esc to exit.");

        // メインタイマー起動
        WarningTimerMain.Start();

        // Observerイベント登録
        WarningTimerMain.WarningAction += WarningTimerMain_WarningAction;

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
                    Console.WriteLine("Press: 1 ... new Observer has been created!");
                    new WarningObserver().Start();

                    break;

                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 変更時に通知が来る
    /// </summary>
    /// <param name="isWarning"></param>
    private static void WarningTimerMain_WarningAction(bool isWarning)
    {
        Console.WriteLine($"{ClockNow.MiliSeconds}: {isWarning}という通知がメインスレッドに来た");
    }
}
