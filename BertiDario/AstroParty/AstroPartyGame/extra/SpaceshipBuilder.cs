namespace AstroPartyGame
{
    public class SpaceshipBuilder : ISpaceshipBuilder
    {
        public void SetNames(List<String> players){
        }

        public List<Spaceship> Create(IGameState gs){
            return new List<Spaceship>();
        }
    }
}