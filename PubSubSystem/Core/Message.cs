namespace PubSubSystem.Core
{
    public class Message
    {
        public Guid Id { get;} = Guid.NewGuid();
        public string Content { get; } = string.Empty;
        public DateTime Timestamp { get; } = DateTime.UtcNow;

        public Message(string content)
        {
            Content = content;
        }

        public override string ToString()
        {
            return $"Message ID: {Id}, Content: {Content}, Timestamp: {Timestamp}";
        }
    }
}
