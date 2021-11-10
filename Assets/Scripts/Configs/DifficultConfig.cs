using UnityEngine;

namespace Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Difficult", menuName = "Configs/Difficult")]
    public class DifficultConfig : ScriptableObject
    {
        [SerializeField] private float _startSpeed = 1;
        [SerializeField] private AnimationCurve _dificultCurve;
        [SerializeField] private float _timeMultiplier = 0.1f;

        public float StartSpeed => _startSpeed;
        public AnimationCurve DificultCurve => _dificultCurve;
        public float TimeMultiplier => _timeMultiplier;
    }
}
