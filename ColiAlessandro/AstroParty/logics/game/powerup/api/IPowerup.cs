namespace AstroParty
{   /// <summary>
    /// A power up inside AstroParty. 
    /// </summary>
    public interface IPowerUp : IEntity
    {
        /// <summary> size of a PowerUp relative to the map. </summary>
        const double RELATIVE_SIZE = 2.5;

        /// <summary> mofifier for the UpgradedSpeed. </summary>
        const double SPEED_MODIFIER = 1.3;

        /// <summary> the duration of the effect for most PowerUPs in milliseconds. </summary>
        const double DURATION = 5000;

        /// <summary> the delay between the first and the second shot. </summary>
        const long DOUBLESHOT_DELAY = 55;

        /// <summary> the maximun number of powerUps to be on the screen at the same time. </summary>
        const int MAX_ON_SCREEN = 5;
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