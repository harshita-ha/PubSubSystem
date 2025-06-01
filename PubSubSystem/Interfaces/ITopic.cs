using PubSubSystem.Core;

namespace PubSubSystem.Interfaces
{
    public interface ITopic
    {
        void AddSubscriber(ISubscriber subscriber);
        void Removesubscriber(ISubscriber subscriber);
        void Publish(Message message);
    }
}
