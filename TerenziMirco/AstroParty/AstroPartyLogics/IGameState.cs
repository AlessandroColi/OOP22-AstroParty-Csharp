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

        /// <value>Collection of all the spaceship in the game</value>
        ICollection<ISpaceship> Spaceships { get; }

        /// <value>Collection of all the obstacles in the game</value>
        ICollection<IObstacle> Obstacles { get; }

        /// <value>Collection of all the projectiles in the game</value>
        ICollection<IProjectile> Projectiles { get; }

        /// <value>Collection of all the power-ups in the game</value>
        ICollection<IPowerUp> PowerUps { get; }

        /// <value>Collection of all the entities in the game</value>
        ICollection<IEntity> Entities { get; }

        /// <summary>Called to update the position and status of all the entities in the map
        /// and manage their interactions.</summary>
        /// <param name="time">The time elapsed from the last update.</param>
        void Update(double time);

        /// <returns>True if the game is over, otherwise false.</param>
        bool IsOver();

        /// <param name="spaceship">The spaceship to be added.</param>
        void AddSpaceship(ISpaceship spaceship);

        /// <param name="obstacle">The obstacle to be added.</param>
        void AddObstacle(IObstacle obstacle);

        /// <param name="projectile">The projectile to be added.</param>
        void AddProjectile(IProjectile projectile);

        /// <param name="powerUp">The power-up to be added.</param>
        void AddPowerUp(IPowerUp powerUp);

        /// <param name="spaceship">The spaceship to be removed.</param>
        void RemoveSpaceship(ISpaceship spaceship);

        /// <param name="obstacle">The obstacle to be removed.</param>
        void RemoveObstacle(IObstacle obstacle);

        /// <param name="projectile">The projectile to be removed.</param>
        void RemoveProjectile(IProjectile projectile);

        /// <param name="powerUp">The power-up to be removed.</param>
        void RemovePowerUp(IPowerUp powerUp);
    }
}