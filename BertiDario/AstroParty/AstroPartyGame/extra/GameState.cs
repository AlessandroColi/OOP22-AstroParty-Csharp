namespace AstroPartyGame{
    public class GameState : IGameState{    
        public List<ISpaceship> Spaceships { get; }  
        public void AddSpaceship (ISpaceship spaceship){
        }  
        public void RegisterObserver(){
        }

        public void Update(double time){
        }

        public bool IsOver(){
            return false;
        }
    }
}