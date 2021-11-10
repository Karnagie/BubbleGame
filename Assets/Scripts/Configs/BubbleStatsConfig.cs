using Assets.Scripts.Bubbles.Stats;
using UnityEngine;

namespace Assets.Scripts.Configs
{
    [CreateAssetMenu(fileName = "BubbleStats", menuName = "Configs/BubbleStats")]
    public class BubbleStatsConfig : ScriptableObject
    {
        [SerializeField] private float _defaultDamage;
        [SerializeField] private float _damageSpread;

        [SerializeField] private float _defaultScore;
        [SerializeField] private float _scoreSpread;

        public float DefaultDamage => _defaultDamage;
        public float DamageSpread => _damageSpread;
        public float DefaultScore => _defaultScore;
        public float ScoreSpread => _scoreSpread;

        public BubbleStats GetStats()
        {
            return new BubbleStats(_defaultDamage, _damageSpread, _defaultDamage, _scoreSpread);
        }
    }
}
