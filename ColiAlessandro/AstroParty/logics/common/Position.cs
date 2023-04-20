namespace AstroParty
{
    /// <summary>
    /// A simple class that represents a point in a two-dimensional space.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// The margin of error for two positions to be considered the same.
        /// </summary>
        public const double EPSILON = 0.000_001;
        private readonly double _x;
        private readonly double _y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Position"/> class.
        /// </summary>
        /// <param name="x">The X position.</param>
        /// <param name="y">The Y position.</param>
        public Position(double x, double y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Moves the point according to the given direction.
        /// </summary>
        /// <param name="v">The <see cref="Direction"/> of the movement to be performed.</param>
        /// <returns>The resulting position after the movement.</returns>
        public Position Move(Direction v)
        {
            return new Position(_x + v.GetX(), _y + v.GetY());
        }

        /// <summary>
        /// Calculates the sum of two positions.
        /// </summary>
        /// <param name="p">The position to be added to this position.</param>
        /// <returns>The new position resulting from the sum.</returns>
        public Position Add(Position p)
        {
            return new Position(_x + p.X(), _y + p.Y());
        }

        /// <summary>
        /// Gets the distance from another position using the Pythagorean theorem.
        /// </summary>
        /// <param name="pos">The position which the distance is to be calculated from.</param>
        /// <returns>The distance to the other position as a double.</returns>
        public double GetDistanceFrom(Position pos)
        {
            double deltaX = _x - pos.X();
            double deltaY = _y - pos.Y();
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }

        /// <summary>
        /// Gets the X coordinate.
        /// </summary>
        public double X { get =>  _x;  }

        /// <summary>
        /// Gets the Y coordinate.
        /// </summary>
        public double Y { get =>  _y; }

        /// <summary>
        /// Determines whether the specified object is equal to this position.
        /// </summary>
        /// <param name="obj">The object to compare to this position.</param>
        /// <returns>True if the object is equal to this position, false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Position))
            {
                return false;
            }

            Position pos = (Position)obj;
            return Math.Abs(pos.X() - _X()) < EPSILON && Math.Abs(pos.GetY() - _Y()) < EPSILON;
        }

        /// <summary>
        /// Gets the hash code for this position.
        /// </summary>
        /// <returns>The hash code for this position.</returns>
        public override int GetHashCode()
        {
            const int prime = 7;
            int result = (int)(_x + _y);
            result = prime * result;
            result = prime * result;
            return result;
        }

        /// <summary>
        /// Returns a string that represents this position.
        /// </summary>
        /// <returns>A string that represents this position as "X:Y".</returns>
        public override string ToString()
        {
            return Convert.ToString(x) + ":" + Convert.ToString(y);
        }

        /// <summary>
        /// Creates a defensive copy of this position.
        /// </summary>
        /// <returns>A new instance of <see cref="Position"/> with the same values as this position.</returns>
        public Position Copy()
        {
            return new Position(_x, _y);
        }
    }
}