using System;
using System.Collections;

namespace Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context = new Context();

            ArrayList list = new ArrayList();

            list.Add(new Plus());
            list.Add(new Minus());
            list.Add(new Divided());
            list.Add(new Multiply());

            foreach (AbstractExpression item in list)
            {
                item.Interpret(context);
            }

            Console.ReadLine();
        }
    }

    class Context
    {
    }

    abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    class Plus : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Toplama");
        }
    }

    class Minus : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Çıkarma");
        }
    }
    class Divided : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Bölme");
        }
    }

    class Multiply : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Çarpma");
        }
    }
}
