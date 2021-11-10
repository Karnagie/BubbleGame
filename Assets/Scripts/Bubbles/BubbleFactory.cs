using Assets.Scripts.Configs;
using Assets.Scripts.Core.Factory;
using UnityEngine;

namespace Assets.Scripts.Bubbles
{
    [CreateAssetMenu(fileName = "BubbleFactory", menuName = "Factories/Bubble")]
    public class BubbleFactory : GameObjectFactory
    {
        [SerializeField] private Bubble _prefab;
        [SerializeField] private DifficultConfig _difficult;
        [SerializeField] private BubbleStatsConfig _stats;

        public void Delete(Bubble bubble)
        {
            bubble.Destroy();
        }

        public Bubble GetRandom()
        {
            Bubble bubble = CreateGameObjectInstance(_prefab);
            BubbleMovement movement = bubble.gameObject.GetComponent<BubbleMovement>();
            float spread = _difficult.StartSpeed / 4;
            float randomSpeed = Random.Range(_difficult.StartSpeed - spread, _difficult.StartSpeed + spread);
            movement.Init(randomSpeed, _difficult.DificultCurve, _difficult.TimeMultiplier);
            bubble.InitRandom(_stats.GetStats());
            return bubble;
        }
    }
}
