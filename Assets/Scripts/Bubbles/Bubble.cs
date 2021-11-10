using Assets.Scripts.Bubbles.Stats;
using Assets.Scripts.Core.BusEvents;
using Assets.Scripts.Core.BusEvents.Handlers;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Bubbles
{
    public class Bubble : MonoBehaviour
    {
        [SerializeField] private BubbleMovement _movement;
        [SerializeField] private SpriteRenderer _renderer;
        [SerializeField] private ParticleSystem _destroyingParticles;
        [SerializeField] private float _objectRadius = 0.5f;

        private float _goingTimer;
        private IEnumerator _awaiting;
        private BubbleStats _stats;

        public float GoingTimer => _goingTimer;
        public float ObjectRadius => _objectRadius;
        public float Damage => _stats.Damage;
        public float Score => _stats.Score;

        public void InitRandom(BubbleStats stats)
        {
            _stats = stats;
            _awaiting = WaitForGoing();
            _destroyingParticles.transform.SetParent(null);
            _stats.Randomize();
            _renderer.color = _stats.Color;
            StartCoroutine(_awaiting);
        }

        public void Explode()
        {
            PrepareAndPlayParticles();
            ResetBubble();
        }

        public void Destroy()
        {
            Destroy(_destroyingParticles.gameObject);
            Destroy(gameObject);
        }

        private void PrepareAndPlayParticles()
        {
            _destroyingParticles.transform.position = transform.position;
            var collor = _destroyingParticles.colorOverLifetime;
            Gradient gradient = new Gradient();
            Color bubbleColor = _renderer.color;
            gradient.SetKeys(new GradientColorKey[] { new GradientColorKey(bubbleColor, 0.0f), new GradientColorKey(bubbleColor, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(0.0f, 1.0f) });
            collor.color = gradient;
            _destroyingParticles.Play();
        }

        private void ResetBubble()
        {
            _stats.Randomize();
            _renderer.color = _stats.Color;
            StopCoroutine(_awaiting);
            _goingTimer = 0;
            _movement.UpdateSpeed();
            _awaiting = WaitForGoing();
            StartCoroutine(_awaiting);
        }
        
        private void FixedUpdate()
        {
            _movement.Move();
        }

        private IEnumerator WaitForGoing()
        {
            float screenLength = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)).y * 2;
            float timer = (screenLength+_objectRadius) / _movement.Speed;
            _goingTimer = timer;
            yield return new WaitForSeconds(timer);
            timer = _objectRadius / _movement.Speed;
            yield return new WaitForSeconds(timer);
            EventBus.RaiseEvent((IBubbleHandler handler) => handler.Losed(this));
        }

        private void OnMouseDown()
        {
            EventBus.RaiseEvent((IBubbleHandler handler) => handler.Caught(this));
        }
    }
}