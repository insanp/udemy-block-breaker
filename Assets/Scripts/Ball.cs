using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] Vector2 initialVelocity;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float minimumVelocity = 3.0f;

    bool hasStarted = false;
    private AudioSource audioSource;
    private Rigidbody2D ballRB;

    // state
    Vector2 paddleToBallVector;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        hasStarted = false;
        audioSource = GetComponent<AudioSource>();
        ballRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // click left mouse
            ballRB.velocity = initialVelocity;
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            UnstuckBall();

            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
        }
    }

    private void UnstuckBall()
    {
        Debug.Log(ballRB.velocity);
        bool corrected = false;
        Vector2 newV = ballRB.velocity;

        if (ballRB.velocity.x < minimumVelocity && ballRB.velocity.x > -minimumVelocity)
        {
            Debug.Log("Correcting velocity x");
            if (ballRB.velocity.x > 0f)
            {
                newV.Set(minimumVelocity, ballRB.velocity.y);
            }
            else
            {
                newV.Set(-minimumVelocity, ballRB.velocity.y);
            }

            corrected = true;
        }

        if (ballRB.velocity.y < minimumVelocity && ballRB.velocity.y > -minimumVelocity)
        {
            Debug.Log("Correcting velocity y");
            if (ballRB.velocity.y > 0f)
            {
                newV.Set(ballRB.velocity.x, minimumVelocity);
            }
            else
            {
                newV.Set(ballRB.velocity.x, -minimumVelocity);
            }

            corrected = true;
        }

        if (corrected)
        {
            ballRB.velocity = newV;
        }
    }
}
