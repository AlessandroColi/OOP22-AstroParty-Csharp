namespace ColiAlessandro.spaceship
{   /// <summary>
    /// Interface for a basic spaceship in AstroParty.
    /// </summary>
    public interface ISpaceship
    {
        /// <summary>
        /// Resets the position of the spaceship before the update.
        /// </summary>
        void ResetPosition();

        /// <summary>
        /// Equips a power up to the spaceship.
        /// </summary>
        /// <param name="pUp">The PowerUp to be equipped.</param>
        /// <returns>True if it can be picked up.</returns>
        bool EquipPowerUp(PowerUp pUp);

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
        void RemovePowerUp(PowerUp upgradedSpeed);

        /// <summary>
        /// either can be killed or not ( does not consider the shield )
        /// </summary>
        bool Mortal{ ; set }

        /// <summary>
        /// The rotation angle.
        /// </summary>
        double Angle{ get ; }

        /// <summary>
        /// the PlayerId of this spaceship.
        /// </summary>
        PlayerId Id{ get ; }

        /// <summary>
        /// The CircleHitBox of the spaceship.
        /// </summary>
        CircleHitBox HitBox{ get ; }

        /// <summary>
        /// The travel speed.
        /// </summary>
        double Speed{ get ; set }

        /// <summary>
        /// the spaceship is turnong or not.
        /// </summary>
        bool Turning{ ; set }
    }
}