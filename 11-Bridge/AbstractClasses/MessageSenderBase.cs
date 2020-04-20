using System;

namespace _11_Bridge.AbstractClasses
{
    public abstract class MessageSenderBase
    {
        public void Save()
        {
            Console.WriteLine("Message saved!");
        }

        public abstract void Send(Body body);
    }
}
