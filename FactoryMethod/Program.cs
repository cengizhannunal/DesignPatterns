using FactoryMethod.Abstract;
using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new LoggerFactory().CreateLogger(LoggerType.FileLogger);
            logger.Log("system format exception");
            Console.ReadKey();
        }
    }
}
