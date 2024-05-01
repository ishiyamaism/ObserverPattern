namespace ObserverPattern;

public static class WarningObserverCounter
{
  public static int Count { get; private set; }

  static WarningObserverCounter()
  {
    Count = 1;  // 最初にメインタイマーがあるとする
  }
  public static void Countup()
  {
    Count = Count + 1;
  }
}
