/*
 * Keegan Graf
 * Updated 4/23/2023
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRef : MonoBehaviour
{
    public NavMeshAgent navMeshagent;
    public PlayerHealth playerHealth;
    [Header("Stats")]

    public float pathUpdateDelay = 0.2f;

    private void Awake(){
        navMeshagent = GetComponent<NavMeshAgent>();
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Player"){
            playerHealth.TakeDamage(20);
        }
    }
}
