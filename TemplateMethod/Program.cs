using System;

namespace TemplateMethod
{
    static class Program
    {
        static void Main(string[] args)
        {
            FileLogger fileLogger = new FileLogger();
            fileLogger.Log("Mesaj dosyaya loglandı.");

            DatabaseLogger databaseLogger = new DatabaseLogger();
            databaseLogger.Log("Mesaj veritabanına loglandı.");

            Console.ReadKey();
        }


        abstract class Logger
        {
            protected abstract void Logging(string message);
            public void Log(string message)
            {
                Logging(message);
            }
        }

        class FileLogger : Logger
        {
            protected override void Logging(string message)
            {
                Console.WriteLine(message);
            }
        }

        class DatabaseLogger : Logger
        {
            protected override void Logging(string message)
            {
                Console.WriteLine(message);
            }
        }
    }
}
