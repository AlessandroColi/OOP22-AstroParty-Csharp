namespace AstroPartyTests;

[TestClass]
public class GameStateTest
{
    private class ObserverExample : IObserver
    {
        public Queue<IEvent> Queue { get; }

        public ObserverExample() => Queue = new Queue<IEvent>();

        public void Notify(IEvent e)
        {
            Queue.Enqueue(e);
        }
    }

    [TestMethod]
    public void TestSpaceships()
    {
        var state = new GameState();
        Assert.AreEqual(state.Spaceships.Count, 0);

        var s1 = new Spaceship();
        var s2 = new Spaceship();
        state.AddSpaceship(s1);
        state.AddSpaceship(s2);
        Assert.AreEqual(state.Spaceships.Count, 2);
        Assert.IsFalse(state.IsOver());

        state.RemoveSpaceship(s1);
        Assert.AreEqual(state.Spaceships.Count, 1);
        Assert.IsTrue(state.IsOver());

    }

    [TestMethod]
    public void TestObstacles()
    {
        var state = new GameState();
        Assert.AreEqual(state.Obstacles.Count, 0);

        var o1 = new Obstacle();
        var o2 = new Obstacle();
        state.AddObstacle(o1);
        state.AddObstacle(o2);
        Assert.AreEqual(state.Obstacles.Count, 2);

        state.RemoveObstacle(o1);
        Assert.AreEqual(state.Obstacles.Count, 1);
    }

    [TestMethod]
    public void TestProjectiles()
    {
        var state = new GameState();
        Assert.AreEqual(state.Projectiles.Count, 0);

        var p1 = new Projectile();
        var p2 = new Projectile();
        state.AddProjectile(p1);
        state.AddProjectile(p2);
        Assert.AreEqual(state.Projectiles.Count, 2);

        state.RemoveProjectile(p1);
        Assert.AreEqual(state.Projectiles.Count, 1);
    }

    [TestMethod]
    public void TestPowerUp()
    {
        var state = new GameState();
        Assert.AreEqual(state.PowerUps.Count, 0);

        var p1 = new PowerUp();
        var p2 = new PowerUp();
        state.AddPowerUp(p1);
        state.AddPowerUp(p2);
        Assert.AreEqual(state.PowerUps.Count, 2);

        state.RemovePowerUp(p1);
        Assert.AreEqual(state.PowerUps.Count, 1);
    }

    [TestMethod]
    public void TestAllEntities()
    {
        var state = new GameState();
        Assert.AreEqual(state.Entities.Count, 0);

        var p1 = new PowerUp();
        var s1 = new Spaceship();
        state.AddPowerUp(p1);
        state.AddSpaceship(s1);
        Assert.AreEqual(state.Entities.Count, 2);

        var s2 = new Spaceship();
        state.AddSpaceship(s2);
        state.RemoveSpaceship(s1);
        Assert.AreEqual(state.Entities.Count, 2);

        state.RemovePowerUp(p1);
        Assert.AreEqual(state.Entities.Count, 1);
    }

    [TestMethod]
    public void TestObservable()
    {
        var state = new GameState();
        var observer = new ObserverExample();
        IEvent eventExample = new Event(_ => Console.WriteLine("EventExample"));
        state.RegisterObserver(observer);
        state.NotifyObservers(eventExample);
        Assert.AreEqual(observer.Queue.Count, 1);
        state.NotifyObservers(eventExample);
        state.NotifyObservers(eventExample);
        Assert.AreEqual(observer.Queue.Count, 3);
    }
}