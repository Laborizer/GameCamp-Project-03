using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public GameObject gameOverPanel;
    public Text gameOverText;

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
        gameOverPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        checkGameOver();
	}

    private void checkGameOver()
    {
        player.GetComponent<Player>().canMove = false;
        gameOverPanel.SetActive(true);
    }
}
