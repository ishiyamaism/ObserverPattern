namespace ObserverPattern;

/// <summary>
/// 監視用インスタンス(旧サブタイマー)
/// (他スレッドなど用のメイン以外監視用インスタンス)
/// </summary>
public class WarningObserver
{
  private int _observerNumber;
  public string ObserverName
  {
    get { return $"{_observerNumber}個目オブザーバー"; }
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


  public WarningObserver()
  {
    WarningTimerMain.WarningAction += WarningTimerMain_WarningAction;
  }

  public void Start()
  {
    WarningObserverCounter.Countup();
    _observerNumber = WarningObserverCounter.Count;
  }

  /// <summary>
  /// 変更時に通知が来る
  /// </summary>
  /// <param name="isWarning"></param>
  private void WarningTimerMain_WarningAction(bool isWarning)
  {
    Console.WriteLine($"{ClockNow.MiliSeconds}: {isWarning}という通知が{ObserverName}に来た");
  }
}
