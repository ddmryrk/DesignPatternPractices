using _10_Decorator.AbstractClasses;
using System;

namespace _10_Decorator
{
    class Decorator
    {
        /// Bu pattern elde temel bir nesne mevcut iken bu nesneyi farklı koşullarda
        /// daha farklı anlamlar yüklemek için kullanılır.
        static void Main(string[] args)
        {
            var personalCar = new PersonalCar { Make = "BMW", Model = "3.20", HirePrice = 2500 };

            SpecialOffer specialOffer = new SpecialOffer(personalCar);
            specialOffer.DiscountPercentage = 10;

            Console.WriteLine("Concrete : {0}", personalCar.HirePrice);
            Console.WriteLine("Special offer : {0}", specialOffer.HirePrice);

            Console.ReadLine();
        }
    }

    #region Inherited Classes
    class PersonalCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : CarBase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }  

    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }
        private readonly CarBase _carBase;

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }

        public override decimal HirePrice
        {
            get { return _carBase.HirePrice - _carBase.HirePrice * DiscountPercentage / 100; }
            set { }
        }
    }
    #endregion
}
