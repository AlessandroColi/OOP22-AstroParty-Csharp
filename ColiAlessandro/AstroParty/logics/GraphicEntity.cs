namespace AstroParty
{
    public class GraphicEntity : IGraphicEntity
    {
        private readonly Position _position;
        private readonly double _height;
        private readonly double _length;
        private readonly EntityType _type;

        public PlayerId Id { get; set; }

        public double Angle { get; set; }

        public GraphicEntity(Position pos, double height, double length, EntityType type)
        {
            _position = pos;
            _height = height;
            _length = length;
            _type = type;
        }

        public GraphicEntity(Position pos, double side, EntityType type) 
            : this(pos, side, side, type)
        {
        }

        public Position GetPosition() => _position;

        public double GetHeight() => _height;

        public double GetLength() => _length;

        public EntityType GetEntityType() => _type;
    }
}