using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private Boolean facingRight;
    private float delta;

    public float speed;
    public float drunkness;
    public float amplitude;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {
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
            transform.position += Vector3.right * delta * (Mathf.Sin(drunkness) * amplitude);
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (facingRight)
            {
                transform.Rotate(new Vector3(0, -180, 0));
                facingRight = false;
            }
            transform.position -= Vector3.right * delta * (Mathf.Sin(drunkness) * amplitude);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.up * delta * (Mathf.Sin(drunkness) * amplitude);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.down * delta * (Mathf.Sin(drunkness) * amplitude);
        }
    }
}
