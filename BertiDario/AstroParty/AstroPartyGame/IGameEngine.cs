namespace AstroPartyGame
{
    public interface IGameEngine
    {
        void init(List<String> players, bool obstacle, bool powerup, int rounds);

        void mainLoop();
    }
}