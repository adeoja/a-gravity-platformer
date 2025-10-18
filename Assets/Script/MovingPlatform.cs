using System;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 startPosition;
    [SerializeField] private Vector3 moveDistance;
    [SerializeField] private float platformSpeed = 2;
    [SerializeField] private bool movingPlatform;
    private Vector3 endPosition;
    private float t;
    private bool shouldMove = false;
    private bool moveToEnd = true;

    

    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition + moveDistance;
    }

    void Update()
    {
        if (shouldMove && !movingPlatform) // Only move when triggered
        {
            t += Time.deltaTime * platformSpeed;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
        }

        if (movingPlatform)
        {
            t += Time.deltaTime * platformSpeed; 
            
            // Move platform between points
            if (moveToEnd)
            {
                transform.position = Vector3.Lerp(startPosition, endPosition, t);
            
                if (t >= 1f) // Reached end point
                {
                    moveToEnd = false;
                    t = 0f;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(endPosition, startPosition, t);
            
                if (t >= 1f) // Reached start point
                {
                    moveToEnd = true;
                    t = 0f;
                }
            }
        }
    }

    public void StartMoving() // start movement on trigger
    {
        shouldMove = true;
    }
}