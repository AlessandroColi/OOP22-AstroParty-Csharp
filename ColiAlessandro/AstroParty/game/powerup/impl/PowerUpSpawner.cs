
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
            _timer.Start();
        }

        override vois Stop(){
            _timer.Stop();
        }

                /**
        * creates and adds a new powerUp to the world.
        */
        private void generate() {
            //System.out.println("spawn");
            if (this.world != null && this.world.getPowerUps().size() < PowerUp.MAX_ON_SCREEN) {
                this.world.addPowerUp(this.pUPfactory.createPowerUp(this.generateType(), this.generatePos()));
            }
        }
    //TODO: da qua in poi sono ancora su java e va tradotta
        /**
        * generate the type of the new Power Up between the active ones in the world.
        * @return the {@link PowerUpTypes}
        */
        private EntityType generateType() {

            final int rand = random.nextInt(this.possiblePowerUpTypes.size());
            final var it = this.possiblePowerUpTypes.iterator();

            for (int i = 0; i < rand; i++) {
                it.next();    //non controllo perche' ho preso un num minore di size quindi deve esserci qualcosa;
            }

            return it.next();
        }

        /**
        * generates a possible {@link Position} for the new PowerUp.
        * @return the position.
        */
        private Position generatePos() {

            Position pos;

            do {
                pos = new Position(random.nextDouble(GameState.WIDTH - PowerUp.RELATIVE_SIZE * 2) + PowerUp.RELATIVE_SIZE,
                        random.nextDouble(GameState.HEIGHT - PowerUp.RELATIVE_SIZE * 2) + PowerUp.RELATIVE_SIZE);

            } while (canExist(pos));

            return pos;
        }

        private boolean canExist(final Position position) {
            final CircleHitBox hbox = new CircleHitBoxImpl(position, PowerUp.RELATIVE_SIZE);
            return  this.world.getEntities().stream()
                    .map(entity -> entity.getHitBox())
                    .anyMatch(e -> e.checkCollision(hbox));
    }
    }
}