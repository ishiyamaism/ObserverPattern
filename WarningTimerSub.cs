namespace ObserverPattern;

/// <summary>
/// サブタイマー
/// (他スレッドなど用のメイン以外監視タイマー)
/// </summary>
public class WarningTimerSub
{
  private Timer _timer;
  private int _timerNumber;
  public string TimerName
  {
    get { return $"{_timerNumber}個目タイマー"; }
  }

  private bool _isWarning = false;
  public bool IsWarning
  {
    get { return _isWarning; }
    private set
    {
      if (_isWarning != value)
      {
        _isWarning = value;
      }
    }
  }


  public WarningTimerSub()
  {
    _timer = new Timer(TimerCallback);
  }

  public void Start()
  {
    WarningTimerCounter.Countup();
    _timer.Change(0, 5000);
    _timerNumber = WarningTimerCounter.Count;
  }

  /// <summary>
  /// 普通の実装：タイマーが定期的に監視する
  /// (何個も存在すればそれぞれが逐一報告する)
  /// </summary>
  /// <param name="state"></param>
  private void TimerCallback(object? state)
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
