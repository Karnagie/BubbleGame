using Assets.Scripts.Core.BusEvents;
using Assets.Scripts.Core.BusEvents.Handlers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts.UI.Panels
{
    public class LosePanel : Panel
    {
        [SerializeField] private Button _restartButton;

        private void Start()
        {
            _restartButton.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            SceneManager.LoadScene(0);
        }
    }
}
