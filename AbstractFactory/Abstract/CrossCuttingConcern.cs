namespace AbstractFactory.Abstract
{
    public abstract class CrossCuttingConcern
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }
}
