namespace ExtraAPI
{
    /// <summary>
    /// This is a simplified version of the original interface and is implemented for demonstration purposes.
    /// </summary>
    public interface IObstacle : IEntity
    {
        bool IsActive();
        bool IsHarmful();
    }
}