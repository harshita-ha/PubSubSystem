using PubSubSystem.Core;
using PubSubSystem.Interfaces;

namespace PubSubSystem
{
    public class PubSubDemo
    {
        public void Run()
        {
            Console.WriteLine("Init PubSubDemo...");

            ISubscriber logSubscriber = new Subscribers.LogSubscriber();
            ISubscriber fileSubscriber = new Subscribers.FileSubscriber("C:\\Users\\hhazarika\\source\\repos\\LLDs\\PubSubSystem\\fileSubsriberLog.txt");

            ITopic topic = new Core.Topic();

            Publisher publisher = new Publisher();

            publisher.RegisterTopic(topic);

            topic.AddSubscriber(logSubscriber);
            topic.AddSubscriber(fileSubscriber);

            publisher.PublishMessage("[debug] Harshita's first Pub-Sub System created!");
            publisher.PublishMessage("[ERROR] Harshita's first Pub-Sub System created!");

            //Thread.Sleep(1000);
        }
    }
}
