namespace AstroParty
{
    /// <summary>
    /// A simple class describing movements as the distance in X and Y coordinates from the starting point.
    /// </summary>
    public class Direction {
        private readonly double _x;
        private readonly double _y;

        /// <summary>
        /// Initializes a new instance of the Direction class with the specified X and Y coordinates.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public Direction(double x, double y)
        {
            _x = x;
            _y = y;
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
        /// Adds the specified Direction to this Direction.
        /// </summary>
        /// <param name="v">The Direction to be added.</param>
        /// <returns>A new Direction.</returns>
        public Direction Add(Direction v)
        {
            return new Direction(_x + v.X, _y + v.Y);
        }

        /// <summary>
        /// Multiplies the direction for a scalar.
        /// </summary>
        /// <param name="alpha">The value to multiply this Direction with.</param>
        /// <returns>A new Direction.</returns>
        public Direction Multiply(double alpha)
        {
            return new Direction(_x * alpha, _y * alpha);
        }

        /// <summary>
        /// Returns a string representation of this Direction.
        /// </summary>
        /// <returns>A string representation of this Direction.</returns>
        public override string ToString()
        {
            return Convert.ToString(x) + ":" + Convert.ToString(y);
        }
    }
}