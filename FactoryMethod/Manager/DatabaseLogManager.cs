using FactoryMethod.Abstract;
using System;

namespace FactoryMethod.Manager
{
    public class DatabaseLogManager : ILogger
    {
        public void Log(string message) => Console.WriteLine($"Database loglama işlemi: {message}");
    }
}
