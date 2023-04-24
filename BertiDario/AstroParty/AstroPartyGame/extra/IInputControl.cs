namespace AstroPartyGame
{
    public interface IInputControl
    {
        void Start();

        void Stop();

        void ComputeAll(List<ISpaceship> spaceships);
    }
}