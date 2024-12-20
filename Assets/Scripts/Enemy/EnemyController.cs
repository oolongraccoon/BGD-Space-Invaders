using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Movement boundaries for the enemy
    public float minPosX; 
    public float maxPosX; 

    // Movement configuration
    public float moveDistance = 1.5f; 
    public float timeStep = 0.3f;     // Time 

    public float countdown;          // Countdown timer for controlling movement when using countdown mode

    private bool isMovingRight = true;  // Tracks whether the enemy is moving to the right
    public bool isUsingCountdown = true;

    // Use this for initialization
    void Start()
    {
        if (isUsingCountdown)
        {
            countdown = timeStep;
        }
        else
        {
            // Invoke repeating will be called once after timeStep (2nd parameter) amount,
            // and then repeatedly every timeStep (3rd parameter) amount
            //InvokeRepeating("Move", timeStep, timeStep);
            InvokeRepeating("Move", timeStep, timeStep);
        }
    }


    // Called once per frame
    void Update()
    {
        if (isUsingCountdown)
        {
            countdown -= Time.deltaTime;

            // When countdown reaches zero, move the enemy and reset the timer
            if (countdown <= 0)
            {
                Move();
                countdown = timeStep;
            }
        }
    }

    // Handles the horizontal movement of the enemy
    void Move()
    {
        if (isMovingRight)
        {
            // Move the enemy to the right
            Vector3 currentPos = transform.position;
            Vector3 newPos = currentPos + new Vector3(moveDistance, 0f, 0f);
            transform.position = newPos;

            // Check if the enemy has reached the right boundary
            if (transform.position.x >= maxPosX)
            {
                isMovingRight = false; // Change direction
                MoveDown(); // Move down vertically
            }
        }
        else
        {
            // Move the enemy to the left
            Vector3 currentPos = transform.position;
            Vector3 newPos = currentPos - new Vector3(moveDistance, 0f, 0f);
            transform.position = newPos;

            // Check if the enemy has reached the left boundary
            if (transform.position.x <= minPosX)
            {
                isMovingRight = true; // Change direction
                MoveDown();  
            }
        }
    }

    // Handles the vertical movement when the enemy reaches a boundary
    void MoveDown()
    {
        Vector3 currentPos = transform.position;
        Vector3 newPos = currentPos - new Vector3(0f, moveDistance, 0f); // Move down by moveDistance
        transform.position = newPos;
    }
}
