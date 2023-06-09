namespace AstroPartyLogics
{
    /// <summary>Observer interface from Observer pattern.</summary>
    public interface IObserver
    {
        /// <summary>Notify the observer of the new event.</summary>
        /// <param name="e">The event that has occurred.</param>
        void Notify(IEvent e);
    }
}