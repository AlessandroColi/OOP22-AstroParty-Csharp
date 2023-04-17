namespace AstroPartyTests;

[TestClass]
public class EventQueueTest
{
    private readonly CollisionEventQueue _queue = new CollisionEventQueue();
    private readonly IGameState _state = new GameState();

    [TestMethod]
    public void TestQueue()
    {
        IEvent eventExample = new Event(state => state.AddSpaceship(new Spaceship()));
        _queue.Notify(eventExample);
        _queue.Notify(eventExample);
        _queue.ManageEvents(_state);
        Assert.AreEqual(_state.Spaceships.Count, 2);
        _queue.Notify(eventExample);
        _queue.Notify(eventExample);
        _queue.Notify(eventExample);
        _queue.ManageEvents(_state);
        Assert.AreEqual(_state.Spaceships.Count, 5);
    }
}