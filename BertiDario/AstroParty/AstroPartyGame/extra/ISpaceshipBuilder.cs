using System.Collections.Generic;
namespace AstroPartyGame
{

    public interface ISpaceshipBuilder{
        void SetNames(List<String> players);
        List<Spaceship> Create(IGameState gs);
    }
}