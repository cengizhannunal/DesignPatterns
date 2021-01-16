using System;
using System.Collections.Generic;

namespace Composite
{
    static class Program
    {
        static void Main(string[] args)
        {
            Composite root = new Composite("Main");
            Composite sportOutdoor = new Composite("Sport-Outdoor");
            root.Add(sportOutdoor);

            Composite electronic = new Composite("Electronic");
            electronic.Add(new Leaf("Laptop"));
            electronic.Add(new Leaf("Telephone"));
            root.Add(electronic);


            Composite clothing = new Composite("Clothing");
            clothing.Add(new Leaf("Shoes"));
            clothing.Add(new Leaf("Jean"));
            clothing.Add(new Leaf("Jacket"));

            root.Add(clothing);

            root.Display();
            Console.ReadKey();
        }

        abstract class Component
        {
            string name { get; set; }
            protected Component(string name)
            {
                this.name = name;
            }
            public abstract void Add(Component component);
            public abstract void Display();
        }

        class Leaf : Component
        {
            string name { get; set; }
            public Leaf(string name) : base(name)
            {
                this.name = name;
            }
            public override void Add(Component component)
            {
                throw new NotImplementedException();
            }

            public override void Display()
            {
                Console.WriteLine("-> " + name);
            }
        }

        class Composite : Component
        {
            public List<Component> components = new List<Component>();
            string name { get; set; }
            public Composite(string name) : base(name)
            {
                this.name = name;
            }

            public override void Add(Component component)
            {
                components.Add(component);
            }
            public override void Display()
            {
                Console.WriteLine(name);
                foreach (var item in components)
                {
                    item.Display();
                }
            }
        }
    }
}
