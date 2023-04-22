using System.Collections.Generic;
using System.Linq;
namespace AstroParty
{
    public interface IGameState
    {
        const double HEIGHT = 100;
        const double WIDTH = 100;
        List<IPowerUp> GetPowerUps();
        void AddPowerUp( IPowerUp pUp);
    }
}