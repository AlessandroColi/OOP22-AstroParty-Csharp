namespace ExtraAPI
{
    /// <summary>
    /// This is a simplified version of the original interface and is implemented for demonstration purposes.
    /// </summary>
    public interface ISpaceship : IEntity
    {
        void resetPosition();
        bool equipPowerUp(IPowerUp pUp);
    }
}