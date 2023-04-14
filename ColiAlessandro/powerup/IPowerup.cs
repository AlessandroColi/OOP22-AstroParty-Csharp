namespace ColiAlessandro.powerup
{   /// <summary>
    /// A power up inside AstroParty. 
    /// </summary>
    public interface IPowerUp 
    {
        /// <summary>
        /// Use the power up on the spaceship that has picked up this power up.
        /// </summary>
        void Use();

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
        /// Inform this power up that it has been picked up.
        /// </summary>
        /// <param name="owner">The spaceship that picked it up.</param>
        /// <returns>True if it has been picked up.</returns>
        bool PickUp(Spaceship owner);

        /// <summary>
        /// the type of the power up.
        /// </summary>
        EntityType Type{ get ; }

        /// <summary>
        /// the graphic entity of this power up.
        /// </summary>
        GraphicEntity GraphicComponent{ get ; }

        /// <summary>
        /// Determines whether this power up is offensive.
        /// </summary>
        bool Offensive{ get ; }

        /// <summary>
        /// the hit box of the entity.
        /// </summary>
        CircleHitBox HitBox{ get ; }

        /// <summary>
        /// the position of the entity.
        /// </summary>
        Position Position{ get ; }
    }
}