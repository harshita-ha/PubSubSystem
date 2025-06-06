﻿using PubSubSystem.Core;
using PubSubSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubSystem.Subscribers
{
    public class FileSubscriber : ISubscriber
    {
        private string _filePath;

        public FileSubscriber(string filePath)
        {
            _filePath = filePath;
        }
        
        public void ReceiveMessage(Core.Message message)
        {
            File.WriteAllText(_filePath, message.ToString());
            Console.WriteLine($"Published message: {message.ToString()} to file.");
        }


        /*
        * Extension following DIP 
        */
        public bool ShouldReceiveMessage(Message message)
        {
            return message.Content.Contains("error", StringComparison.OrdinalIgnoreCase);
        }
    }
}
