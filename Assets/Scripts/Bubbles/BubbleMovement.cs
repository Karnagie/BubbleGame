using UnityEngine;

namespace Assets.Scripts.Bubbles
{
    public class BubbleMovement : MonoBehaviour
    {
        [SerializeField] private Transform _transform;

        private float _startSpeed;
        private AnimationCurve _difficultCurve = AnimationCurve.Linear(0,0,1,0);
        private float _timeMultiplier = 0;
        private float _speed;

        public float Speed => _speed;

        public void Init(float startSpeed)
        {
            _startSpeed = startSpeed;
            _speed = _startSpeed;
            UpdateSpeed();
        }

        public void Init(float startSpeed, AnimationCurve difficultCurve, float timeMultiplier)
        {
            _startSpeed = startSpeed;
            _difficultCurve = difficultCurve;
            _timeMultiplier = timeMultiplier;
            UpdateSpeed();
        }

        public void UpdateSpeed()
        {
            _speed = _startSpeed + (_startSpeed * _difficultCurve.Evaluate(Time.timeSinceLevelLoad * _timeMultiplier));
        }

        public void Move()
        {
            _transform.Translate(Vector3.down* _speed * Time.deltaTime);
        }
    }
}
