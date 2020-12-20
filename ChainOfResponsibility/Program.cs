using System;

namespace ChainOfResponsibility
{
    static class Program
    {
        static void Main(string[] args)
        {
            var databaseLogger = new DatabaseLogger();
            databaseLogger.Logging("Chain Of Responsibility");
            Console.Read();
        }
    }

    public abstract class Logger
    {
        protected Logger Next { get; set; }
        abstract protected void WriteMessage(string message);

        internal void Logging(string message)
        {
            try
            {
                WriteMessage(message);
            }
            catch
            {
                if (Next != null)
                    Next.Logging(message);
            }
        }
    }

    public class FileLogger : Logger
    {
        protected override void WriteMessage(string message)
        {
            Console.WriteLine(string.Concat(message, " mesaj dosyaya yazıldı."));
        }
    }

    public class DatabaseLogger : Logger
    {
        public DatabaseLogger()
        {
            Next = new FileLogger();
        }
        protected override void WriteMessage(string message)
        {
            Console.WriteLine(string.Concat(message, " mesaj veritabanına yazıldı."));
        }
    }
}
