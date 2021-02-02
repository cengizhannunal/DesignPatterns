using System;
using System.Collections.Generic;

namespace Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            IMediator mediator = new ConcreteMediator();

            User1 user1 = new User1(mediator);
            User2 user2 = new User2(mediator);

            user2.Publish($"Mesaj {typeof(User2).Name}'den yayınlandı.");
            Console.Read();
        }

        interface IMediator
        {
            void Publish(string message);
            void Add(Colleague subscriber);
        }

        abstract class Colleague
        {
            public abstract void Publish(string message);
            public abstract void Handle(string message);
        }

        class ConcreteMediator : IMediator
        {
            List<Colleague> colleagues { get; set; } = new List<Colleague>();
            public void Publish(string message)
            {
                foreach (var item in colleagues)
                {
                    item.Handle(message);
                }
            }

            public void Add(Colleague subscriber)
            {
                colleagues.Add(subscriber);
            }
        }


        class User1 : Colleague
        {
            readonly IMediator _mediator;
            public User1(IMediator mediator)
            {
                _mediator = mediator;
                mediator.Add(this);
            }
            public override void Handle(string message)
            {
                Console.WriteLine("User1 mesajı: " + message);
            }
            public override void Publish(string message)
            {
                _mediator.Publish(message);
            }
        }

        class User2 : Colleague
        {
            readonly IMediator _mediator;
            public User2(IMediator mediator)
            {
                _mediator = mediator;
                mediator.Add(this);
            }
            public override void Handle(string message)
            {
                Console.WriteLine("User2 mesajı: " + message);
            }
            public override void Publish(string message)
            {
                _mediator.Publish(message);
            }
        }
    }
}
