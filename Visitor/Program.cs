using System;

namespace Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            IPhone iPhone = new IPhone();
            iPhone.Accept(new OsVisitor());
            iPhone.Accept(new StoreVisitor());

            Console.WriteLine("------------");

            Samsung samsung = new Samsung();
            samsung.Accept(new OsVisitor());
            samsung.Accept(new StoreVisitor());

            Console.ReadLine();
        }
    }

    abstract class Phone
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public abstract void Accept(Visitor visitor);
    }
    class IPhone : Phone
    {
        public override void Accept(Visitor visitor)
        {
            visitor.Generate(this);
        }
    }

    class Samsung : Phone
    {
        public override void Accept(Visitor visitor)
        {
            visitor.Generate(this);
        }
    }

    abstract class Visitor
    {
        public abstract void Generate(Phone phone);
    }


    class OsVisitor : Visitor
    {
        public override void Generate(Phone phone)
        {
            if (phone is IPhone)
            {
                Console.WriteLine("Telefona Ios işletim sistemi yüklendi.");
            }
            else if (phone is Samsung)
            {
                Console.WriteLine("Telefona Android işletim sistemi yüklendi.");
            }
        }
    }

    class StoreVisitor : Visitor
    {
        public override void Generate(Phone phone)
        {
            if (phone is IPhone)
            {
                Console.WriteLine("Telefona App Store market yüklendi.");
            }
            else if (phone is Samsung)
            {
                Console.WriteLine("Telefona Google Play market yüklendi.");
            }
        }
    }

}
