using AbstractFactory.Abstract;
using System;

namespace AbstractFactory.Logger
{
    public class DatabaseLogger : Logging
    {
        public override void Log(string message) => Console.WriteLine("logged database");
    }
}
