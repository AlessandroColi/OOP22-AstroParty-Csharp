using ExtraAPI;

namespace AstroPartyLogics
{
    public class GameState : IGameState, IObservable
    {
        private readonly IList<IObserver> _observers;
        private readonly IEventFactory _eventFactory;
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
            _observers = new List<IObserver>();
            _eventFactory = new EventFactory();
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
        public void RegisterObserver(IObserver observer) => _observers.Add(observer);

        /// <inheritdoc />
        public void UnregisterObserver(IObserver observer) => _observers.Remove(observer);

        /// <inheritdoc />
        public void NotifyObservers(IEvent e)
        {
            foreach (var observer in _observers)
            {
                observer.Notify(e);
            }
        }

        /// <inheritdoc />
        public void Update(double time)
        {
            foreach (var entity in Entities)
            {
                entity.Update(time);
            }

            CheckPlayerMovement();
            CheckProjectileInteractions();
            CheckSpaceshipInteractions();
        }

        private bool CheckBoundariesCollisions(IHitBox hb)
        {
            IPosition pos = hb.Center;
            double r = hb.Radius;

            return pos.X + r > IGameState.RIGHT_SIDE
                    || pos.X - r < IGameState.LEFT_SIDE
                    || pos.Y + r > IGameState.LOWER_SIDE
                    || pos.Y - r < IGameState.UPPER_SIDE;
        }

        private void CheckPlayerMovement()
        {
            foreach (var spaceship in Spaceships)
            {
                if (CheckBoundariesCollisions(spaceship.HitBox)
                    || Obstacles.Where(o => !o.IsHarmful())
                            .Any(e => e.HitBox.CheckCollision(spaceship.HitBox))
                    || Spaceships.Where(targetSpaceship => !targetSpaceship.Equals(spaceship))
                            .Any(e => e.HitBox.CheckCollision(spaceship.HitBox)))
                {
                    NotifyObservers(_eventFactory.SpaceshipColliedEvent(spaceship));
                }
            }
        }

        private bool CheckCollisionWith<E>(List<E> entities, IHitBox targetHB, Func<E, IEvent> eventGetter) where E : IEntity
        {
            List<E> hitted = entities.Where(e => e.HitBox.CheckCollision(targetHB)).ToList();
            if (hitted.Count == 0) return false;
            else
            {
                hitted.ForEach(e => NotifyObservers(eventGetter(e)));
                return true;
            }
        }
        private void CheckProjectileInteractions()
        {
            foreach (var p in Projectiles)
            {
                IHitBox hBox = p.HitBox;

                if (CheckBoundariesCollisions(hBox)
                    || CheckCollisionWith<ISpaceship>(
                        Spaceships.ToList(),
                        hBox,
                        e => _eventFactory.SpaceshipHittedEvent(e))
                    || CheckCollisionWith<IObstacle>(
                        Obstacles.ToList(),
                        hBox,
                        e => _eventFactory.ObstacleHittedEvent(e)))
                {
                    NotifyObservers(_eventFactory.ProjectileHitEvent(p));
                }
            }
        }
        
        private void CheckSpaceshipInteractions()
        {
            foreach (var s in Spaceships)
            {
                IHitBox hBox = s.HitBox;

                CheckCollisionWith<IPowerUp>(
                        PowerUps.ToList(),
                        hBox,
                        e => _eventFactory.PowerUpEquipEvent(e, s)
                    );

                CheckCollisionWith<IObstacle>(
                        Obstacles.Where(o => o.IsActive() && o.IsHarmful()).ToList(),
                        hBox,
                        _ => _eventFactory.SpaceshipHittedEvent(s)
                    );
            }
        }
    }
}