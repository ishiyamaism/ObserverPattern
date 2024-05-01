namespace ObserverPattern;

public static class WarningTimerCounter
{
  public static int Count { get; private set; }

  static WarningTimerCounter()
  {
    Count = 1;  // 最初にメインタイマーがあるとする
  }
  public static void Countup()
  {
    Count = Count + 1;
  }
}
