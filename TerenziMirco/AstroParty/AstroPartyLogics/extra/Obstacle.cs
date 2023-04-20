using ExtraAPI;
namespace ExtraImpl
{
    /// <summary>
    /// This is a simplified version of the original class and is implemented for demonstration purposes.
    /// </summary>
    public class Obstacle : IObstacle
    {
        public IHitBox HitBox => throw new NotImplementedException();

        public bool Hit() => true;

        public bool IsActive() => throw new NotImplementedException();

        public bool IsHarmful() => throw new NotImplementedException();

        public void Update(double time) => throw new NotImplementedException();
    }
}