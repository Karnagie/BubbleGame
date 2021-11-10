using Assets.Scripts.Core.BusEvents;
using Assets.Scripts.Core.BusEvents.Handlers;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Panels
{
    public class PausePanel : Panel
    {
        [SerializeField] private Button _continueButton;
        [SerializeField] private Button _restartButton;

        private void Start()
        {
            _continueButton.onClick.AddListener(Continue);
            _restartButton.onClick.AddListener(Restart);
        }

        private void Continue()
        {
            EventBus.RaiseEvent((IGameStateHandler handler) => handler.Continue());
        }

        private void Restart()
        {
            EventBus.Clear();
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }
}
