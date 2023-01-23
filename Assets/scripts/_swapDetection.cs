using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class _swapDetection : MonoBehaviour
{
    //public vars
    
    //private vars
    private _inputManger inputManger;
    private Vector2 startPosition, endPosition;
    private float startTime, endTime;
    [SerializeField] private float minDistance = .2f;
    [SerializeField] private float maxTime = 1f;
    [SerializeField, Range(0f, 1f)] private float directionThreshold = .9f;

    private void Awake()
    {
        inputManger = _inputManger.Instance;
    }

    private void OnEnable()
    {
        inputManger.OnStartTouch += SwipeStart;
        inputManger.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        inputManger.OnStartTouch -= SwipeStart;
        inputManger.OnEndTouch -= SwipeEnd;
    }

    private void SwipeStart(Vector2 position, float time)
    {
        startPosition = position;
        startTime = time;
    }
    
    private void SwipeEnd(Vector2 position, float time)
    {
        endPosition = position;
        endTime = time;
        DetectSwipe();
    }

    private void DetectSwipe()
    {
        if (Vector3.Distance(startPosition, endPosition) >= minDistance &&
            (endTime - startTime) <= maxTime)
        {
            Debug.DrawLine(startPosition, endPosition, Color.red, 5f);
            Vector3 direction = endPosition - startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }

    private void SwipeDirection(Vector2 direction)
    {
        if (Vector2.Dot(Vector2.up, direction) > directionThreshold)
        {
            Debug.Log("Swipe Up");
        }
        
        if (Vector2.Dot(Vector2.down, direction) > directionThreshold)
        {
            Debug.Log("Swipe Down");
        }
        
        if (Vector2.Dot(Vector2.left, direction) > directionThreshold)
        {
            Debug.Log("Swipe Left");
        }
        
        if (Vector2.Dot(Vector2.right, direction) > directionThreshold)
        {
            Debug.Log("Swipe Right");
        }
        
    }
}
