using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var logger = Logger.Instance();
            logger.Logging("Singleton pattern");
            Console.ReadKey();
        }
    }
}
