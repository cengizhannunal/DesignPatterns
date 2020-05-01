using System;

namespace AbstractFactory.Caching
{
    public class RedisCaching : Abstract.Caching
    {
        public override void Cache(string message) => Console.WriteLine("cached redis");
    }
}
