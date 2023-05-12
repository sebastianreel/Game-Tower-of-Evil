using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSpikes : MonoBehaviour
{
    public int damage;
    public PlayerHealth playerHealth;
    private int time = 0;

    // Update is called once per frame
    void Update()
    {
        time--;
        // Debug.Log(time);
    }

    private void OnTriggerEnter(Collider collision){
        if(collision.tag == "Player" && time <= 0){
            FindObjectOfType<AudioManager>().Play("Cut");
            playerHealth.TakeDamage(damage);
            time = 200;
        }
    }
}
