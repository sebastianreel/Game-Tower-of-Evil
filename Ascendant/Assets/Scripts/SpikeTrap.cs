using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [Header ("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header ("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    public int damage;
    public PlayerHealth playerHealth;
    private int time = 500;

    private void Awake(){
        initScale = enemy.localScale;
    }
    
    private void Update(){
        if (movingLeft){
            if (enemy.position.y <= leftEdge.position.y)
                MoveInDirection(1);
            else
                DirectionChange();
        }
        else{
            if (enemy.position.y >= rightEdge.position.y)
                MoveInDirection(-1);
            else
                DirectionChange();
        }

        time = time - 1;
        Debug.Log (time);
            
    }

    private void DirectionChange(){
        movingLeft = !movingLeft;
    }

    private void MoveInDirection(int _direction){
        
        //enemy.localScale = new Vector3(initScale.x, Mathf.Abs(initScale.y) * _direction, initScale.z);

        enemy.position = new Vector3(enemy.position.x, enemy.position.y + Time.deltaTime * _direction * speed, enemy.position.z);

    }
    private void OnTriggerEnter(Collider collision){
        if(collision.tag == "Player" && time <= 0){
            playerHealth.TakeDamage(damage);
            time = 500;
        }
    }
}
