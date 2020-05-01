using AbstractFactory.Abstract;
using AbstractFactory.Caching;
using AbstractFactory.Logger;

namespace AbstractFactory.Factory
{
    public class Factory2 : CrossCuttingConcern
    {
        public override Abstract.Caching CreateCaching() => new MemoryCaching();

        public override Logging CreateLogger() => new FileLogger();
    }
}
