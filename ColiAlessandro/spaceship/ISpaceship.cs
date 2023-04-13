/// <summary>
/// Interface for a basic spaceship in AstroParty.
/// </summary>
public interface ISpaceship 
{
    /// <summary>
    /// Size of a PowerUp relative to the map.
    /// </summary>
    double RELATIVE_SIZE { get; }

    /// <summary>
    /// The speed at which a SpaceShip rotates.
    /// </summary>
    double ROTATION_SPEED { get; }

    /// <summary>
    /// Returns the PlayerId of this spaceship.
    /// </summary>
    /// <returns>The PlayerId of this spaceship.</returns>
    PlayerId GetId();

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
    /// Starts turning.
    /// </summary>
    void StartTurn();

    /// <summary>
    /// Returns the rotation angle.
    /// </summary>
    /// <returns>The rotation angle.</returns>
    double GetAngle();

    /// <summary>
    /// Stops turning.
    /// </summary>
    void StopTurn();

    /// <summary>
    /// Returns the CircleHitBox of the spaceship.
    /// </summary>
    /// <returns>The CircleHitBox of the spaceship.</returns>
    CircleHitBox GetHitBox();

    /// <summary>
    /// Makes the ship immortal.
    /// </summary>
    void MakeImmortal();

    /// <summary>
    /// Makes the ship mortal.
    /// </summary>
    void MakeMortal();

    /// <summary>
    /// Gives the ship a shield that blocks one damage instance.
    /// </summary>
    void NewShield();

    /// <summary>
    /// Sets the speed to max.
    /// </summary>
    void UpgradeSpeed();

    /// <summary>
    /// Sets the speed to normal.
    /// </summary>
    void NormalSpeed();

    /// <summary>
    /// Removes the power up after it's been used.
    /// </summary>
    /// <param name="upgradedSpeed">The power up to be removed.</param>
    void RemovePowerUp(PowerUp upgradedSpeed);
}