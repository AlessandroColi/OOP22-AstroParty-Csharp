namespace AstroPartyLogics
{
    /// <summary>
    /// An interface rappresenting most of the objects in the game.
    /// This is a simplified version of the original interface and is implemented for demonstration purposes.
    /// </summary>
    public interface IEntity
    {
        /// <value>The hitbox of the entity.</value>
        IHitBox HitBox { get; }


        /// <returns>True if is killed/destroyed, false otherwise.</returns>
        bool hit();

        /// <summary>
        /// Tells the entity how much time has passed since the last update.
        /// </summary>
        /// <param name="time">The time in milliseconds.</param>
        void update(double time);
    }
}