using ExtraAPI;
namespace ExtraImpl
{
    public class Obstacle : IObstacle
    {
        public IHitBox HitBox => throw new NotImplementedException();

        public bool Hit() => true;

        public bool IsActive() => throw new NotImplementedException();

        public bool IsHarmful() => throw new NotImplementedException();

        public void Update(double time) => throw new NotImplementedException();
    }
}