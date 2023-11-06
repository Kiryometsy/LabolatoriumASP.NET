namespace Labolatorium3App.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime Actual() { return DateTime.Now; }
    }
}
