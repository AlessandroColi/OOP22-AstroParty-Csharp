namespace AstroParty
{
    public interface IPowerUpSpawner
    {
        /// <summary>
        /// the game has ended so stop spawning.
        /// </summary>
        void Stop();

        /// <summary>
        /// start spawning, and put the new Power ups inside the correct {@link GameState}.
        /// </summary>
        /// <param name: world> the gamestate </param>
        
        void Start(GameState world);
    }
}