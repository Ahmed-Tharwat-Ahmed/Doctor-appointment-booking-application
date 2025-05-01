using System.Collections.Concurrent;

namespace App.Shared.Domain
{
    public class EventBus : IEventBus
    {
        // Internal storage for event listeners
        private readonly ConcurrentDictionary<object, List<IEventListener>> _listeners = new();

        // Thread-safe collection to manage tasks
        private readonly TaskFactory _taskFactory = new(TaskScheduler.Default);

        // Subscribe an owner to a specific event type with a callback
        public void Subscribe<T>(object owner, Action<T> callback)
        {
            if (!_listeners.ContainsKey(owner))
            {
                _listeners[owner] = new List<IEventListener>();
            }

            _listeners[owner].Add(new EventListener<T>(callback));
        }

        // Unsubscribe all events associated with a specific owner
        public void Unsubscribe(object owner)
        {
            _listeners.TryRemove(owner, out _);
        }

        // Push an event to the bus, invoking all relevant callbacks
        public async Task Push<T>(T @event)
        {
            var tasks = new List<Task>();

            foreach (var listenerGroup in _listeners.Values)
            {
                foreach (var listener in listenerGroup)
                {
                    if (listener is EventListener<T> typedListener)
                    {
                        // Execute the callback asynchronously
                        tasks.Add(_taskFactory.StartNew(() => typedListener.Handle(@event)));
                    }
                }
            }

            await Task.WhenAll(tasks);
        }

        // Interface for event listeners
        private interface IEventListener { }

        // Implementation of a generic event listener
        private class EventListener<T> : IEventListener
        {
            private readonly Action<T> _callback;

            public EventListener(Action<T> callback)
            {
                _callback = callback;
            }

            // Invoke the callback with the provided event
            public void Handle(T @event)
            {
                _callback(@event);
            }
        }
    }
}
