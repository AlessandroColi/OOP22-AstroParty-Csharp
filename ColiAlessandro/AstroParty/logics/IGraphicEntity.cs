namespace AstroParty
{
    public interface IGraphicEntity
    {
        ///<returns>
        ///the {@link Position} of the top-left corner, used to draw the image.
        ///</returns>
        Position GetPosition();

        ///<returns>
        ///the height of the entity to be drawn.
        ///</returns>
        double GetHeight();

        ///
        ///the length of the entity to be drawn.
        ///</returns>
        double GetLength();

        ///</summary>
        ///the {@linkplain EntityType} of the entity to be drawn.
        ///</summary>
        EntityType GetType();

        /// <summary>
        /// the id of the spaceship ( only used for spaeschips and not for other entities)
        /// </summary>
        PlayerId Id{ get ; set; }

        /// <summary>
        /// the angle at witch the entity is rotated
        /// </summary>
        double Angle{ get ; set; }
    }

}