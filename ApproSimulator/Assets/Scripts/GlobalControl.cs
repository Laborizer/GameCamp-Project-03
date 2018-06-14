using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour {

    public static GlobalControl Instance;
    public bool facingRight;
    public float randomPushVer;
    public float randomPushHor;
    public float standingRandomPushVer;
    public float standingRandomPushHor;
    public int nextUpdate = 1;
    public float drunkLevelStand;
    public float drunkLevelWalk;
    public bool drunk;
    public float walkSpeed;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
