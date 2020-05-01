using FactoryMethod.Abstract;
using System;

namespace FactoryMethod.Manager
{
    public class EmailLogManager : ILogger
    {
        public void Log(string message) => Console.WriteLine($"Email loglama işlemi: {message}");
    }
}
