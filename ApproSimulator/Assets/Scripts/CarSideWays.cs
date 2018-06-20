using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSideWays : MonoBehaviour {

    public AudioSource audiosource;

    public GameObject moveObject;
    public GameObject pointA;
    public GameObject pointB;
    public float Speed;

    private Vector2 startPos;
    private Vector2 endPos;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.Play();

        startPos = pointA.transform.position;
        endPos = pointB.transform.position;
    }
    void Update()
    {
        transform.Rotate(Vector3.forward, 200f * Time.deltaTime);
        moveObject.transform.position = Vector2.Lerp(startPos, endPos, Mathf.PingPong(Time.time * Speed, 1.0f));
    }
}
