/*
 * Antonio Massa
 * Updated 4/25/2023
 */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    #region Serialized Fields
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField] 
    private GameObject controlsMenu;
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
    [SerializeField] 
    private float delay = 0.75f;
    [SerializeField] 
    private AudioSource sound;
    [SerializeField] 
    private AudioClip clip;
    #endregion

    #region public variables
    public static bool paused = false;
    #endregion

    #region unity functions
    private void Start()
    {
        Cursor.visible = true;

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
    #endregion

    #region button functions
    private void backButtonClicked()
    {
        playClip();
        StartCoroutine(backButtonCoroutine());
    }

    private void quitButtonClicked()
    {
        Application.Quit();
    }

    private void controlsButtonClicked()
    {
        playClip();
        StartCoroutine(controlsButtonCoroutine());
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
    #endregion

    #region pause functions
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
    #endregion

    #region other functions
    public void playClip()
    {
        if (sound != null && clip != null)
        {
            sound.PlayOneShot(clip);
        }
    }
    #endregion

    #region coroutines
    IEnumerator backButtonCoroutine()
    {
        yield return new WaitForSeconds(delay);
        controlsMenu.SetActive(false);
        pauseMenu.SetActive(true);
        controls.Select();
    }

    IEnumerator controlsButtonCoroutine()
    {
        yield return new WaitForSeconds(delay);
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
        back.Select();
    }
    #endregion
}
