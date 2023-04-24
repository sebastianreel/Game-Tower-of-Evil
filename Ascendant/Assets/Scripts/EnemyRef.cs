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
    [Header("Stats")]

    public float pathUpdateDelay = 0.2f;

    private void Awake(){
        navMeshagent = GetComponent<NavMeshAgent>();
    }
}
