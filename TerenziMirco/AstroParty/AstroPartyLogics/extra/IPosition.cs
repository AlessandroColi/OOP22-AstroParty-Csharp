namespace ExtraAPI
{
    /// <summary>
    /// This is a simplified version of the original interface and is implemented for demonstration purposes.
    /// </summary>
    public interface IPosition : IEntity
    {
        double X { get; }
        double Y { get; }
    }
}