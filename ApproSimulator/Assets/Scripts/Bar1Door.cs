using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bar1Door : MonoBehaviour {

    public bool canEnter;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(canEnter && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Bar1");
        }
	}

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player") {
            canEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.tag == "Player")
        {
            canEnter = false;
        }
    }
}
