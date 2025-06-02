using PubSubSystem.Core;

namespace PubSubSystem.Interfaces
{
    public interface ISubscriber
    {
        void ReceiveMessage(Message message);

        bool ShouldReceiveMessage(Message message);
    }
}
