namespace AstroPartyGame{
    public interface IGameState{        
        public List<ISpaceship> Spaceships { get; }
        void AddSpaceship (ISpaceship spaceship);
        void RegisterObserver();
        void Update(double time);
        bool IsOver();
    }
}