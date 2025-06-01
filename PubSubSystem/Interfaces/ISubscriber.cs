using PubSubSystem.Core;

namespace PubSubSystem.Interfaces
{
    public interface ISubscriber
    {
        void ReceiveMessage(Message message);
    }
}
