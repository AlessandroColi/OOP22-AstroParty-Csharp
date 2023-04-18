
namespace ColiAlessandro.AstroParty.game.powerup
{
    public interface IPowerUpFactory
    {
        IPowerUp createPowerUp(EntityType type, Position pos);
    }
}