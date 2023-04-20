using ExtraAPI;
namespace ExtraImpl
{
    /// <summary>
    /// This is a simplified version of the original interface and is implemented for demonstration purposes.
    /// </summary>
    public class Spaceship : ISpaceship
    {
        public IHitBox HitBox => throw new NotImplementedException();
        public bool Hit() => true;

        public bool EquipPowerUp(IPowerUp pUp) => throw new NotImplementedException();

        public void ResetPosition() => throw new NotImplementedException();

        public void Update(double time) => throw new NotImplementedException();
    }
}