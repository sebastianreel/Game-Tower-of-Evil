using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/*
 Sebastian Reel
 CS 328 - Game Design
 */

public class NextLevel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("LevelOne");
    }
}
