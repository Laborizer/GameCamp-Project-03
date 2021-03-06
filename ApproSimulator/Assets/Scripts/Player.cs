﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject gameOverPanel;
    public GameObject winPanel;
    public GameObject menu;

    bool deathSoundPlayed;

    public bool canMove;
    public bool onDoor;
    public float peeEmergency;
    public Text beerCountText;
    public int beerCount = 0;

    private Rigidbody2D rb;
    private Boolean facingRight;
    public float randomPushVer;
    public float randomPushHor;
    public float standingRandomPushVer;
    public float standingRandomPushHor;
    public int nextUpdate = 1;
    public float drunkLevelStand;
    public float drunkLevelWalk;
    public Boolean drunk = false;
    public float walkSpeed;
    public string previousDoor;

    public AudioClip gulp;
    public AudioClip deathScream;
    public AudioClip impact;
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        deathSoundPlayed = false;
        gameOverPanel.SetActive(false);
        winPanel.SetActive(false);
        menu.SetActive(false);
        canMove = true;
        beerCountText.text = "Beers: " + beerCount.ToString() + "/20";

        peeEmergency = GlobalControl.Instance.peeEmergency;
        previousDoor = "";
        rb = GetComponent<Rigidbody2D>();
        drunk = GlobalControl.Instance.drunk;
        previousDoor = GlobalControl.Instance.previousDoor;
        if (drunk)
        {
            facingRight = GlobalControl.Instance.facingRight;
            randomPushVer = GlobalControl.Instance.randomPushVer;
            randomPushHor = GlobalControl.Instance.randomPushHor;
            standingRandomPushVer = GlobalControl.Instance.standingRandomPushVer;
            standingRandomPushHor = GlobalControl.Instance.standingRandomPushHor;
            nextUpdate = GlobalControl.Instance.nextUpdate;
            drunkLevelStand = GlobalControl.Instance.drunkLevelStand;
            drunkLevelWalk = GlobalControl.Instance.drunkLevelWalk;
            walkSpeed = GlobalControl.Instance.walkSpeed;
            beerCountText.text = "Beers: " + GlobalControl.Instance.beerCount.ToString() + "/20";
            beerCount = GlobalControl.Instance.beerCount;
        }
        if (!String.IsNullOrEmpty(previousDoor))
        {
            getDoorLocation(GlobalControl.Instance.previousDoor);
        }
    }

    private void getDoorLocation(String door)
    {
        var doorLoc = GameObject.Find(door);
        if (doorLoc)
        {
            transform.position = doorLoc.transform.position;
        }
    }

    void FixedUpdate()
    {
        Move();
        checkGameOver();
        checkWin();
        Piss();
    }

    private void checkWin()
    {
        if (beerCount == 20)
        {
            canMove = false;
            winPanel.SetActive(true);
            menu.SetActive(true);
        }
    }

    private void Piss()
    {
        if (Input.GetKey(KeyCode.Space) && peeEmergency >= 0)
        {
            peeEmergency -= 0.003f;
            if (drunkLevelStand >= 0f)
            {
                drunkLevelStand -= 0.001f;
            }

            if (walkSpeed <= 0.021f)
            {
                walkSpeed += 0.00001f;
            }
            if (drunkLevelWalk >= 0)
            {
                drunkLevelWalk -= 0.001f;
            }
        }
    }

    private void checkGameOver()
    {
        if(peeEmergency >= 1f)
        {
            canMove = false;
            gameOverPanel.SetActive(true);
            menu.SetActive(true);
            if(!deathSoundPlayed)
            {
                deathSoundPlayed = true;
                audioSource.PlayOneShot(deathScream, 1F);
            }
        }
    }

    public void ForceSave()
    {
        GlobalControl.Instance.drunk = this.drunk;
        GlobalControl.Instance.drunkLevelStand = this.drunkLevelStand;
        GlobalControl.Instance.drunkLevelWalk = this.drunkLevelWalk;
        GlobalControl.Instance.facingRight = this.facingRight;
        GlobalControl.Instance.nextUpdate = this.nextUpdate;
        GlobalControl.Instance.randomPushHor = this.randomPushHor;
        GlobalControl.Instance.randomPushVer = this.randomPushVer;
        GlobalControl.Instance.walkSpeed = this.walkSpeed;
        GlobalControl.Instance.standingRandomPushVer = this.standingRandomPushVer;
        GlobalControl.Instance.standingRandomPushHor = this.standingRandomPushHor;
        GlobalControl.Instance.peeEmergency = this.peeEmergency;
        GlobalControl.Instance.beerCount = this.beerCount;
    }

    private void Move()
    {
        peeEmergency += 0.1f / 1600f;

        if (Time.time >= nextUpdate && drunk && canMove)
        {
            DrunkAutoMove();
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
        } else if(!drunk)
        {
            DrunkReset();
        }

        if (Input.GetKey(KeyCode.D) && canMove)
        {
            if (!facingRight)
            {
                transform.Rotate(new Vector3(0, 180, 0));
                facingRight = true;
            }
            //transform.position += Vector3.right * delta;
            rb.MovePosition(new Vector2(transform.position.x + walkSpeed + (randomPushVer/2),transform.position.y + (randomPushHor/2)));
        }

        if (Input.GetKey(KeyCode.A) && canMove)
        {
            if (facingRight)
            {
                transform.Rotate(new Vector3(0, -180, 0));
                facingRight = false;
            }
            //transform.position -= Vector3.right * delta;
            rb.MovePosition(new Vector2(transform.position.x - walkSpeed + (randomPushVer / 2), transform.position.y + (randomPushHor / 2)));
        }

        if (Input.GetKey(KeyCode.W) && canMove)
        {
            //transform.position += Vector3.up * delta;
            rb.MovePosition(new Vector2(transform.position.x + (randomPushVer / 2), transform.position.y + walkSpeed + (randomPushHor / 2)));
        }

        if (Input.GetKey(KeyCode.S) && canMove)
        {
            //transform.position += Vector3.down * delta;
            rb.MovePosition(new Vector2(transform.position.x + (randomPushVer / 2), transform.position.y - walkSpeed + (randomPushHor / 2)));
        }
    }

    private void DrunkReset()
    {
        randomPushVer = 0f;
        randomPushHor = 0f;
        standingRandomPushHor = 0f;
        standingRandomPushVer = 0f;
        rb.velocity = new Vector2(0f,0f);
    }

    private void DrunkAutoMove()
    {
        randomPushVer = UnityEngine.Random.Range(-drunkLevelWalk, drunkLevelWalk);
        randomPushHor = UnityEngine.Random.Range(-drunkLevelWalk, drunkLevelWalk);
        standingRandomPushHor = UnityEngine.Random.Range(-drunkLevelStand, drunkLevelStand);
        standingRandomPushVer = UnityEngine.Random.Range(-drunkLevelStand, drunkLevelStand);
        rb.AddForce(new Vector2(standingRandomPushVer, standingRandomPushHor));
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Alcohol")
        {
            audioSource.PlayOneShot(gulp, 5F);
            peeEmergency += 0.19f;

            if (drunkLevelStand <= 3f)
            {
                drunkLevelStand += 1f;
            }

            if (walkSpeed >= 0.005f)
            {
                walkSpeed -= 0.001f;
            }
            if (drunkLevelWalk <= 0.01f)
            {
                drunkLevelWalk += 0.001f;
            }
            beerCount++;
            beerCountText.text = "Beers: " + beerCount.ToString() + "/20";
            Destroy(col.gameObject);
            drunk = true;
        }

        if (col.gameObject.tag == "Car")
        {
            audioSource.PlayOneShot(impact, 7F);
            audioSource.PlayOneShot(deathScream, 1F);
            canMove = false;
            gameOverPanel.SetActive(true);
            menu.SetActive(true);
        }
    }
}
