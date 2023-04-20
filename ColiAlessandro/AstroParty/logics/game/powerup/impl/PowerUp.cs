namespace AstroParty
{
    public abstract class PowerUp : IPowerup
    {
        private ISpaceship _owner;
        private readonly Position _position;
        private boolean _pickedUp;

        PowerUp( Position position, boolean offensive, EntityType type )
        {
            _position = position;
            Type = type;
            Offensive = offensive;
        }
        bool Offensive{ get ; private set; }

        EntityType Type{ get ; private set; }

        IgraphicEntity GraphicComponent{ get => new GraphicEntity(_position, IPowerup.RELATIVE_SIZE, Type); } 

        Position GetPosition() => _position;
        
        bool PickUp(ISpaceship owner)
        {
            if( _owner == null || owner = null)
            {
                return false
            }
            _owner = owner;
            return true;
        }

        override ICircleHitBox GetHitbox() => null; // not implemented in C#

        protected ISpaceship GetOwner() => _owner;

        protected boolean IsPickedUp() => _owner != null;

        abstract void Use();

        abstract void Update(double time);
    }
}