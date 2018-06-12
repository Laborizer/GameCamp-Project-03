using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bar1Door : MonoBehaviour {

    bool canEnter;

	// Use this for initialization
	void Start () {
        canEnter = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(canEnter && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Bar1");
        }

        canEnter = false;
	}

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            canEnter = true;
        }
    }
}
