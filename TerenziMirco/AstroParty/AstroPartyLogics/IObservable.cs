namespace AstroPartyLogics
{
    /// <summary>Subject interface from observer pattern.</summary>
    public interface Observable {

        /// <param name="observer">The observer to be added.</param>
        void registerObserver(Observer observer);

        /// <param name="observer">The observer to be removed.</param>
        void unregisterObserver(Observer observer);

        /// <summary>Tells to all the observers that an event has occurred.</summary>
        /// <param name="e">The event that has occurred.</param>
        void notifyObservers(IEvent e);
    }
}