namespace AstroParty
{
    public abstract class PowerUp : IPowerUp
    {
        private ISpaceship _owner;
        private readonly Position _position;
        private bool _pickedUp;

        PowerUp( Position position, bool offensive, EntityType type )
        {
            _position = position;
            Type = type;
            Offensive = offensive;
        }
        public override bool Offensive{ get ; private set; }

        public override EntityType Type{ get ; private set; }

        public override IGraphicEntity GraphicComponent{ get => new GraphicEntity(_position, IPowerUp.RELATIVE_SIZE, Type); } 

        public override Position GetPosition() => _position;
        
        public override bool PickUp(ISpaceship owner)
        {
            if( _owner == null || owner = null)
            {
                return false;
            }
            _owner = owner;
            return true;
        }

        public override IHitBox GetHitbox() => null; // not implemented in C#

        protected ISpaceship GetOwner() => _owner;

        protected bool IsPickedUp() => _owner != null;

        abstract public override void Use();

        abstract public override void Update(double time);
    }
}