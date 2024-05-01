namespace ObserverPattern;

/// <summary>
/// 一括監視用メインタイマー
/// </summary>
public static class WarningTimerMain
{
  private static Timer _timer;
  public static string TimerName
  {
    get { return "メインタイマー"; }
  }

  private static bool _isWarning = false;
  public static bool IsWarning
  {
    get { return _isWarning; }
    private set
    {
      if (_isWarning != value)
      {
        // 変化時に変化をInvokeで通知
        WarningAction?.Invoke(value);
        _isWarning = value;
      }
    }
  }

  /// <summary>
  /// "event"でカプセル化されたデリゲート
  /// (+= か -= でしか登録/解除ができない)
  /// </summary>
  public static event Action<bool>? WarningAction;

  static WarningTimerMain()
  {
    _timer = new Timer(TimerCallback);
  }

  public static void Start()
  {
    _timer.Change(0, 5000);
  }

  /// <summary>
  /// 普通の実装：タイマーが定期的に監視する
  /// (何個も存在すればそれぞれが逐一報告する)
  /// </summary>
  /// <param name="state"></param>
  private static void TimerCallback(object? state)
  {
    var lines = File.ReadAllLines("warning.txt");
    if (lines.Length > 0)
    {
      IsWarning = lines[0] == "1";
    }
    else
    {
      IsWarning = false;
    }

    Console.WriteLine($"{ClockNow.MiliSeconds}: {TimerName}says {IsWarning}");
  }
}
