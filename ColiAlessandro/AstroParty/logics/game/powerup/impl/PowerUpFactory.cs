 using System;
namespace AstroParty
{
    public class PowerUpFactory : IPowerUpFactory
    {
        public IPowerUp CreatePowerUp(EntityType type, Position pos)
        {
            switch ( type )
            {
                case EntityType.UPGRADEDSPEED:
                {
                    return CreateSpeed(pos);
                }
                case EntityType.SHIELD:
                {
                    return CreateShield(pos);
                }
                case EntityType.IMMORTALITY:
                {
                    return CreateImmortality(pos);
                }
                case EntityType.DOUBLESHOT:
                {
                    return CreateDoubleShot(pos);
                }

                default: 
                    throw new ArgumentException("Type not possible");
            }
        }

        private IPowerUp CreateSpeed( Position position )
        {
            return new SpeedPowerUp(position);
        }
        
        private IPowerUp CreateShield( Position position )
        {
            return new ShieldPowerUp(position);
        }

        private IPowerUp CreateImmortality( Position position )
        {
            return new ImmortalityPowerUp(position);
        }

        private IPowerUp CreateDoubleShot( Position position )
        {
            return new DoubleShotPowerUp(position);
        }
    }

    class ImmortalityPowerUp : PowerUp
    {
        
        private bool _inUse;
        private double _UseTime;


        public ImmortalityPowerUp ( Position pos) : base( pos, true, EntityType.IMMORTALITY )
        {
        }

        public override void Use() 
        {
            _inUse = true;
            base.GetOwner().Mortal = false;
        }

        public override void Update( double time)
        {
            
            if (base.IsPickedUp() && !_inUse) 
            {
                Use();
            }

            if (_inUse)
            {
                _UseTime += time;
                if (_UseTime > IPowerUp.DURATION) 
                {
                    base.GetOwner().Mortal = true;
                    base.GetOwner().RemovePowerUp(this);
                }
            }
        }
    }
    

    class DoubleShotPowerUp : PowerUp
    {
        public DoubleShotPowerUp( Position pos) : base( pos, true, EntityType.DOUBLESHOT )
        {
        }

        public override void Use() 
        {
            base.GetOwner().RemovePowerUp(this);
        }

        public override void Update( double time) 
        {
            //nothing to do
        }
    }

    class ShieldPowerUp : PowerUp
    {

        private bool _inUse;
        private double _UseTime;

        public ShieldPowerUp(Position pos) : base( pos, false, EntityType.SHIELD )
        {
        }

        public override void Use() 
        {
            base.GetOwner().NewShield();
            base.GetOwner().RemovePowerUp(this);
        }

        public override void Update( double time) 
        {
            if (base.IsPickedUp()) 
            {
                Use();
            }
        }
    }

    class SpeedPowerUp : PowerUp
    {

        private bool _inUse;
        private double _UseTime;

        public SpeedPowerUp(Position pos) : base( pos, false, EntityType.UPGRADEDSPEED )
        {
        }

        public override void Use()
        {
            base.GetOwner().Speed *= IPowerUp.SPEED_MODIFIER;
        }
                    
        public override void Update( double time) 
        {

            if (base.IsPickedUp() && !_inUse) 
            {
                Use();
            }
    
            if (_inUse) 
            {
                _UseTime += time;
                if (_UseTime > PowerUp.DURATION) 
                {
                    base.GetOwner().Speed /= IPowerUp.SPEED_MODIFIER;
                    base.GetOwner().RemovePowerUp(this);
                }
            }
        }
    }
}