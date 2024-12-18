using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float minPosX;
    public float maxPosX;

    public float moveDistance = 1f;
    public float timeStep = 1f;
    public float countdown;

    private bool isMovingRight = true;
    public bool isUsingCountdown = true;

    void Start()
    {
        if (isUsingCountdown)
        {
            countdown = timeStep;
        }
        else
        {
            InvokeRepeating("Move", timeStep, timeStep);
        }
    }

    void Update()
    {
        if (isUsingCountdown)
        {
            countdown -= Time.deltaTime;

            if (countdown <= 0)
            {
                Move();
                countdown = timeStep;
            }
        }
    }

    void Move()
    {
        if (isMovingRight)
        {
            Vector3 currentPos = transform.position;
            Vector3 newPos = currentPos + new Vector3(moveDistance, 0f, 0f);
            transform.position = newPos;

            if (transform.position.x >= maxPosX)
            {
                isMovingRight = false;
                MoveDown();
            }
        }
        else
        {
            Vector3 currentPos = transform.position;
            Vector3 newPos = currentPos - new Vector3(moveDistance, 0f, 0f);
            transform.position = newPos;

            if (transform.position.x <= minPosX)
            {
                isMovingRight = true;
                MoveDown();
            }
        }
    }

    void MoveDown()
    {
        Vector3 currentPos = transform.position;
        Vector3 newPos = currentPos - new Vector3(0f, moveDistance, 0f);
        transform.position = newPos;
    }
}
