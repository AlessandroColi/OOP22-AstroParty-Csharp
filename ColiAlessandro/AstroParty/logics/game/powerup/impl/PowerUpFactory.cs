namespace logics.game.powerup.impl
{
    public class PowerUpFactory : IPowerUpFactory
    {
        IPowerUp CreatePowerUp(EntityType type, Position pos)
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

        private CreateSpeed( Position position )
        {
            return new PowerUp( position, false, EntityType.UPGRADEDSPEED )
            {

                private boolean _inUse;
                private double _UseTime;

                    override void Use()
                    {
                        base.GetOwner.Speed *= IPowerUp.SPEED_MODIFIER;
                    }
                    
                void Update( double time) 
                {

                    if (base.IsPickedUp() && !_inUse) 
                    {
                        Use();
                    }

                    if (_inUse) {
                        _UseTime += time;
                        if (_UseTime > PowerUp.DURATION) 
                        {
                            base.GetOwner.Speed /= IPowerUp.SPEED_MODIFIER;
                            base.GetOwner().RemovePowerUp(this);
                        }
                    }
                }
            };
        }
        
        private CreateShisupereld( Position position )
        {
            return new BasicPowerUp(pos, false, EntityType.SHIELD) 
            {

                override void Update( double time) 
                {
                    if (base.IsPickedUp()) {
                        Use();
                    }
                }

                override void Use() 
                {
                    base.GetOwner().NewShield();
                    base.GetOwner().RemovePowerUp(this);
                }
            };
        }

        private CreateImmortality( Position position )
        {
            return new BasicPowerUp(pos, false,  EntityType.IMMORTALITY)
            {

                private boolean _inUse;
                private double _UseTime;

                public void Use() 
                {
                    _inUse = true;
                    base.GetOwner().Mortal = false;
                }

                public void Update( double time)
                {

                    if (base.IsPickedUp() && !_inUse) 
                    {
                        Use();
                    }

                    if (_inUse) {
                        _UseTime += time;
                        if (_UseTime > PowerUp.DURATION) 
                        {
                            base.GetOwner().Mortal = true;
                            base.GetOwner().RemovePowerUp(this);
                        }
                    }
                }
            };
        }

        private CreateDoubleShot( Position position )
        {
            return new BasicPowerUp(pos, true,  EntityType.DOUBLESHOT)
            {

                override void Update( double time) 
                {
                }

                override void Use() 
                {
                    base.GetOwner().RemovePowerUp(this);
                }
            };
        }
    }
}