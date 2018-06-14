using UnityEngine;
using System.Collections;

public class EnemyNPC : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Player").transform.position, (Time.deltaTime/2));
    }

}