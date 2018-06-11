using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Rigidbody2D rb;
    private Boolean facingRight;

    public float speed;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Move(moveHorizontal,moveVertical);
	}

    private void Move(float moveHorizontal, float moveVertical)
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (!facingRight)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                facingRight = true;
            }
            transform.position += Vector3.right * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (facingRight)
            {
                transform.Rotate(new Vector3(0, -180, 0));
                facingRight = false;
            }
            transform.position -= Vector3.right * speed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * speed;
        }
    }
}
