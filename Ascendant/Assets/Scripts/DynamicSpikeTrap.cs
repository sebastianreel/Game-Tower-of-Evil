using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class DynamicSpikeTrap : MonoBehaviour
{
    #region Serialize Fields
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float trapTime;
    [SerializeField]
    private AudioClip clip;
    [SerializeField]
    private AudioSource source;
    #endregion

    #region variables
    private float timer = 0.0f;
    private bool played = false;
    #endregion

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(timer > trapTime)
            {
                anim.SetBool("Raised", true);
                playTrapClip();
                played= true;
            }
            timer += Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            anim.SetBool("Raised", false);
        }
        timer = 0.0f;
        played = false; 
    }

    private void playTrapClip()
    {
        if (source != null && clip != null && !played)
        {
            source.PlayOneShot(clip);
        }
    }
}
