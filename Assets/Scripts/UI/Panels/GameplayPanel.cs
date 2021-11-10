using Assets.Scripts.Core.BusEvents;
using Assets.Scripts.Core.BusEvents.Handlers;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Panels
{
    public class GameplayPanel : Panel
    {
        [SerializeField] private Button _pauseButton;

        private void Start()
        {
            _pauseButton.onClick.AddListener(Pause);
        }

        private void Pause()
        {
            EventBus.RaiseEvent((IGameStateHandler handler) => handler.Pause());
        }
    }
}
