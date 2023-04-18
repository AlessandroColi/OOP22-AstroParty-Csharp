namespace ColiAlessandro.AstroParty
{
    public class GraphicEntity :IGraphicEntity
    {
        private readonly Position _position;
        private readonly double _height;
        private readonly double _length;
        private readonly EntityType _type;

        PlayerId Id{ get ; set; }

        double Angle{ get ; set; }

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

        Position GetPosition() => _position ;

        double GetHeight() => _height ;

        double GetLength() => _length ;

        EntityType GetType() => _type ;
    }

}