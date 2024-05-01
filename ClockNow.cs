namespace ObserverPattern;

public static class ClockNow
{
  public static string MiliSeconds
  {
    get { return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"); }
  }
}
