using Assets.Scripts.Bubbles;
using Assets.Scripts.Core.BusEvents;
using Assets.Scripts.Core.BusEvents.Handlers;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class BubblesManager : MonoBehaviour, IBubbleHandler
    {
        [SerializeField] private BubbleFactory _bubbleFactory;
        [SerializeField] private int _bubblePoolSize = 10;

        private Bubble[] _bubbles;

        public void Losed(Bubble entity)
        {
            ResetBubble(entity);
            EventBus.RaiseEvent((IPointsHandler handler) => handler.LoseHP(entity.Damage));
        }

        public void Caught(Bubble entity)
        {
            ResetBubble(entity);
            EventBus.RaiseEvent((IPointsHandler handler) => handler.AddScore(entity.Score));
        }

        public void Stop()
        {
            foreach (var bubble in _bubbles)
            {
                _bubbleFactory.Delete(bubble);
            }
            EventBus.Unsubscribe(this);
        }

        private void Awake()
        {
            EventBus.Subscribe(this);
        }

        private void Start()
        {
            _bubbles = new Bubble[_bubblePoolSize];
            for (int i = 0; i < _bubblePoolSize; i++)
            {
                _bubbles[i] = _bubbleFactory.GetRandom();
                SetBubblePosition(_bubbles[i]);
            }
        }

        private void SetBubblePosition(Bubble bubble)
        {
            Vector3 spawnPosition = new Vector3(Screen.width / 2, Screen.height, 0);
            float upperLeftAngle = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).x;
            float offset = Random.Range(-upperLeftAngle, upperLeftAngle);
            Vector3 wordPosition = Camera.main.ScreenToWorldPoint(spawnPosition);
            wordPosition.x += offset;
            wordPosition.y += bubble.ObjectRadius;
            wordPosition.z = 0;
            bubble.gameObject.transform.position = wordPosition;
        }

        private void ResetBubble(Bubble entity)
        {
            entity.Explode();
            SetBubblePosition(entity);
        }
    }
}
