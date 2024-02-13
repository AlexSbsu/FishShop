namespace Fish_Shop
{
    public interface ITimeService
    { 
        string GetTime { get; }  
    }
    public class TimeService : ITimeService
    {
        public string GetTime => DateTime.Now.ToString("hh:mm:ss");
    }
    public interface IDateService
    {
        string GetDateNow { get; }
    }
    public class DateService : IDateService
    {
        public string GetDateNow => DateTime.Now.ToString();
    }
}
