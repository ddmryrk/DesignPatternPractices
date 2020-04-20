using _11_Bridge.AbstractClasses;
using System;

namespace _11_Bridge
{
    /// Bu desende amaç bir nesnenin içinde soyutlanabilir kısımların soyutlanmasıdır.
    /// Logic ve nesnelerin yönetimi için daha temiz bir yapı sunar.
    class Bridge
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.MessageSenderBase = new SmsSender();
            customerManager.UpdateCustomer();
            Console.ReadLine();
        }
    }

    class CustomerManager
    {
        public MessageSenderBase MessageSenderBase { get; set; }

        public void UpdateCustomer()
        {
            MessageSenderBase.Send(new Body { Title = "About the course!" });
            Console.WriteLine("Customer updated");
        }
    }

    #region Inherited Classes
    class SmsSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via SmsSender", body.Title);
        }
    }

    class EmailSender : MessageSenderBase
    {
        public override void Send(Body body)
        {
            Console.WriteLine("{0} was sent via EmailSender", body.Title);
        }
    }
    #endregion
}
