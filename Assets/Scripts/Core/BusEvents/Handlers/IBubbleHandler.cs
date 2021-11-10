using Assets.Scripts.Bubbles;

namespace Assets.Scripts.Core.BusEvents.Handlers
{
    public interface IBubbleHandler : IGlobalSubscriber
    {
        void Losed(Bubble entity);
        void Caught(Bubble entity);
        void Stop();
    }
}
