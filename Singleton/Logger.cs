using System;

namespace Singleton
{
    public class Logger
    {
        private Logger()
        {
        }
        private static Logger _logger;
        static object _lock = new object();

        public static Logger Instance()
        {
            if (_logger == null)
            {
                lock (_lock)
                {
                    if (_logger == null)
                        _logger = new Logger();
                }
            }

            return _logger;
        }

        public void Logging(string message) => Console.WriteLine(message);
    }
}
