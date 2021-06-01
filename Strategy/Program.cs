using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context;

            context = new Context(new ExcelReportStrategy());
            context.Create();

            context = new Context(new WordReportStrategy());
            context.Create();

            context = new Context(new PdfReportStrategy());
            context.Create();

            Console.ReadLine();
        }
    }

    //Strategy
    interface IReport
    {
        void CreateReport();
    }

    //ConcreteStrategy  
    class ExcelReportStrategy : IReport
    {
        public void CreateReport()
        {
            Console.WriteLine("Excel raporu oluşturuldu.");
        }
    }

    //ConcreteStrategy  
    class WordReportStrategy : IReport
    {
        public void CreateReport()
        {
            Console.WriteLine("Word raporu oluşturuldu.");
        }
    }

    //ConcreteStrategy  
    class PdfReportStrategy : IReport
    {
        public void CreateReport()
        {
            Console.WriteLine("Pdf raporu oluşturuldu.");
        }
    }

    //Context
    class Context
    {
        readonly IReport _strategy;
        public Context(IReport strategy)
        {
            _strategy = strategy;
        }

        public void Create()
        {
            _strategy.CreateReport();
        }
    }
}
