using System;

namespace AbstractFactory.Caching
{
    public class MemoryCaching : Abstract.Caching
    {
        public override void Cache(string message) => Console.WriteLine("cached memory");
    }
}
