namespace _03_AbstractFactory.AbstractClasses
{
    public abstract class CrossCuttingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }
}
