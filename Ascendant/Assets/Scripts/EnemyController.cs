using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int health, maxHealth = 3;
    [SerializeField] float moveSpeed = 5f;
    public GameObject player;
    //Transform target; // use this to chase the player 

    bool lookat = false;
    Rigidbody rb;
    public float speed = 10;
    public float multiplier = 10;
    public float speed_limit = 2;
    Vector3 vel; // used for movement direction towards player


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        health = maxHealth;
        //target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (PlayerDetection.found)
        {
            lookat = true;
        }
        if (lookat)
        {
            transform.LookAt(player.transform);
            if (!PlayerDetection.found && vel.x > -2 && vel.x < 2 && vel.z > -2 && vel.z < 2)
            {
                rb.AddForce(speed * multiplier * Time.deltaTime * transform.forward);
            }
        }
    }
}
