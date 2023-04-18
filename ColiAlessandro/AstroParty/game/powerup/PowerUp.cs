namespace ColiAlessandro.AstroParty.game.PowerUp
{
    public abstract class PowerUp : IPowerup
    {
        private ISpaceship? _owner;
        private readonly Position _position;

        PowerUp( Position position, boolean offensive, EntityType type )
        {
            _position = position;
            Type = type;
            Offensive = offensive;
        }
        bool Offensive{ get ; private set; }

        EntityType Type{ get ; private set; }

        IgraphicEntity GraphicComponent{ get ; } //TODO

        Position GetPosition() => _position;
        
        bool PickUp(ISpaceship owner) => _owner;

        override ICircleHitBox GetHitbox(); //TODO

        protected ISpaceship GetOwner() => _owner;

        abstract void Use();

        abstract void Update(double time);
    }
}