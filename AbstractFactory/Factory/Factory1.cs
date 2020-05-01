using AbstractFactory.Abstract;
using AbstractFactory.Caching;
using AbstractFactory.Logger;

namespace AbstractFactory.Factory
{
    public class Factory1 : CrossCuttingConcern
    {
        public override Abstract.Caching CreateCaching() => new RedisCaching();

        public override Logging CreateLogger() => new DatabaseLogger();
    }
}
