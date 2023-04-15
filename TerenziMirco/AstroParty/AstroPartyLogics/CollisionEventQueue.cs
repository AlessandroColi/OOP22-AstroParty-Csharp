namespace AstroPartyLogics
{
    public class CollisionEventQueue : IObserver
    {
        private readonly Queue<IEvent> _queue;

        public CollisionEventQueue() => _queue = new Queue<IEvent>();

        /// <inheritdoc />
        public void notify(IEvent e)
        {
            _queue.Enqueue(e);
        }

        /// <summary>Manages all the events in the queue.</summary>
        /// <param name="state">The current state of the game world.</param>
        public void manageEvents(IGameState state)
        {
            while (_queue.Count > 0)
            {
                _queue.Dequeue().manage(state);
            }
        }
    }
}