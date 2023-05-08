using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    Transform mainCam;
    Transform block;
    Transform worldSpaceCanvas;

    public Vector3 offset;

    void Start()
    {
        mainCam = Camera.main.transform;
        block = transform.parent;
        worldSpaceCanvas = GameObject.FindObjectOfType<Canvas>().transform;

        transform.SetParent(worldSpaceCanvas);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position);
        transform.position = block.position + offset;
        
    }
}
