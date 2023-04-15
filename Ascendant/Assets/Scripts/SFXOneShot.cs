using System.Collections;
using UnityEngine;

public class SFXOneShot : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private AudioClip clip;
    [SerializeField]
    private float delay = 1.0f;
    
    public void playClip()
    {
        if(source!= null && clip != null)
        {
            source.PlayOneShot(clip);
        }
    }
    public void delayNext()
    {
        StartCoroutine(DelayAction());
    }

    private IEnumerator DelayAction()
    {
        yield return new WaitForSeconds(delay);
    }
}
