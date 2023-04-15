namespace AstroPartyLogics
{
    /// <summary>Implementation of IEvent interface.</summary>
    public class Event : IEvent
    {
        private Action<IGameState> _manageAction;

        public Event(Action<IGameState> manageAction)
        {
            _manageAction = manageAction;
        }

        public void Manage(IGameState state)
        {
            _manageAction(state);
        }
    }
}