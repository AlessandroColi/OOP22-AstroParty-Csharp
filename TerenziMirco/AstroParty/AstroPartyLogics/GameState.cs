using ExtraAPI;

namespace AstroPartyLogics
{
    public class GameState : IGameState
    {
        /// <inheritdoc />
        public ICollection<ISpaceship> Spaceships { get; }

        /// <inheritdoc />
        public ICollection<IObstacle> Obstacles { get; }

        /// <inheritdoc />
        public ICollection<IProjectile> Projectiles { get; }

        /// <inheritdoc />
        public ICollection<IPowerUp> PowerUps { get; }
                
        /// <inheritdoc />
        public ICollection<IEntity> Entities
        {
            get
            {
                List<IEntity> worldEntities = new List<IEntity>();
                worldEntities.AddRange(Spaceships);
                worldEntities.AddRange(Obstacles);
                worldEntities.AddRange(Projectiles);
                worldEntities.AddRange(PowerUps);
                return worldEntities;
            }
            
        }

        /// <summary>Constructor for GameStateImpl.</summary>
        public GameState()
        {
            Spaceships = new List<ISpaceship>();
            Obstacles = new List<IObstacle>();
            Projectiles = new List<IProjectile>();
            PowerUps = new List<IPowerUp>();
        }


        /// <inheritdoc />
        public void AddSpaceship(ISpaceship spaceship) => Spaceships.Add(spaceship);

        /// <inheritdoc />
        public void AddObstacle(IObstacle obstacle) => Obstacles.Add(obstacle);

        /// <inheritdoc />
        public void AddProjectile(IProjectile projectile) => Projectiles.Add(projectile);

        /// <inheritdoc />
        public void AddPowerUp(IPowerUp powerUp) => PowerUps.Add(powerUp);

        /// <inheritdoc />
        public bool IsOver() => Spaceships.Count() == 1;

        /// <inheritdoc />
        public void RemoveSpaceship(ISpaceship spaceship) => Spaceships.Remove(spaceship);

        /// <inheritdoc />
        public void RemoveObstacle(IObstacle obstacle) => Obstacles.Remove(obstacle);

        /// <inheritdoc />
        public void RemoveProjectile(IProjectile projectile) => Projectiles.Remove(projectile);

        /// <inheritdoc />
        public void RemovePowerUp(IPowerUp powerUp) => PowerUps.Remove(powerUp);

        /// <inheritdoc />
        public void Update(double time)
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}