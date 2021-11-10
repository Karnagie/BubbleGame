using Assets.Scripts.Core.BusEvents;
using Assets.Scripts.Core.BusEvents.Handlers;
using Assets.Scripts.UI.Panels;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class MenuPanel : MonoBehaviour, IGameStateHandler
    {
        [SerializeField] private Panel _pausePanel;
        [SerializeField] private Panel _losePanel;
        [SerializeField] private Panel _gameplayPanel;

        private void Awake()
        {
            EventBus.Subscribe(this);
        }

        public void Lose()
        {
            _losePanel.Show();
            EventBus.Unsubscribe(this);
        }

        public void Pause()
        {
            Time.timeScale = 0;
            _pausePanel.Show();
            _gameplayPanel.ShowOff();
        }

        public void Continue()
        {
            Time.timeScale = 1;
            _pausePanel.ShowOff();
            _gameplayPanel.Show();
        }
    }
}
