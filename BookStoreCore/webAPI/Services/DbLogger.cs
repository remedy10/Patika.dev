namespace webAPI.Services
{
    public class DbLogger : ILoggerService
    {
        public void Write(string message)
        {
            Console.WriteLine("[DbLOGGER] => {0}", message);
        }
    }
}
