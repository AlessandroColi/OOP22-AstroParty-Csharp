using ExtraAPI;
namespace ExtraImpl
{
    public class Entity : IEntity
    {
        public IHitBox HitBox => throw new NotImplementedException();

        public bool Hit()
        {
            throw new NotImplementedException();
        }

        public void Update(double time)
        {
            throw new NotImplementedException();
        }
    }

}