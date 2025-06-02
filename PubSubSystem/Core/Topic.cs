using PubSubSystem.Interfaces;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace PubSubSystem.Core
{
    public class Topic : ITopic//, IDisposable
    {
        private readonly ConcurrentBag<ISubscriber> _subscribers = new ConcurrentBag<ISubscriber>();

        /*
         * Async implementation to support subscriber scale-ups 
        private readonly ConcurrentDictionary<ISubscriber, BlockingCollection<Message>> _subscriberQueue = new ConcurrentDictionary<ISubscriber, BlockingCollection<Message>>();
        private List<Task> _tasks = new List<Task>();
        private bool _disposed = false;
        private readonly CancellationTokenSource _cancellationTokenSource = new();
        */

        /*
        * Async implementation support for subscriber scale-ups 
        public void Dispose()
        {
            if (_disposed) return;

            _cancellationTokenSource.Cancel();

            foreach (var queue in _subscriberQueue.Values)
            {
                queue.CompleteAdding();
            }

            Task.WaitAll(_tasks.ToArray());

            foreach (var queue in _subscriberQueue.Values)
            {
                queue.Dispose();
            }

            _cancellationTokenSource.Dispose();
            _disposed = true;
        }
        */

        public void AddSubscriber(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);

            /*
             * Async implementation support for subscriber scale-ups 

            var queue = new BlockingCollection<Message>(boundedCapacity: 100);

            _subscriberQueue.GetOrAdd(subscriber, queue);

            _tasks.Add(Task.Run(() => Consume(subscriber, queue)));
           */
        }

        public void Removesubscriber(ISubscriber subscriber)
        {
            _subscribers.TryTake(out subscriber);

            /*
             * Async implementation support for subscriber scale-ups 

            _subscriberQueue.TryRemove(subscriber, out var queue);
            */
        }

        // This is the basic synchronous implementation of Publish method.
        public void Publish(Message message)
        {
            foreach (var subscriber in _subscribers)
            {
                if (subscriber.ShouldReceiveMessage(message))
                {
                    subscriber.ReceiveMessage(message);
                }
            }

            /*
             * Async implementation support for subscriber scale-ups 
            foreach (var kvp in _subscriberQueue)
            {
                if (kvp.Value.TryAdd(message))
                {
                    Console.WriteLine($"Successfully published message with id {message.Id} to {kvp.Key.GetType().Name} queue.");
                }
                else
                {
                    Console.WriteLine($"Dropping message with id {message.Id} for {kvp.Key.GetType().Name}.");
                }
            }
            */
        }

        /*
        * Async implementation support for subscriber scale-ups 
        private void Consume(ISubscriber subscriber, BlockingCollection<Message> queue)
        {
            try
            {
                foreach (var message in queue.GetConsumingEnumerable())
                {
                    subscriber.ReceiveMessage(message);
                    Console.WriteLine($"Successfully send message with id {message.Id} to {subscriber.GetType().Name}.");
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine($"Consumer for {subscriber} cancelled.");
            }
        }
        */
    }
}
