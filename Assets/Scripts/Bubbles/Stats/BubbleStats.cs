using UnityEngine;

namespace Assets.Scripts.Bubbles.Stats
{
    public struct BubbleStats
    {
        private float _damage;
        private float _score;
        private Color _color;

        private float _defaultDamage;
        private float _damageSpread;

        private float _defaultScore;
        private float _scoreSpread;

        public float Damage => _damage;
        public float Score => _score;
        public Color Color => _color;

        public BubbleStats(float damage, float score)
        {
            _defaultDamage = damage;
            _damageSpread = 0;
            _damage = _defaultDamage;

            _defaultScore = score;
            _scoreSpread = 0;
            _score = _defaultScore;

            _color = new Color();
        }

        public BubbleStats(float defaultDamage, float damageSpread, float defaultScore, float scoreSpread)
        {
            _defaultDamage = defaultDamage;
            _damageSpread = damageSpread;
            _damage = _defaultDamage;

            _defaultScore = defaultScore;
            _scoreSpread = scoreSpread;
            _score = _defaultScore;

            _color = new Color();
        }

        public void Randomize()
        {
            float randomDamage = Random.Range(_defaultDamage - _damageSpread, _defaultDamage + _damageSpread);
            _damage = randomDamage;

            float randomScore = Random.Range(_defaultScore - _scoreSpread, _defaultScore + _scoreSpread);
            _score = randomScore;

            Color randomColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            _color = randomColor;
        }
    }
}
