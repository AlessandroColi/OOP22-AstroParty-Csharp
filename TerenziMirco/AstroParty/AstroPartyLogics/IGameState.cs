using ExtraAPI;
namespace AstroPartyLogics
{
    /// <summary>Interface that models the state of the game.</summary>
    public interface IGameState
    {
        /// <summary>The height of the map.</summary>
        const double HEIGHT = 100.0;

        /// <summary>The width of the map.</summary>
        const double WIDTH = 100.0;

        /// <summary>Y coordinates of the top of the game world.</summary>
        const double UPPER_SIDE = 0;

        /// <summary>Y coordinates of the bottom of the game world.</summary>
        const double LOWER_SIDE = UPPER_SIDE + HEIGHT;

        /// <summary>X coordinates of the left part of the game world.</summary>
        const double LEFT_SIDE = 0;

        /// <summary>X coordinates of the right part of the game world.</summary>
        const double RIGHT_SIDE = LEFT_SIDE + WIDTH;

        /// <returns>A collection of all the entities in the game</returns>
        ICollection<IEntity> getEntities();

        /// <value>Collection of all the spaceship in the game</value>
        ICollection<ISpaceship> Spaceships { get; }

        /// <value>Collection of all the obstacles in the game</value>
        ICollection<IObstacle> Obstacles { get; }

        /// <value>Collection of all the projectiles in the game</value>
        ICollection<IProjectile> Projectiles { get; }

        /// <value>Collection of all the power-ups in the game</value>
        ICollection<IPowerUp> PowerUps { get; }

        /// <summary>Called to update the position and status of all the entities in the map
        /// and manage their interactions.</summary>
        /// <param name="time">The time elapsed from the last update.</param>
        void update(double time);

        /// <returns>True if the game is over, otherwise false.</param>
        bool isOver();

        /// <param name="spaceship">The spaceship to be added.</param>
        void addSpaceship(ISpaceship spaceship);

        /// <param name="obstacle">The obstacle to be added.</param>
        void addObstacle(IObstacle obstacle);

        /// <param name="projectile">The projectile to be added.</param>
        void addProjectile(IProjectile projectile);

        /// <param name="powerUp">The power-up to be added.</param>
        void addPowerUp(IPowerUp powerUp);

        /// <param name="spaceship">The spaceship to be removed.</param>
        void removeSpaceship(ISpaceship spaceship);

        /// <param name="obstacle">The obstacle to be removed.</param>
        void removeObstacle(IObstacle obstacle);

        /// <param name="projectile">The projectile to be removed.</param>
        void removeProjectile(IProjectile projectile);

        /// <param name="powerUp">The power-up to be removed.</param>
        void removePowerUp(IPowerUp powerUp);
    }
}