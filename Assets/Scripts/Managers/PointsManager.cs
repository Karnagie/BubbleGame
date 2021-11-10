using Assets.Scripts.Core.BusEvents;
using Assets.Scripts.Core.BusEvents.Handlers;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class PointsManager : MonoBehaviour, IPointsHandler
    {
        [SerializeField] private string _highScoreKey = "HighScore";
        [SerializeField] private float _startHp = 10;
        [SerializeField] private TMP_Text _scoreUI;
        [SerializeField] private TMP_Text _hpUI;
        [SerializeField] private TMP_Text _highScoreUI;

        private float _score = 0;
        private float _highScore;
        private float _hp;

        private void Awake()
        {
            EventBus.Subscribe(this);
        }

        private void Start()
        {
            _highScore = PlayerPrefs.GetFloat(_highScoreKey, 0);
            _hp = _startHp;
            _scoreUI.text = $"Score: {GetPoint(_score)}";
            _hpUI.text = $"Hp: {GetPoint(_hp)}";
            _highScoreUI.text = $"High Score: {GetPoint(_highScore)}";
        }

        public void AddScore(float count)
        {
            _score += count;
            _scoreUI.text = $"Score: {GetPoint(_score)}";
        }

        public void LoseHP(float count)
        {
            _hp -= count;
            _hpUI.text = $"Hp: {GetPoint(_hp)}";
            if (_hp <= 0)
            {
                LoseGame();
                _hpUI.text = $"Hp: {0}";
            }
        }

        private void LoseGame()
        {
            EventBus.RaiseEvent((IBubbleHandler handler) => handler.Stop());
            EventBus.RaiseEvent((IGameStateHandler handler) => handler.Lose());
            if(_score > _highScore)PlayerPrefs.SetFloat(_highScoreKey, _score);
            EventBus.Unsubscribe(this);
        }

        private string GetPoint(float value)
        {
            return value.ToString().Substring(0, Mathf.Min(value.ToString().Length, 3));
        }

        [ContextMenu("Reset prefs")]
        private void ResetPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
