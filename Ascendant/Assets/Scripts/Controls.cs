using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField]    
    Transform mainCam;
    [SerializeField]
    private Transform worldSpaceCanvas;
    [SerializeField]
    private Vector3 offset;
    #endregion
    #region Unity Functions
    void Start()
    {
        mainCam = Camera.main.transform;
        transform.position = transform.parent.position + offset; 
        transform.SetParent(worldSpaceCanvas);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.transform.position);
    }
    #endregion
}
