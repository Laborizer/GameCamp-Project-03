using UnityEngine;
using System.Collections;

public class EnemyNPC : MonoBehaviour
{

    GameObject enemy;
    GameObject player;

    public bool canGrapple;

    void Start()
    {
        enemy = GameObject.Find("EnemyNPC");
        player = GameObject.Find("Player");

        player.GetComponent<Player>().transform.parent = null;
        canGrapple = false;
    }

    void Update()
    {
        if(!canGrapple)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, (Time.deltaTime / 2));
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Game").transform.position, (Time.deltaTime /2));
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
        canGrapple = true;
    }

    private void OnCollisionExit2D(Collision2D obj)
    {

    }

}