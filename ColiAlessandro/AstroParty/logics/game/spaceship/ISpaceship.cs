namespace AstroParty
{   /// <summary>
    /// Interface for a basic spaceship in AstroParty.
    /// </summary>
    public interface ISpaceship : IEntity
    {
        /// <summary>
        /// the size relative to the map. 
        /// </summary>
        const double RELATIVE_SIZE = 3;
        /// <summary>
        /// the speed at which a SpaceShip rotates. 
        /// </summary>
        const double ROTATION_SPEED = 0.25;
        /// <summary>
        /// Resets the position of the spaceship before the update.
        /// </summary>
        void ResetPosition();

        /// <summary>
        /// Equips a power up to the spaceship.
        /// </summary>
        /// <param name="pUp">The Powerup to be equipped.</param>
        /// <returns>True if it can be picked up.</returns>
        bool EquipPowerUp(IPowerUp pUp);

        /// <summary>
        /// Shoots a Projectile.
        /// </summary>
        void Shoot();

        /// <summary>
        /// Gives the ship a shield that blocks one damage instance.
        /// </summary>
        void NewShield();

        /// <summary>
        /// Removes the power up after it's been used.
        /// </summary>
        /// <param name="upgradedSpeed">The power up to be removed.</param>
        void RemovePowerUp(IPowerUp upgradedSpeed);

        /// <summary>
        /// either can be killed or not ( does not consider the shield )
        /// </summary>
        bool Mortal{ get ; set; }

        /// <summary>
        /// The rotation angle.
        /// </summary>
        double Angle{ get ; }

        /// <summary>
        /// the PlayerId of this spaceship.
        /// </summary>
        PlayerId Id{ get ; }

        /// <summary>
        /// The travel speed.
        /// </summary>
        double Speed{ get ; set; }

        /// <summary>
        /// the spaceship is turnong or not.
        /// </summary>
        bool Turning{ get ; set; }

    }
}