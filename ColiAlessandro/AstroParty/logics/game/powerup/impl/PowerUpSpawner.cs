using System.Collections.Generic;
using System.Timers;
using System;
using System.Linq;

namespace AstroParty
{
    public class PowerUpSpawner : IPowerUpSpawner
    {
        private readonly List<EntityType> _possiblePowerUpTypes;
        private readonly long _spawnDelay;
        private IGameState _world; 
        private readonly IPowerUpFactory _pUPfactory = new PowerUpFactory();
        private Timer _timer = new System.Timers.Timer();
        private Random _random = new Random();


        /// <param name= possiblePowerUpTypes> a collection of the possible types of PowerUPs. </param>
        /// <param name= spawnDelay the delay> between spawns.</param>
        public PowerUpSpawner( List<EntityType> possiblePowerUpTypes, long spawnDelay)
        {
            _possiblePowerUpTypes = new List<EntityType>( possiblePowerUpTypes );
            _spawnDelay = spawnDelay;
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void Start(IGameState world)
        {
            _world = world;
            _timer.Interval = _spawnDelay;
            _timer.AutoReset = true;
            _timer.Elapsed += ( sender, e ) => Generate();
            _timer.Start();
        }

        ///<summary>
        /// creates and adds a new powerUp to the world.
        ///</summary>
        private void Generate()
        {
            //System.out.println("spawn");
            if (this.world != null && this.world.GetPowerUps().size() < PowerUp.MAX_ON_SCREEN) {
                this.world.AddPowerUp(this.pUPfactory.CreatePowerUp(this.GenerateType(), this.GeneratePos()));
            }
        }
        
        ///<summary>
        // generate the type of the new Power Up between the active ones in the world.
        ///</summary>
        /// <return> the {@link PowerUpTypes} </return>
        private EntityType GenerateType()
        {
            int rand = random.NextInt64(_possiblePowerUpTypes.Count);
            return _possiblePowerUpTypes.ElementAt(rand);
        }

        ///<summary>
        // generates a possible {@link Position} for the new PowerUp.
        ///</summary>
        /// <return> the position </return>
        private Position GeneratePos()
        {

            Position pos;

            do {
                pos = new Position(random.nextDouble(IGameState.WIDTH - IPowerUp.RELATIVE_SIZE * 2) + IPowerUp.RELATIVE_SIZE,
                        random.nextDouble(IGameState.HEIGHT - IPowerUp.RELATIVE_SIZE * 2) + IPowerUp.RELATIVE_SIZE);

            } while (canExist(pos));

            return pos;
        }

        private bool canExist(Position position)
        {
            CircleHitBox hbox = new CircleHitBoxImpl(position, PowerUp.RELATIVE_SIZE); //TODO ?
            return  this.world.getEntities().stream()
                    .map(entity -> entity.getHitBox())
                    .anyMatch(e -> e.checkCollision(hbox));
    }
    }
}