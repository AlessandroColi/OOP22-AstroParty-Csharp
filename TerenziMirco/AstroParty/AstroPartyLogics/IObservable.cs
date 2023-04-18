namespace AstroPartyLogics
{
    /// <summary>Subject interface from observer pattern.</summary>
    public interface IObservable
    {
        /// <param name="observer">The observer to be added.</param>
        void RegisterObserver(IObserver observer);

        /// <param name="observer">The observer to be removed.</param>
        void UnregisterObserver(IObserver observer);

        /// <summary>Tells to all the observers that an event has occurred.</summary>
        /// <param name="e">The event that has occurred.</param>
        void NotifyObservers(IEvent e);
    }
}