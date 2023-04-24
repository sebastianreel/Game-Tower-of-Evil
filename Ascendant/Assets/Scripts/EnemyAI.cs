using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;

    private EnemyRef enemyRef;

    private float pathUpdateDeadline;

    private float AttackDistance;

    private void Awake(){
        enemyRef = GetComponent<EnemyRef>();
    }

    void Start(){
        AttackDistance = enemyRef.navMeshagent.stoppingDistance;
    }

    void Update(){
        if(target != null){

            bool inRange = Vector3.Distance(transform.position, target.position) <= AttackDistance;

            if(inRange){
                TargetLock();
            }
            else{
                UpdatePath();
            }
        }
    }

    private void TargetLock(){
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    private void UpdatePath(){
        if(Time.time >= pathUpdateDeadline){
            Debug.Log("Updating Path");
            pathUpdateDeadline = Time.time + enemyRef.pathUpdateDelay;
            enemyRef.navMeshagent.SetDestination(target.position);
        }
    }
}
