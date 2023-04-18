
namespace ColiAlessandro.AstroParty.game.powerup.api
{
    public interface IPowerUpFactory
    {
        IPowerUp CreatePowerUp(EntityType type, Position pos);
    }
}