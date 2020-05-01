using FactoryMethod.Abstract;
using System;

namespace FactoryMethod.Manager
{
    public class FileLogManager : ILogger
    {
        public void Log(string message) => Console.WriteLine($"File loglama işlemi: {message}");
    }
}
