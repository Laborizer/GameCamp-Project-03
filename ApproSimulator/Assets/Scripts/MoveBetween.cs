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
    private float currentLerpTime = 0;
    
    void Start()
    {
        startPos = pointA.transform.position; 
        endPos = pointB.transform.position;
    }
    void Update()
    {
        moveObject.transform.position = Vector2.Lerp(startPos,endPos, Mathf.PingPong(Time.time * Speed, 1.0f));
    }
}
