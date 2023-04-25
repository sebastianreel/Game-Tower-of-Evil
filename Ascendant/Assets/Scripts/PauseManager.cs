using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField] 
    private GameObject creditsMenu;
    [SerializeField]
    private Button resume;
    [SerializeField]
    private Button mainMenu;
    [SerializeField]
    private Button controls;
    [SerializeField]
    private Button quit;
    [SerializeField]
    private Button back;
    #endregion

    public static bool paused = false;
    private void Start()
    {
        resume.onClick.AddListener(ResumeButtonClicked);
        mainMenu.onClick.AddListener(mainMenuButtonClicked);
        controls.onClick.AddListener(controlsButtonClicked);
        quit.onClick.AddListener(quitButtonClicked);
        back.onClick.AddListener(backButtonClicked);
    }

    private void OnDestroy()
    {
        resume.onClick.RemoveAllListeners();
        mainMenu.onClick.RemoveAllListeners();
        controls.onClick.RemoveAllListeners();
        quit.onClick.RemoveAllListeners();
        back.onClick.RemoveAllListeners();
    }

    private void backButtonClicked()
    {
        creditsMenu.SetActive(false);
        pauseMenu.SetActive(true);
        controls.Select();
    }

    private void quitButtonClicked()
    {
        Application.Quit();
    }

    private void controlsButtonClicked()
    {
        pauseMenu.SetActive(false);
        creditsMenu.SetActive(true);
        back.Select();
    }

    private void mainMenuButtonClicked()
    {
        Time.timeScale = 1.0f;
        paused= false;
        SceneManager.LoadScene("MainMenu");
    }

    private void ResumeButtonClicked()
    {
        resumeGame();
    }

    private void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        paused = true;
        AudioListener.pause = true;
        resume.Select();
    }

    private void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        paused= false;
        AudioListener.pause = false;
        
    }
    
    public void determinePause()
    {
        if(paused)
        {
            resumeGame();
        }
        else
        {
            pauseGame();
        }
    }
}
