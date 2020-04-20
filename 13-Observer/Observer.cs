using _13_Observer.AbstractClasses;
using System;
using System.Collections.Generic;

namespace _13_Observer
{
    /// Bu patternin amacı, kendisine abone olan sistemleri, bir işlem olduğunda devreye girmesinin sağlanmasıdır.
    /// Mesela alışveriş sitesinde ürün fiyatı düşünce haberdar edilmesi gibi.
    class Program
    {
        static void Main(string[] args)
        {
            var customerObserver = new CustomerObserver();
            ProductManager productManager = new ProductManager();
            productManager.Attach(customerObserver);
            productManager.Attach(new EmployeeObserver());
            productManager.Detach(customerObserver);
            productManager.UpdatePrice();

            Console.ReadLine();
        }
    }

    class ProductManager
    {
        List<ObserverBase> _observers = new List<ObserverBase>();
        public void UpdatePrice()
        {
            Console.WriteLine("Product price changed");
            Notify();
        }

        public void Attach(ObserverBase observer)
        {
            _observers.Add(observer);
        }

        public void Detach(ObserverBase observer)
        {
            _observers.Remove(observer);
        }

        private void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
    }

    #region Inherited Classes
    class CustomerObserver : ObserverBase
    {
        public override void Update()
        {
            Console.WriteLine("Message to customer : Product price changed!");
        }
    }

    class EmployeeObserver : ObserverBase
    {
        public override void Update()
        {
            Console.WriteLine("Message to employee : Product price changed!");
        }
    }
    #endregion
}
