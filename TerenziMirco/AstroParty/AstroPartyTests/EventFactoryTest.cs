namespace AstroPartyTests;

[TestClass]
public class EventFactoryTest
{

    private readonly IEventFactory _eventFactory = new EventFactory();
    private readonly IGameState _state = new GameState();

    [TestMethod]
    public void TestSpaceshipCollied()
    {
        Assert.IsNotNull(_eventFactory.SpaceshipColliedEvent(new Spaceship()));
    }
    
    [TestMethod]
    public void TestProjectileHit()
    {
        var projectile = new Projectile();
        _state.AddProjectile(projectile);
        Assert.AreEqual(_state.Entities.Count, 1);
        Assert.AreEqual(_state.Projectiles.Count, 1);

        var ev = _eventFactory.ProjectileHitEvent(projectile);
        Assert.IsNotNull(ev);

        ev.Manage(_state);
        Assert.AreEqual(_state.Entities.Count, 0);
        Assert.AreEqual(_state.Projectiles.Count, 0);
    }

    [TestMethod]
    public void TestObstacleHitted()
    {
        var obstacle = new Obstacle();
        _state.AddObstacle(obstacle);
        Assert.AreEqual(_state.Entities.Count, 1);
        Assert.AreEqual(_state.Obstacles.Count, 1);

        var ev = _eventFactory.ObstacleHittedEvent(obstacle);
        Assert.IsNotNull(ev);

        ev.Manage(_state);
        Assert.AreEqual(_state.Entities.Count, 0);
        Assert.AreEqual(_state.Obstacles.Count, 0);
    }

    [TestMethod]
    public void TestSpaceshipHitted()
    {
        var spaceship = new Spaceship();
        _state.AddSpaceship(spaceship);
        Assert.AreEqual(_state.Entities.Count, 1);
        Assert.AreEqual(_state.Spaceships.Count, 1);

        var ev = _eventFactory.SpaceshipHittedEvent(spaceship);
        Assert.IsNotNull(ev);

        ev.Manage(_state);
        Assert.AreEqual(_state.Entities.Count, 0);
        Assert.AreEqual(_state.Spaceships.Count, 0);
    }

    [TestMethod]
    public void TestPowerUpEquip()
    {
        Assert.IsNotNull(_eventFactory.PowerUpEquipEvent(new PowerUp(), new Spaceship()));
    }
}