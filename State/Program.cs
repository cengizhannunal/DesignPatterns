using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderContext orderContext = new OrderContext(new Prepare());
            orderContext.Next();
            orderContext.Next();

            Console.ReadLine();
        }
    }

    //State
    abstract class State
    {
        public abstract void Handle(OrderContext orderContext);
    }

    //ConcreteState
    class Prepare : State
    {
        public Prepare()
        {
            Console.WriteLine("Sipariş hazırlanıyor.");
        }
        public override void Handle(OrderContext orderContext)
        {
            orderContext.State = new Cargo();
        }
    }
    //ConcreteState
    class Cargo : State
    {
        public Cargo()
        {
            Console.WriteLine("Sipariş kargolandı.");
        }
        public override void Handle(OrderContext orderContext)
        {
            orderContext.State = new Delivery();
        }
    }
    //ConcreteState
    class Delivery : State
    {
        public Delivery()
        {
            Console.WriteLine("Sipariş teslim edildi.");
        }
        public override void Handle(OrderContext orderContext)
        {
            //
        }
    }
    //Context
    class OrderContext
    {
        public State State;

        public OrderContext(State state)
        {
            this.State = state;
        }

        public void Next()
        {
            State.Handle(this);
        }
    }

}
