using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EnemyNPC : MonoBehaviour
{
    AudioSource audiosource;
    public AudioClip getOut;

    GameObject player;
    GameObject door;

    public bool canGrapple;
    bool soundPlayed;
    public string debug;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();

        player = GameObject.Find("Player");
        door = GameObject.Find("Game");

        player.GetComponent<Player>().transform.parent = null;
        canGrapple = false;
        soundPlayed = false;
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
        player.GetComponent<Player>().canMove = false;
        player.GetComponent<Player>().transform.parent = transform;
        door.GetComponent<Bar1Door>().isGrapped = true;
    }

    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "Player" && !soundPlayed)
        {
            audiosource.PlayOneShot(getOut, 2f);
            canGrapple = true;
            soundPlayed = true;
        }
    }

    private void OnCollisionExit2D(Collision2D obj)
    {

    }
}