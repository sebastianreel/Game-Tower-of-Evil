using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

/*
Sebastian Reel
CS 328 - Game Desgin
*/

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    public bool chase = false;
    public Transform startingPoint;
    private GameObject player;
    public Transform target;

    public int damage;
    public PlayerHealth playerHealth;
    private int time = 500;



    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }
        if (chase == true)
        {
            Chase();
        } else
        {
            ReturnStartPoint();
        }
        time = time - 1;

        LookatPlayer();
    }

    private void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }

    private void LookatPlayer()
    {
        Vector3 look = target.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(look);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.3f);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player" && time <= 0)
        {
            playerHealth.TakeDamage(damage);
            time = 500;
        }
    }

}
