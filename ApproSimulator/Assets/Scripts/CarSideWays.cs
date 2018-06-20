using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSideWays : MonoBehaviour {

    public GameObject moveObject;
    public GameObject pointA;
    public GameObject pointB;
    public float Speed;

    private Vector2 startPos;
    private Vector2 endPos;

    void Start()
    {
        startPos = pointA.transform.position;
        endPos = pointB.transform.position;
    }
    void Update()
    {
        if (transform.position == pointA.transform.position)
        {
            transform.Rotate(new Vector3(0, 180, 0));
        }
        if (transform.position == pointB.transform.position)
        {
            transform.Rotate(new Vector3(0, -180, 0));
        }
        moveObject.transform.position = Vector2.Lerp(startPos, endPos, Mathf.PingPong(Time.time * Speed, 1.0f));
    }
}
