using PubSubSystem.Interfaces;
using System.Collections.Concurrent;

namespace PubSubSystem.Core
{
    public class Topic : ITopic
    {
        private readonly ConcurrentBag<ISubscriber> _subscribers = new ConcurrentBag<ISubscriber>();
        public void AddSubscriber(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }
        public void Removesubscriber(ISubscriber subscriber)
        {
            _subscribers.TryTake(out subscriber);
        }
        public void Publish(Message message)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.ReceiveMessage(message);
            }
        }
    }
}
