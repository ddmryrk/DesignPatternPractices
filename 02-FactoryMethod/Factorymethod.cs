using _02_FactoryMethod.Interfaces;
using System;

namespace _02_FactoryMethod
{
    class Factorymethod
    {
        /// Bu pattern ile loglamayı yönetecek fabrikalar yaratıyoruz.
        /// Sınıflar çıplak olmamalıdır. Interfacelerden türetilip soyutlanması gerekir.
        /// Fabrikaları da interfaceler ile soyutlayarak daha esnek bir yapı kuruyoruz.
        /// new ile oluşturulan her nesneye bağımlıyız. Bu yüzden soyutlamamız gerekir.
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            customerManager.Save();

            Console.ReadLine();
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }

    public class LoggerFactory : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new EdLogger();
        }
    }

    public class LoggerFactory2 : ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            //Business to decide factory
            return new Log4NetLogger();
        }
    }


    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EdLogger");
        }
    }

    public class Log4NetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with Log4NetLogger");
        }
    }
}
