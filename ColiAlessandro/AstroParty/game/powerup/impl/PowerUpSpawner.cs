
namespace ColiAlessandro.AstroParty.game.powerup.impl
{
    public class PowerUpSpawner : IPowerUpSpawner
    {
        private readonly Collection<EntityType> _possiblePowerUpTypes;
        private readonly long _spawnDelay;
        private IGameState _world; 
        private readonly IPowerUpFactory _pUPfactory = new PowerUpFactory();
        private Timer _timer = new System.Timers.Timer();


        /// <param name= possiblePowerUpTypes> a collection of the possible types of PowerUPs. </param>
        /// <param name= spawnDelay the delay> between spawns.</param>
        public PowerUpSpawnerImpl(Collection<EntityType> possiblePowerUpTypes, long spawnDelay) {
            _possiblePowerUpTypes = new Collection<EntityType>( possiblePowerUpTypes );
            _spawnDelay = spawnDelay;
        }

        override void Start(final GameState world) {
            _world = world;
            _timer.Interval = _spawnDelay;
            _timer.AutoReset = true;
            _timer.Elapsed += ( sender, e ) => Generate();
            _timer.start();
        }
    }
}