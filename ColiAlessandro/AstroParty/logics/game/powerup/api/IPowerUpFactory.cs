
namespace AstroParty
{
    public interface IPowerUpFactory
    {
        IPowerUp CreatePowerUp(EntityType type, Position pos);
    }
}