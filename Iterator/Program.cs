using System;
using System.Collections.Generic;

namespace Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteAggregate aggregate = new ConcreteAggregate();
            aggregate.Add(new Category() { Name = "Csharp" });
            aggregate.Add(new Category() { Name = "Asp.Net" });
            aggregate.Add(new Category() { Name = "EntityFramework" });
            aggregate.Add(new Category() { Name = ".NET CORE" });

            IIterator iterator = aggregate.CreateIterator();

            Console.WriteLine($"İlk eleman : {((Category)iterator.First()).Name}");
            Console.WriteLine($"Son eleman : {((Category)iterator.Last()).Name}");

            while (iterator.MoveNext())
            {
                Console.WriteLine(((Category)iterator.Current()).Name);
            }

            Console.ReadLine();
        }
    }

    class Category
    {
        public string Name { get; set; }
    }

    //Iterator
    interface IIterator
    {
        public abstract object First();
        public abstract object Last();
        public abstract bool MoveNext();
        public abstract object Current();
    }

    //Aggregate
    interface IAggregate
    {
        IIterator CreateIterator();
    }

    //ConcreteAggregate
    class ConcreteAggregate : IAggregate
    {
        public List<Category> Categories { get; } = new List<Category>();
        public void Add(Category category) => Categories.Add(category);
        public int Count { get => Categories.Count; }
        public IIterator CreateIterator()
        {
            return new CategoryIterator(this);
        }
    }

    //ConcreteIterator
    class CategoryIterator : IIterator
    {
        readonly ConcreteAggregate _aggregate;
        int currentIndex = -1;
        public CategoryIterator(ConcreteAggregate categoryAggregate)
        {
            _aggregate = categoryAggregate;
        }

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < _aggregate.Count;
        }

        public object Current()
        {
            return _aggregate.Categories[currentIndex];
        }

        public object First()
        {
            return _aggregate.Categories[0];
        }

        public object Last()
        {
            return _aggregate.Categories[_aggregate.Count - 1];
        }
    }


}
