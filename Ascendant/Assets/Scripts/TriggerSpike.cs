using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpike : MonoBehaviour
{
    private bool trigger = false;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision){
        if (collision.tag == "Player"){
            FindObjectOfType<AudioManager>().Play("spike_trap");
            trigger = true;
        }
    }

    private void OnTriggerExit(Collider collision){
        if (collision.tag == "Player"){
            trigger = false;
        }
    }

    public bool triggerSpike(){
        return trigger;
    }
}
