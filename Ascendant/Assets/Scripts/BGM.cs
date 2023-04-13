using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class BGM : MonoBehaviour
{
    [SerializeField]
    private AudioSource backgroundMusic;
    [SerializeField]
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        if(backgroundMusic != null)
        {
            backgroundMusic.loop = true;
            backgroundMusic.clip = clip;
            backgroundMusic.Play();
        }
    }
}
