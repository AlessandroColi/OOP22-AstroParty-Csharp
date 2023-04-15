namespace ColiAlessandro.AstroParty.extra.api
{
    public interface IEntity
    {
        /// <summary>
        /// Determines whether the entity was hit.
        /// </summary>
        /// <returns>True if the entity was hit.</returns>
        bool Hit();

        /// <summary>
        /// Tells the entity how much time has passed since the last update.
        /// </summary>
        /// <param name="time">The time that has passed in milliseconds.</param>
        void Update(double time);

        /// <summary>
        /// the position of the entity.
        /// </summary>
        /// <returns>the position</returns>
        Position GetPosition();

        /// <summary>
        /// the type of the power up.
        /// </summary>
        EntityType Type{ get ; }

        /// <summary>
        /// the graphic entity of this power up.
        /// </summary>
        IgraphicEntity GraphicComponent{ get ; }

        /// <summary>
        /// HitBox of the entity.
        /// </summary>
        HitBox GetHitbox();
    }
}