using ExtraAPI;
namespace AstroPartyLogics
{
    /// <summary>
    /// IEventFactory implementation.
    /// </summary>
    public class EventFactory : IEventFactory
    {

        /// <inheritdoc />
        public IEvent spaceshipColliedEvent(ISpaceship spaceship)
            => new Event(state => spaceship.resetPosition());

        /// <inheritdoc />
        public IEvent projectileHitEvent(IProjectile projectile)
            => new Event(state =>
                {
                    if (projectile.hit())
                    {
                        state.removeProjectile(projectile);
                    }
                });

        /// <inheritdoc />
        public IEvent obstacleHittedEvent(IObstacle obstacle)
            => new Event(state =>
                {
                    if (obstacle.hit())
                    {
                        state.removeObstacle(obstacle);
                    }
                });

        /// <inheritdoc />
        public IEvent spaceshipHittedEvent(ISpaceship spaceship)
            => new Event(state =>
                {
                    if (spaceship.hit())
                    {
                        state.removeSpaceship(spaceship);
                    }
                });

        /// <inheritdoc />
        public IEvent powerUpEquipEvent(IPowerUp powerUp, ISpaceship spaceship)
            => new Event(state =>
                {
                    if (spaceship.equipPowerUp(powerUp))
                    {
                        state.removePowerUp(powerUp);
                    }
                });
    }
}