using System.Collections.Generic;

namespace AstroPartyGame
{
    public class GameEngine : IGameEngine 
    {
        private static ISpaceship _spaceship;
        private static IGameState _gameState;
        private static ISpaceshipBuilder _spaceshipBuilder;
        private static IInputControl _inputControl;
        private static int _roundsGame;
        private static bool _obstaclesBool;
        private static bool _powerupsBool;
        private static int? _p1, _p2, _p3, _p4;
        const int _O1_X = 47, _O1_Y = 27, _O2_X = 47, _O2_Y = 67, _O3_Y = 7,
            _O4_Y = 87, _L1_X = _O3_Y + 10, _L2_X = _O2_Y + 10;

        /// <inheritdoc />
        public GameEngine(){
        }

        /// <inheritdoc />
        public void init(List<String> players, bool obstacle, bool powerup, int rounds) {
            _spaceship = new Spaceship();
            _spaceshipBuilder = new SpaceshipBuilder();
            _spaceshipBuilder.SetNames(players);
            _roundsGame = rounds;
            _obstaclesBool = obstacle;
            _powerupsBool = powerup;
            _p1 = 0;
            _p2 = 0;
            _p3 = 0;
            _p4 = 0;
        }

        /// <inheritdoc />
        private void CreateMap() {
            _gameState = new GameState();
            _inputControl = new InputControl();

            CreateObstacles();

            if (_powerupsBool) 
            {
                CreatePowerups();
            }

            if (_obstaclesBool) 
            {
                CreateLasers();
            }

            foreach(Spaceship spaceship in _spaceshipBuilder.Create(_gameState)){
                _gameState.AddSpaceship(spaceship);
            }
        }

        private void CreatePowerups() {
        }

        private void CreateObstacles() {
        }

        private void CreateLasers() {
        }

        /// <inheritdoc />
        public void mainLoop() {
            CreateMap();
            Round round = new Round();
            round.Execute();
        }

        private class Round 
        {

            public void Execute() 
            {
                const double _viewRefreshInterval = 16.6;
                const double _nextRefreshTime = _viewRefreshInterval;
                List<String> _a = new List<String>();

                _inputControl.Start();
                while (!(_gameState.IsOver())) 
                {

                    ProcessInput();

                    UpdateGame(_viewRefreshInterval);


                    Render();

                    try
                    {
                        double _surplusTime = _nextRefreshTime - DateTime.UtcNow.Millisecond;

                        if (_surplusTime < 0) {
                            _surplusTime = 0;
                        }
                    } catch (Exception e) 
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                _inputControl.Stop();

                foreach(Spaceship s in _gameState.Spaceships){
                    _a.Add(s.ToString());
                }
                switch (_a[0]) 
                {
                case "Player1":
                    _p1 = _p1 + 1;
                    if (_p1.Equals(_roundsGame)) 
                    {
                        // player 1 is the winner
                    }
                    break;

                case "Player2":
                    _p2 = _p2 + 1;
                    if (_p2.Equals(_roundsGame)) 
                    {
                        // player 2 is the winner
                    }
                    break;

                case "Player3":
                    _p3 = _p3 + 1;
                    if (_p3.Equals(_roundsGame)) 
                    {
                        // player 3 is the winner
                    }
                    break;

                case "Player4":
                    _p4 = _p4 + 1;
                    if (_p4.Equals(_roundsGame)) 
                    {
                        // player 4 is the winner
                    }
                    break;

                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        
        protected static void ProcessInput() {
            _inputControl.ComputeAll(_gameState.Spaceships);
        }

        private static void UpdateGame(double timePassedCycle) {
            _gameState.Update(timePassedCycle);
        }

        private static void Render(){
        }

    }

}