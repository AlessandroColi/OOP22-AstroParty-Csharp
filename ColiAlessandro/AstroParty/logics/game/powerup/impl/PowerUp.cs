namespace AstroParty
{
    public abstract class PowerUp : IPowerUp
    {
        private ISpaceship _owner;
        private readonly Position _position;
        private bool _pickedUp;

        public PowerUp( Position position, bool offensive, EntityType type )
        {
            _position = position;
            Type = type;
            Offensive = offensive;
        }
        public bool Offensive{ get ; private set; }

        public EntityType Type{ get ; private set; }

        public IGraphicEntity GraphicComponent{ get => new GraphicEntity(_position, IPowerUp.RELATIVE_SIZE, Type); } 

        public Position GetPosition() => _position;
        
        public bool PickUp(ISpaceship owner)
        {
            if( _owner == null || owner == null)
            {
                return false;
            }
            _owner = owner;
            _pickedUp = true;
            return true;
        }

        public IHitBox GetHitbox() => null; // not implemented in C#

        public bool Hit() => true;

        protected ISpaceship GetOwner() => _owner;

        protected bool IsPickedUp() => _pickedUp;

        abstract public void Use();

        abstract public void Update(double time);
    }
}