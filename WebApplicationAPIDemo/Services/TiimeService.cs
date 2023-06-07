namespace WebApplicationAPIDemo.Services
{
    public class TimeService
    {
        private readonly DateTime _startTime;
        public TimeService()
        {
            _startTime = DateTime.Now;
        }
        public DateTime StartTime => _startTime;
    }
}
