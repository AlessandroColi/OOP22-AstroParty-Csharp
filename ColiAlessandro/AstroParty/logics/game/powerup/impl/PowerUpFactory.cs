namespace AstroParty
{
    public class PowerUpFactory : IPowerUpFactory
    {
        public override IPowerUp CreatePowerUp(EntityType type, Position pos)
        {
            switch ( type )
            {
                case EntityType.UPGRADEDSPEED:
                {
                    CreateSpeed(pos);
                    break;
                }
                case EntityType.SHIELD:
                {
                    CreateShield(pos);
                    break;
                }
                case EntityType.IMMORTALITY:
                {
                    CreateImmortality(pos);
                    break;
                }
                case EntityType.DOUBLESHOT:
                {
                    CreateDoubleShot(pos);
                    break;
                }

                default: 
                    throw new ArgumentException("Type not possible");
            }
        }

        private void CreateSpeed( Position position )
        {
            return new SpeedPowerUp(position);
        }
        
        private void CreateShisupereld( Position position )
        {
            return new ShieldPowerUp(position);
        }

        private void CreateImmortality( Position position )
        {
            return new ImmortalityPowerUp(pos);
        }

        private void CreateDoubleShot( Position position )
        {
            return new DoubleShotPowerUp(pos);
        }
    }

    class ImmortalityPowerUp : PowerUp
    {
        
        private bool _inUse;
        private double _UseTime;


        ImmortalityPowerUp ( Position pos)
        {
            PowerUp( pos, true, EntityType.IMMORTALITY );
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
                if (_UseTime > PowerUp.DURATION) 
                {
                    base.GetOwner().Mortal = true;
                    base.GetOwner().RemovePowerUp(this);
                }
            }
        }
    }
    

    class DoubleShotPowerUp : PowerUp
    {
        DoubleShotPowerUp( Position pos)
        {
            PowerUp( pos, true, EntityType.DOUBLESHOT );
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

        ShieldPowerUp(Position pos)
        {
            PowerUp( pos, false, EntityType.SHIELD );
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

        SpeedPowerUp(Position pos)
        {
            PowerUp( pos, false, EntityType.UPGRADEDSPEED );
        }

        public override void Use()
        {
            base.GetOwner.Speed *= IPowerUp.SPEED_MODIFIER;
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
                    base.GetOwner.Speed /= IPowerUp.SPEED_MODIFIER;
                    base.GetOwner().RemovePowerUp(this);
                }
            }
        }
    }
}