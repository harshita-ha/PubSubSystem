using PubSubSystem.Core;
using PubSubSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubSystem.Subscribers
{
    public class LogSubscriber : ISubscriber
    {
        public void ReceiveMessage(Core.Message message)
        {
            // Log the message to the console
            Console.WriteLine($"LogSubscriber received message: {message.ToString()}");
        }

        /*
        * Extension following DIP 
        */
        public bool ShouldReceiveMessage(Message message)
        {
            return message.Content.Contains("debug", StringComparison.OrdinalIgnoreCase);
        }
    }
}
