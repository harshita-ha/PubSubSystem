using PubSubSystem.Interfaces;

namespace PubSubSystem.Core
{
    public class Publisher
    {
        private readonly HashSet<ITopic> _topic = new HashSet<ITopic>();
        
        public void RegisterTopic(ITopic topic)
        {
            _topic.Add(topic);
        }

        public void PublishMessage(string content)
        {
            var message = new Message(content);

            Console.WriteLine($"[PUBLISHER] Published message: {message.ToString()}.");

            foreach (var topic in _topic)
            {
                topic.Publish(message);
            }
        }
    }
}
