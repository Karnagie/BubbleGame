using System.Collections;
using Assets.Scripts.Bubbles;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BubbleMovementTests
{
    private GameObject _bubble;
    private BubbleMovement _movement;

    [SetUp]
    public void SetUp()
    {
        _bubble = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Bubble"));
        _movement = _bubble.gameObject.GetComponent<BubbleMovement>();
    }

    [UnityTest]
    public IEnumerator Bubble_MoveToEndOfScreen_Negative5()
    {
        float camSize = 5;
        float screenLength = camSize * 2;
        float speed = 5;
        float expectedTime = screenLength / speed;
        _bubble.transform.position = Vector3.up * camSize;
        _movement.Init(speed);

        yield return new WaitForSeconds(expectedTime);

        Assert.AreEqual(-5f, Mathf.Round(_bubble.transform.position.y));
    }
}
