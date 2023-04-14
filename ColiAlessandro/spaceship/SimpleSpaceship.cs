using System.Data.Common;
using System;
namespace ColiAlessandro.spaceship
{
    public class SimpleSpaceship : ISpaceship
    {
        public bool Mortal{ private get ; set }
        public double Angle{ get ; private set }
        public PlayerId Id{ get ; private set }
        public CircleHitBox HitBox{ get ; private set }
        GraphicEntity GraphicComponent{ get ; }     //TODO: fagli restituire sempre un grafic component ( prob non vera impl)
        public double Speed{ get ; set }
        public bool Turning{private get ; set }

        private Position _position;
        private Position _lastPosition;

        private PowerUp? _powerUp;
        private bool _shield;

        private Direction _direction;
        private double _angle;

        private GameState _world;

        private readonly int _maxBullets;
        private readonly long _bulletRegenTime;
        private int _bullets;

        public SimpleSpaceship( Position startPosition; Direction startDirection;
                        double angle; GameState world; double speed;
                        int maxBullets; bool startingShield;
                        PlayerId id; long bulletRegenTime)
        {
            _position = startPosition;
            _lastPosition = startPosition;
            _direction = startDirection;
            _world = world;
            _shield = startingShield;
            _bulletRegenTime = bulletRegenTime;
            _angle = angle;
            _maxBullets = maxBullets;
            _bullets = maxBullets;
            Speed.set(speed);
            Id.set(id);
        }

        public void ResetPosition()
        {
            _position = _lastPosition;
        }
    
        Position GetPosition() => _position;

        bool EquipPowerUp(PowerUp pUp) => _powerUp = pUp;

        void Shoot(); //TODO

        bool Hit(); //TODO

        void Update(double time); //TODO

        void NewShield() => _shield = true;

        void RemovePowerUp(PowerUp pUp) {
            if( pUp == _powerUp ?? null)
            {
                _powerUp = null;
            }
        }
    }
}