namespace AstroPartyLogics
{
    /// <summary>Interface that models a game event.</summary>
    public interface IEvent
    {

        /// <summary>Called for manage the event occurred.</summary>
        /// <param name="state">The current game state.</param>
        void manage(IGameState state);

    }
}