namespace AstroParty
{
    public class GraphicEntity : IGraphicEntity
    {
        private readonly Position _position;
        private readonly double _height;
        private readonly double _length;
        private readonly EntityType _type;

        public override PlayerId Id{ get ; set; }

        public override double Angle { get ; set; }

        GraphicEntity( Position pos, double height, double length, EntityType type)
        {
            _position = pos;
            _height = height;
            _length = length;
            _type = type;
        }

        GraphicEntity( Position pos, double side, EntityType type)
        {
            this( pos, side, side, type);
        }

        public override Position GetPosition() => _position ;

        public override double GetHeight() => _height ;

        public override double GetLength() => _length ;

        public override EntityType GetType() => _type ;
    }

}