namespace AstroPartyLogics
{
    /// <summary>Observer interface from Observer pattern.</summary>
    public interface Observer {

        /// <summary>Notify the observer of the new event.</summary>
        /// <param name="e">The event that has occurred.</param>
        void notify(IEvent e);
    }
}