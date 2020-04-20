using _04_Prototype.AbstractClasses;
using System;

namespace _04_Prototype
{
    class Prototype
    {
        /// Bu desenin amacı nesne üretim maliyetlerini miminumuma indirmektir.
        /// Klonlamayı .net'in MemberwiseClone metodu sağlıyor.
        static void Main(string[] args)
        {
            Customer customer1 = new Customer { FirstName = "Engin", LastName = "Demiroğ", City = "Ankara", Id = 1 };


            Customer customer2 = (Customer)customer1.Clone();
            customer2.FirstName = "Salih";

            Console.WriteLine(customer1.FirstName);
            Console.WriteLine(customer2.FirstName);

            Console.ReadLine();
        }
    }

    public class Customer : Person
    {
        public string City { get; set; }


        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }


        public override Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
