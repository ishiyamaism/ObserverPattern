namespace ObserverPattern;

public class WarningTimer
{
  private Timer _timer;
  private int _timerNumber;
  public string TimerName
  {
    get { return $"{_timerNumber}個目タイマー"; }
  }
  public bool IsWarning { get; private set; }
  public WarningTimer()
  {
    _timer = new Timer(TimerCallback);
  }

  public void Start()
  {
    WarningTimerCounter.Countup();
    _timer.Change(0, 5000);
    _timerNumber = WarningTimerCounter.Count;
  }

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
