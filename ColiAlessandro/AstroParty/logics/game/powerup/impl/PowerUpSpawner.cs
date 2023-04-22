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
            if (_world != null && _world.GetPowerUps().Count < IPowerUp.MAX_ON_SCREEN) {
                _world.AddPowerUp(_pUPfactory.CreatePowerUp(GenerateType(), GeneratePos()));
            }
        }
        
        ///<summary>
        // generate the type of the new Power Up between the active ones in the world.
        ///</summary>
        /// <return> the {@link PowerUpTypes} </return>
        private EntityType GenerateType()
        {
            int rand = _random.Next(_possiblePowerUpTypes.Count);
            return _possiblePowerUpTypes.ElementAt(rand);
        }

        ///<summary>
        // generates a possible {@link Position} for the new PowerUp.
        ///</summary>
        /// <return> the position </return>
        private Position GeneratePos()
        {

            Position pos;
            double rand;
            double x , y ;

            do {

                rand = _random.NextDouble();
                x = rand * (IGameState.WIDTH - IPowerUp.RELATIVE_SIZE * 2);
                
                rand = _random.NextDouble();
                y = rand * (IGameState.HEIGHT - IPowerUp.RELATIVE_SIZE * 2);

                pos = new Position(x + IPowerUp.RELATIVE_SIZE,
                                    y + IPowerUp.RELATIVE_SIZE);

            } while (canExist(pos));

            return pos;
        }

        private bool canExist(Position position)
        {
            return true;
            // outside needed methods are not implemented in c# inside astroparty
        }
    }
}