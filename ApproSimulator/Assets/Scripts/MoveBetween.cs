using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetween : MonoBehaviour {


    public GameObject moveObject;
    public GameObject pointA;
    public GameObject pointB;
    public float Speed;

    private Vector2 startPos;
    private Vector2 endPos;

    private bool lookRight;
    
    void Start()
    {
        startPos = pointA.transform.position; 
        endPos = pointB.transform.position;
    }
    void Update()
    {
        if (transform.position == pointA.transform.position)
        {
            lookRight = true;
        } else if(transform.position == pointB.transform.position)
        {
            lookRight = false;
        }

        if (lookRight)
        {
            Vector3 targetPos = pointA.transform.position;
            Vector3 targetPosFlattened = new Vector3(targetPos.x, targetPos.y, 0);
            transform.LookAt(targetPosFlattened);
        }
        else
        {
            Vector3 targetPos = pointB.transform.position;
            Vector3 targetPosFlattened = new Vector3(targetPos.x, targetPos.y, 0);
            transform.LookAt(targetPosFlattened);
        }
        moveObject.transform.position = Vector2.Lerp(startPos,endPos, Mathf.PingPong(Time.time * Speed, 1.0f));
    }
}
