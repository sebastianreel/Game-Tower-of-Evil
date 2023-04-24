/*
 * Keegan Graf
 * Updated 4/23/2023
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    void OnTriggerEnter(Collider other){
        SceneManager.LoadScene("EndLevel");
    }

}
