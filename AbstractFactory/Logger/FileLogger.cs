using AbstractFactory.Abstract;
using System;

namespace AbstractFactory.Logger
{
    public class FileLogger : Logging
    {
        public override void Log(string message) => Console.WriteLine("logged file");
    }
}
