namespace ColiAlessandro.AstroParty.game.powerup
{   /// <summary>
    /// A power up inside AstroParty. 
    /// </summary>
    public interface IPowerUp : IEntity
    {
        /// <summary>
        /// Use the power up on the spaceship that has picked up this power up.
        /// </summary>
        void Use();

        /// <summary>
        /// Inform this power up that it has been picked up.
        /// </summary>
        /// <param name="owner">The spaceship that picked it up.</param>
        /// <returns>True if it has been picked up.</returns>
        bool PickUp(ISpaceship owner);

        /// <summary>
        /// Determines whether this power up is offensive.
        /// </summary>
        bool Offensive{ get ; }

        /// <summary>
        /// the hitbox of the PowerUp.
        /// </summary>
        override ICircleHitBox GetHitbox();
    }
}