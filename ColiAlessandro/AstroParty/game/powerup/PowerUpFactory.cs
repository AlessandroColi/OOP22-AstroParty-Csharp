namespace ColiAlessandro.AstroParty.game.powerup
{
    public class PowerUpFactory : IPowerUpFactory
    {
        IPowerUp createPowerUp(EntityType type, Position pos)
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
            return new PowerUp( position, false, EntityType.UPGRADEDSPEED ){

                private boolean _inUse;
                private double _useTime;

                    override void Use()
                    {
                        base.GetOwner.Speed *= IPowerUp.SPEED_MODIFIER;
                    }
                    
                void update( double time) {

                    if (base.isPickedUp() && !_inUse) {
                        use();
                    }

                    if (_inUse) {
                        _useTime += time;
                        if (_useTime > PowerUp.DURATION) {
                            base.GetOwner.Speed /= IPowerUp.SPEED_MODIFIER;
                            base.getOwner().removePowerUp(this);
                        }
                    }
                }
            };
        }
        
        private CreateShisupereld( Position position )
        {
            return new BasicPowerUp(pos, false, EntityType.SHIELD) {

                override void update( double time) {
                    if (base.isPickedUp()) {
                        use();
                    }
                }

                override void use() {
                    base.getOwner().newShield();
                    base.getOwner().removePowerUp(this);
                }
            };
        }

        private CreateImmortality( Position position )
        {
            return new BasicPowerUp(pos, false,  EntityType.IMMORTALITY) {

                private boolean _inUse;
                private double _useTime;

                public void use() {
                    _inUse = true;
                    base.getOwner().Mortal = false;
                }

                public void update( double time) {

                    if (base.isPickedUp() && !_inUse) {
                        use();
                    }

                    if (_inUse) {
                        _useTime += time;
                        if (_useTime > PowerUp.DURATION) {
                            base.getOwner().Mortal = true;
                            base.getOwner().removePowerUp(this);
                        }
                    }
                }
            };
        }

        private CreateDoubleShot( Position position )
        {
            return new BasicPowerUp(pos, true,  EntityType.DOUBLESHOT) {

                override void update( double time) {
                }

                override void use() {
                    base.getOwner().removePowerUp(this);
                }
            };
        }
    }
}