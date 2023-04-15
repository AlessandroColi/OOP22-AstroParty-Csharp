using System.Globalization;
using System.Data.Common;
using System;
namespace ColiAlessandro.AstroParty.game.spaceship
{
    public class SimpleSpaceship : ISpaceship
    {
        public bool Mortal{ private get ; set; }
        public double Angle{ get ; private set; }
        public PlayerId Id{ get ; private set; }
        IGraphicEntity GraphicComponent{ get ; }     //TODO: fagli restituire sempre un grafic component ( impl o int? )
        public double Speed{ get ; set; }
        public bool Turning{private get ; set; }

        private Position _position;
        private Position _lastPosition;

        private IPowerup? _powerUp;
        private bool _shield;

        private Direction _direction;
        private double _angle;

        private IGameState _world;

        private readonly int _maxBullets;
        private readonly long _bulletRegenTime;
        private int _bullets;

        private bool _recharging;
        private Timer _timer = new System.Timers.Timer();

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
    
        Position GetPosition() => _position;

        bool EquipPowerUp(IPowerup pUp) => _powerUp = pUp;

        void Shoot()
        {
            if( _bullets == 0)
            {
                return;
            }

            if( _powerUp.Offensive ){
                //TODO switch con i possibili tipi
            }else{
                CreateProjectile();
            }
            StartTimer();
        }

        bool Hit()
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

        void Update(double time)
        {
            if( Turning ){
                UpdateDirection( time );
            }

            if( _powerUp.HasValue )
            {
                _powerUp.Value.Update( time );
            }

            Move( time );
        }

        void NewShield() => _shield = true;

        void RemovePowerUp(IPowerup pUp) {
            if( pUp == _powerUp ?? null)
            {
                _powerUp = null;
            }
        }

        ICircleHitBox GetHitBox(); //TODO

        private void  CreateProjectile() => _world.add( new IProjectile() );

        private void StartTimer()
        {
            if( !_timer.Enabled && _recharging ){
                _timer.start();
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
            _angle = ( _angle + turnTime * Spaceship.ROTATION_SPEED ) % 360; //costante giusta?
            double dirX = Math.cos( Math.PI * _angle / 180.0);
            double dirY = Math.sin( Math.PI * _angle / 180.0);

            _direction = new Direction(dirX, dirY);
        }

        private void Move( double time )
        {
            _lastPosition = _position;
            _position = _position.Add( _direction.Multiply( Speed * time ) );
        }
    }
}