using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DynamicSpikeTrap : MonoBehaviour
{
    #region Serialize Fields
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float trapTime;
    #endregion

    #region variables
    private float timer = 0.0f;
    #endregion

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(timer > trapTime)
            {
                anim.SetBool("Raised", true);
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
    }
}
