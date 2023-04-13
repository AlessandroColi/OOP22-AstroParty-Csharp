using System;

/// <summary>
/// A power up inside AstroParty. 
/// </summary>
public interface IPowerUp 
{
    /// <summary>
    /// Size of the power up relative to the map.
    /// </summary>
    public double RELATIVE_SIZE = 2.5;

    /// <summary>
    /// Modifier for the upgraded speed.
    /// </summary>
    public double SPEED_MODIFIER = 1.3;

    /// <summary>
    /// The duration of the effect for most power ups in milliseconds.
    /// </summary>
    public double DURATION = 5000;

    /// <summary>
    /// The delay between the first and second shot. 
    /// </summary>
    public long DOUBLESHOT_DELAY = 55;

    /// <summary>
    /// The maximum number of power ups that can be on the screen at the same time.
    /// </summary>
    public int MAX_ON_SCREEN = 5;

    /// <summary>
    /// Use the power up on the spaceship that has picked up this power up.
    /// </summary>
    public void use();

    /// <summary>
    /// Inform this power up that it has been picked up.
    /// </summary>
    /// <param name="owner">The spaceship that picked it up.</param>
    /// <returns>True if it has been picked up.</returns>
    public bool pickUp(Spaceship owner);

    /// <summary>
    /// Determines whether this power up is offensive.
    /// </summary>
    /// <returns>True if it is an offensive power up.</returns>
    public bool isOffensive();

    /// <summary>
    /// Gets the hit box of the entity.
    /// </summary>
    /// <returns>The hit box of the entity.</returns>
    public CircleHitBox getHitBox();

    /// <summary>
    /// Gets the position of the entity.
    /// </summary>
    /// <returns>The position of the entity.</returns>
    public Position getPosition();

    /// <summary>
    /// Determines whether the entity was hit.
    /// </summary>
    /// <returns>True if the entity was hit.</returns>
    public bool hit();

    /// <summary>
    /// Tells the entity how much time has passed since the last update.
    /// </summary>
    /// <param name="time">The time that has passed in milliseconds.</param>
    public void update(double time);

    /// <summary>
    /// Gets the type of the power up.
    /// </summary>
    /// <returns>The type of the power up.</returns>
    public EntityType getType();

    /// <summary>
    /// Gets the graphic entity of this power up.
    /// </summary>
    /// <returns>The graphic entity of this power up.</returns>
    public GraphicEntity getGraphicComponent();
}