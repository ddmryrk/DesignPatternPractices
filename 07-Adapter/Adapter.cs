using _07_Adapter.Interfaces;
using System;

namespace _07_Adapter
{
    /// Bu pattern, farklı sistemlerin kendi sistemlerimize entegre etmemiz durumunda,
    /// kendi sistemimizin bozulmadan, farklı sistemin sanki kendi sistemimizmiş
    /// gibi davranmasını sağlar.
    class Adapter
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new Log4NetAdapter());
            productManager.Save();
            Console.ReadLine();
        }
    }

    class ProductManager
    {
        private ILogger _logger;

        public ProductManager(ILogger logger)
        {
            _logger = logger;
        }

        public void Save()
        {
            _logger.Log("User Data");
            Console.WriteLine("Saved");
        }
    }

    #region Inherited Classes
    class EdLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Logged, {0}", message);
        }
    }

    class Log4NetAdapter : ILogger
    {
        public void Log(string message)
        {
            Log4Net log4Net = new Log4Net();
            log4Net.LogMessage(message);
        }
    }
    #endregion

    //Nuget
    class Log4Net
    {
        public void LogMessage(string message)
        {
            Console.WriteLine("Logged with log4net, {0}", message);
        }
    }
}
