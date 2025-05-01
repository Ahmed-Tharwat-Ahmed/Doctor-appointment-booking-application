namespace App.Shared.Domain
{

    public interface IEventBus
    {
        // Method to subscribe to an event with a callback
        void Subscribe<T>(object owner, Action<T> callback);

        // Method to unsubscribe all events associated with an owner
        void Unsubscribe(object owner);

        // Method to push an event to the event bus asynchronously
        Task Push<T>(T @event);
    }

}
