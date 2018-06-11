using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Boolean facingRight;
    private float delta;
    private float timer;
    private float randomPushVer;
    private float randomPushHor;

    //public float speed;
    //public float drunkness;
    //public float amplitude;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("DrunkAutoMove", 0.5f,0.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        delta = Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
        {
            if (!facingRight)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                facingRight = true;
            }
            transform.position += Vector3.right * delta;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (facingRight)
            {
                transform.Rotate(new Vector3(0, -180, 0));
                facingRight = false;
            }
            transform.position -= Vector3.right * delta;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * delta;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * delta;
        }
    }

    private void DrunkAutoMove()
    {
        randomPushVer = UnityEngine.Random.Range(-5f, 5f);
        randomPushHor = UnityEngine.Random.Range(-5f, 5f);
        rb.AddForce(new Vector2(randomPushHor, randomPushVer));
    }
}
