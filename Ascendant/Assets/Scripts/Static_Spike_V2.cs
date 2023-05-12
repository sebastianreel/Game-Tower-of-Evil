/*Created by: Gerard
 * Updated by: Antonio Massa
 * Last updated: 05/11/2023
 */
using UnityEngine;

public class Static_Spike_V2 : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField]
    private int damage;
    [SerializeField]
    private float trapTime;
    [SerializeField]
    PlayerHealth PH;
    #endregion

    #region variables
    private float trapTimer;

    #endregion

    #region OnTrigger Functions
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PH.TakeDamage(damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && trapTimer >= trapTime)
        {
            PH.TakeDamage(damage);
            trapTimer= 0;
        }
        trapTimer += Time.deltaTime;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trapTimer = 0;
        }
    }
    #endregion
}
