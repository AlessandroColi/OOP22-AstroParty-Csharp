namespace ExtraAPI
{
    /// <summary>
    /// This is a simplified version of the original interface and is implemented for demonstration purposes.
    /// </summary>
    public interface IHitBox
    {
        IPosition Center { get; }
        double Radius { get; }
        bool CheckCollision(IHitBox hBox);
    }
}