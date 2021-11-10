namespace Assets.Scripts.Core.BusEvents.Handlers
{
    public interface IGameStateHandler : IGlobalSubscriber
    {
        void Lose();
        void Pause();
        void Continue();
    }
}
