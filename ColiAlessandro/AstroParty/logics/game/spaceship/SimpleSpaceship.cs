using System.Timers;
using System;
namespace AstroParty
{
    public class SimpleSpaceship : ISpaceship
    {

        private Position _position;
        private Position _lastPosition;

        private IPowerUp _powerUp;
        private bool _shield;
        private bool _immortal;

        private Direction _direction;
        private double _angle;

        private IGameState _world;

        private readonly int _maxBullets;
        private readonly long _bulletRegenTime;
        private int _bullets;
        private bool _recharging;
        private Timer _timer = new System.Timers.Timer();

        public bool Mortal{ get => !(_immortal || _shield); 
                            set => _immortal = value ; }
        public double Angle{ get ; private set; }
        public PlayerId Id{ get ; private set; }
        public EntityType Type { get => EntityType.SPACESHIP; }
        public IGraphicEntity GraphicComponent{ 
            get {
                var ret = new GraphicEntity(_position, ISpaceship.RELATIVE_SIZE, EntityType.SPACESHIP);
                ret.Angle = _angle;
                ret.Id = Id;
                return ret;
            } }    
        public double Speed{ get ; set; }
        public bool Turning{ get ; set; }

        public SimpleSpaceship( Position startPosition, Direction startDirection,
                        double angle, IGameState world, double speed,
                        int maxBullets, bool startingShield,
                        PlayerId id, long bulletRegenTime)
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
            Speed = speed ;
            Id = id;

            // set timer proprieties
            _timer.Interval = _bulletRegenTime;
            _timer.AutoReset = false;
            _timer.Elapsed += ( sender, e ) => AddBullet();
        }

        public void ResetPosition()
        {
            _position = _lastPosition;
        }
    
        public Position GetPosition() => _position;

        public bool EquipPowerUp(IPowerUp pUp)
        {
            if ( _powerUp == null)
            {
                _powerUp = pUp;
                return true;
            }
            return false;
        }

        public void Shoot()
        {
            if( _bullets == 0)
            {
                return;
            }

            if( _powerUp.Offensive ){
                // switch for future implementations of other powerUps
                switch ( _powerUp.Type )    
                {
                    case EntityType.DOUBLESHOT:
                    {
                        CreateProjectile();
                        CreateProjectile();
                        break;
                    }

                    default: 
                        throw new ArgumentException("Type not possible");
                }

            }else{
                CreateProjectile();
            }
            StartTimer();
        }

        public bool Hit()
        {
            if( !Mortal )
            {
                return false;
            }
            if( _shield ){
                _shield =  false;
                return false;
            }
            return true;
        }

        public void Update(double time)
        {
            if( Turning ){
                UpdateDirection( time );
            }

            if( _powerUp != null )
            {
                _powerUp.Update( time );
            }

            Move( time );
        }

        public void NewShield() => _shield = true;

        public void RemovePowerUp(IPowerUp pUp) {
            if( pUp == _powerUp)
            {
                _powerUp = null;
            }
        }

        public IHitBox GetHitbox() => null; // not implemented in C#

        private void  CreateProjectile(){} // not implemented in C#

        private void StartTimer()
        {
            if( !_timer.Enabled && _recharging ){
                _timer.Start();
                _recharging = true;
            }
        }

        private void AddBullet()
        {
            _bullets ++;
            _recharging = false;
            if( _bullets < _maxBullets )
            {
                StartTimer();
            }
        }

        private void UpdateDirection( double time )
        {
            _angle = ( _angle + time * ISpaceship.ROTATION_SPEED ) % 360;
            double dirX = Math.Cos( Math.PI * _angle / 180.0);
            double dirY = Math.Sin( Math.PI * _angle / 180.0);

            _direction = new Direction(dirX, dirY);
        }

        private void Move( double time )
        {
            _lastPosition = _position;
            _position = _position.Move( _direction.Multiply( Speed * time ) );
        }
    }
}