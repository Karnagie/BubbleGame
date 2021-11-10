using Assets.Scripts.Bubbles;
using Assets.Scripts.Bubbles.Stats;
using NUnit.Framework;
using UnityEngine;

public class BubbleTests
{
    private Bubble _bubble;
    private BubbleMovement _movement;

    [SetUp]
    public void SetUp()
    {
        _bubble = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Bubble")).GetComponent<Bubble>();
        _movement = _bubble.gameObject.GetComponent<BubbleMovement>();
    }

    [Test]
    public void GoingTimer_IsEqual10_True()
    {
        float screenLength = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height, 0)).y*2;
        float speed = 1;
        float expectedTime = screenLength + _bubble.ObjectRadius;

        _movement.Init(speed);
        _bubble.InitRandom(new BubbleStats());

        Assert.AreEqual(expectedTime, _bubble.GoingTimer);
    }
}
