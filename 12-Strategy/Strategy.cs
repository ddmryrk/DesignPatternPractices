using _12_Strategy.AbstractClasses;
using System;

namespace _12_Strategy
{
    /// Bu patternin amacı belirli bir strateji belirleyip o stratejinin uygulanması amacı ile kullanılır.
    /// Örneğin iş katmanında belirli şartlar altında ayrı kurguların çalıştırılması sağlanabilir
    class Strategy
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();

            customerManager.CreditCalculatorBase = new After2010CreditCalculator();
            customerManager.SaveCredit();

            customerManager.CreditCalculatorBase = new Before2010CreditCalculator();
            customerManager.SaveCredit();
            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }

        public void SaveCredit()
        {
            Console.WriteLine("Customer manager business");
            CreditCalculatorBase.Calculate();

        }
    }

    #region Inherited Classes
    class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using before2010");
        }
    }

    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using after2010");
        }
    }
    #endregion
}
