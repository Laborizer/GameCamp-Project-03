using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Boolean facingRight;
    private float delta;

    public float randomPushVer;
    public float randomPushHor;

    public float standingRandomPushVer;
    public float standingRandomPushHor;

    public int nextUpdate = 1;

    public float walkSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        delta = Time.deltaTime;
        if (Time.time >= nextUpdate)
        {
            DrunkAutoMove();
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (!facingRight)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                facingRight = true;
            }
            //transform.position += Vector3.right * delta;
            rb.MovePosition(new Vector2(transform.position.x + walkSpeed + (randomPushVer/2),transform.position.y + (randomPushHor/2)));
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (facingRight)
            {
                transform.Rotate(new Vector3(0, -180, 0));
                facingRight = false;
            }
            //transform.position -= Vector3.right * delta;
            rb.MovePosition(new Vector2(transform.position.x - walkSpeed + (randomPushVer / 2), transform.position.y + (randomPushHor / 2)));
        }

        if (Input.GetKey(KeyCode.W))
        {
            //transform.position += Vector3.up * delta;
            rb.MovePosition(new Vector2(transform.position.x + (randomPushVer / 2), transform.position.y + walkSpeed + (randomPushHor / 2)));
        }

        if (Input.GetKey(KeyCode.S))
        {
            //transform.position += Vector3.down * delta;
            rb.MovePosition(new Vector2(transform.position.x + (randomPushVer / 2), transform.position.y - walkSpeed + (randomPushHor / 2)));
        }
    }

    private void DrunkAutoMove()
    {
        randomPushVer = UnityEngine.Random.Range(-0.01f, 0.01f);
        randomPushHor = UnityEngine.Random.Range(-0.01f, 0.01f);
        standingRandomPushHor = UnityEngine.Random.Range(-5f, 5f);
        standingRandomPushVer = UnityEngine.Random.Range(-5f, 5f);
        rb.AddForce(new Vector2(standingRandomPushVer, standingRandomPushHor));
    }
}
