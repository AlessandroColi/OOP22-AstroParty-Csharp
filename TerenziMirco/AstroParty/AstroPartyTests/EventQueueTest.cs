namespace AstroPartyTests;

[TestClass]
public class EventQueueTest
{
    private readonly CollisionEventQueue _queue = new CollisionEventQueue();
    private readonly IGameState _state = new GameState();
    
    private class EventExampleAddSpaceship : IEvent
    {
        public void Manage(IGameState state) => state.AddSpaceship(new Spaceship());
    }

    [TestMethod]
    public void Test()
    {
        _queue.Notify(new EventExampleAddSpaceship());
        _queue.Notify(new EventExampleAddSpaceship());
        _queue.ManageEvents(_state);
        Assert.AreEqual(_state.Spaceships.Count, 2);
        _queue.Notify(new EventExampleAddSpaceship());
        _queue.Notify(new EventExampleAddSpaceship());
        _queue.Notify(new EventExampleAddSpaceship());
        _queue.ManageEvents(_state);
        Assert.AreEqual(_state.Spaceships.Count, 5);
    }
}