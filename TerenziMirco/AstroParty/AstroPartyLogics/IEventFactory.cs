namespace AstroPartyLogics
{
    /// <summary>
    /// Factory interface from simple factory pattern that handles events creation.
    /// </summary>
    public interface EventFactory {

        /// <summary>Create a new event for a spaceship collision.</summary>
        /// <param name="spaceship">The spaceship that collied</param>
        /// <returns>The created event.</returns>
        IEvent spaceshipColliedEvent(ISpaceship spaceship);

        /// <summary>Creates a new event for a projectile collision.</summary>
        /// <param name="projectile">The projectile that hit.</param>
        /// <returns>The created event.</returns>
        IEvent projectileHitEvent(IProjectile projectile);

        /// <summary>Create a new event for an obstacle hitted.</summary>
        /// <param name="obstacle">The obstacle that was hit</param>
        /// <returns>The created event.</returns>
        IEvent obstacleHittedEvent(IObstacle obstacle);

        /// <summary>Create a new event for a spaceship hitted.</summary>
        /// <param name="spaceship">The spaceship that was hit</param>
        /// <returns>The created event.</returns>
        IEvent spaceshipHittedEvent(ISpaceship spaceship);

        /// <summary>Create a new event for a spaceship equipping a power-up.</summary>
        /// <param name="powerUp">The power-up that was equipped.</param>
        /// <param name="spaceship">The spaceship that equipped the power-up.</param>
        /// <returns>The created event.</returns>
        IEvent powerUpEquipEvent(IPowerUp powerUp, ISpaceship spaceship);
    }
}