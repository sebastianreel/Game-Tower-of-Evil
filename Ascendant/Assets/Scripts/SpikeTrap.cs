using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public TriggerSpike triggerSpike;
    public Transform startingPoint;
    
    [Header ("Patrol Points")]
    [SerializeField] private Transform top;
    [SerializeField] private Transform bot;

    [Header ("Enemy")]
    [SerializeField] private Transform enemy;

    [Header ("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    public int damage;
    public PlayerHealth playerHealth;
    private int time = 500;
    private bool trigger;

    private void Awake(){
        initScale = enemy.localScale;
    }
    
    private void Update(){
        trigger = triggerSpike.triggerSpike();

        if (trigger == true)
        {
            FindObjectOfType<AudioManager>().Play("spike_trap");
            if (!movingLeft){
                if (enemy.position.y <= top.position.y)
                    MoveInDirection(1);
            }
        }else{
            ReturnStartPoint();
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
    private void ReturnStartPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }
}
