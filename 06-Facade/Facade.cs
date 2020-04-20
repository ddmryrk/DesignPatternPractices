using _06_Facade.Interfaces;
using System;

namespace _06_Facade
{
    /// Patternin amacı, çeşitli sınıfların ortak amaçlar için her seferinde tek tek çağırılmasındansa,
    /// bu sınıfların bir cephede toparlanıp onlara erişimin kolaylaştırılmasıdır.
    /// CrossCuttongConcerns : uygulamayı dikine kesen durumlar
    class Facade
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        private CrossCuttongConcernsFacade _concerns;
        public CustomerManager()
        {
            _concerns = new CrossCuttongConcernsFacade();
        }

        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Authorize.CheckUser();
            _concerns.Logging.Log();
            _concerns.Validation.Validate();
            Console.WriteLine("Saved");
        }
    }

    #region Inherited Classes
    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }
    class Caching : ICaching
    {

        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }
    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }
    class Validation : IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated");
        }
    }
    #endregion

    class CrossCuttongConcernsFacade
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorize;
        public IValidate Validation;


        public CrossCuttongConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
            Validation = new Validation();
        }
    }
}
