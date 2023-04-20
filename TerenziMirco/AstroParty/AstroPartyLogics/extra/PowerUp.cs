using ExtraAPI;
namespace ExtraImpl
{
    /// <summary>
    /// This is a simplified version of the original interface and is implemented for demonstration purposes.
    /// </summary>
    public class PowerUp : IPowerUp
    {
        public IHitBox HitBox => throw new NotImplementedException();

        public bool Hit() => throw new NotImplementedException();

        public void Update(double time) => throw new NotImplementedException();
    }
}