using ExtraAPI;
namespace ExtraImpl
{
    public class PowerUp : IPowerUp
    {
        public IHitBox HitBox => throw new NotImplementedException();

        public bool Hit() => throw new NotImplementedException();

        public void Update(double time) => throw new NotImplementedException();
    }
}