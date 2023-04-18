using ExtraAPI;
namespace ExtraImpl
{
    public class Projectile : IProjectile
    {
        public IHitBox HitBox => throw new NotImplementedException();

        public bool Hit() => true;

        public void Update(double time) => throw new NotImplementedException();
    }
}