using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bar1Door : MonoBehaviour {

    public bool canEnter;
    public string door;
    public bool isGrapped;

	// Use this for initialization
	void Start () {
        isGrapped = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(canEnter && Input.GetKeyDown(KeyCode.E))
        {
            if (door != "Game")
            {
                GlobalControl.Instance.previousDoor = door;
            }
            SceneManager.LoadScene(door);
        }
        if (canEnter && isGrapped)
        {
            isGrapped = false;
            SceneManager.LoadScene("Game");
        }
	}

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player") {
            canEnter = true;
            door = transform.name.ToString();
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            door = "";
            canEnter = false;
        }
    }
}
