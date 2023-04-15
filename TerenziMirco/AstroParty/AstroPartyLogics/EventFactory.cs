using ExtraAPI;
namespace AstroPartyLogics
{
    /// <summary>
    /// IEventFactory implementation.
    /// </summary>
    public class EventFactory : IEventFactory
    {

        /// <inheritdoc />
        public IEvent SpaceshipColliedEvent(ISpaceship spaceship)
            => new Event(state => spaceship.ResetPosition());

        /// <inheritdoc />
        public IEvent ProjectileHitEvent(IProjectile projectile)
            => new Event(state =>
                {
                    if (projectile.Hit())
                    {
                        state.RemoveProjectile(projectile);
                    }
                });

        /// <inheritdoc />
        public IEvent ObstacleHittedEvent(IObstacle obstacle)
            => new Event(state =>
                {
                    if (obstacle.Hit())
                    {
                        state.RemoveObstacle(obstacle);
                    }
                });

        /// <inheritdoc />
        public IEvent SpaceshipHittedEvent(ISpaceship spaceship)
            => new Event(state =>
                {
                    if (spaceship.Hit())
                    {
                        state.RemoveSpaceship(spaceship);
                    }
                });

        /// <inheritdoc />
        public IEvent PowerUpEquipEvent(IPowerUp powerUp, ISpaceship spaceship)
            => new Event(state =>
                {
                    if (spaceship.EquipPowerUp(powerUp))
                    {
                        state.RemovePowerUp(powerUp);
                    }
                });
    }
}