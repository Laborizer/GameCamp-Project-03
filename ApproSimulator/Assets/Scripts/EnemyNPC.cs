﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyNPC : MonoBehaviour
{

    GameObject enemy;
    GameObject player;
    GameObject door;

    public bool canGrapple;

    void Start()
    {
        enemy = GameObject.Find("EnemyNPC");
        player = GameObject.Find("Player");
        door = GameObject.Find("Game");

        player.GetComponent<Player>().transform.parent = null;
        canGrapple = false;
    }

    void Update()
    {
        if(!canGrapple)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, (Time.deltaTime));
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, door.transform.position, (Time.deltaTime));
        }
        
        if(canGrapple)
        {
            grapple();
        }
    }

    void grapple()
    {
        player.GetComponent<Player>().isGrabbed = true;
        player.GetComponent<Player>().transform.parent = transform;
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            canGrapple = true;
        }

        if (obj.gameObject.tag == "Door" && canGrapple)
        {
            SceneManager.LoadScene("Game");
        }
    }

    private void OnCollisionExit2D(Collision2D obj)
    {

    }
}