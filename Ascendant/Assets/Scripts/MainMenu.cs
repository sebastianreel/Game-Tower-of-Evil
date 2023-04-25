/*
 * Antonio Massa
 * Updated 4/14/2023
 */
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region Serialized Field Variables
    [SerializeField] private Button startButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button controlsButton;
    [SerializeField] private Button creditsButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button optionsBackButton;
    [SerializeField] private Button creditsBackBackButton;
    [SerializeField] private Button controlsBackButton;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject creditsMenu;

    [SerializeField] private float delay = 0.75f;
    [SerializeField] private AudioSource sound;
    [SerializeField] private AudioClip clip;
    #endregion

    #region Unity Functions
    private void Start()
    {
        startButton.onClick.AddListener(startButtonClicked);
        optionsButton.onClick.AddListener(optionsButtonClicked);
        controlsButton.onClick.AddListener(controlsButtonClicked);
        creditsButton.onClick.AddListener(creditsButtonClicked);
        optionsBackButton.onClick.AddListener(optionsBackButtonClicked);
        controlsBackButton.onClick.AddListener(controlsBackButtonClicked);
        creditsBackBackButton.onClick.AddListener(creditsBackButtonClicked);
        quitButton.onClick.AddListener(quitGame);
    }
 
    private void OnDisable()
    {
        startButton.onClick.RemoveListener(startButtonClicked);
        optionsButton.onClick.RemoveListener(optionsButtonClicked);
        controlsButton.onClick.RemoveListener(controlsButtonClicked);
        creditsButton.onClick.RemoveListener(creditsButtonClicked);
        optionsBackButton.onClick.RemoveListener(optionsBackButtonClicked);
        controlsBackButton.onClick.RemoveListener(controlsBackButtonClicked);
        creditsBackBackButton.onClick.RemoveListener(creditsBackButtonClicked);
        quitButton?.onClick.RemoveListener(quitGame);

    }
    #endregion

    #region Other Functions

    public void quitGame()
    {
        Application.Quit();
    }

    public void playClip()
    {
        if (sound != null && clip != null)
        {
            sound.PlayOneShot(clip);
        }
    }
    #endregion

    #region Button Functions
    private void startButtonClicked()
    {
        playClip();
        if(startButton!= null)
        {
            StartCoroutine(DelayedLoadScene());
        }
    }
    private void optionsButtonClicked()
    {
        playClip();
        StartCoroutine(optionsButtonDelay());
    }

    private void controlsButtonClicked()
    {
        playClip();
        StartCoroutine(contolsButtonDelay());
    }

    private void creditsButtonClicked()
    {
        playClip();
        StartCoroutine(creditsButtonDelay());
    }

    private void optionsBackButtonClicked()
    {
        playClip();
        StartCoroutine(optionsBackButtonDelay());
    }

    private void controlsBackButtonClicked()
    {
        playClip();
        StartCoroutine(controlsBackButtonDelay());
    }

    private void creditsBackButtonClicked()
    {
        playClip();
        StartCoroutine(creditsBackButtonDelay());
    }
    #endregion

    #region Coroutine Functions
        IEnumerator DelayedLoadScene()
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }

    IEnumerator optionsButtonDelay()
    {
        yield return new WaitForSeconds(delay);
        optionsMenu.SetActive(true);
        mainMenu.SetActive(false);
        optionsBackButton.Select();
    }

    IEnumerator contolsButtonDelay()
    {
        yield return new WaitForSeconds(delay);
        controlsMenu.SetActive(true);
        mainMenu.SetActive(false);
        controlsBackButton.Select();
    }

    IEnumerator creditsButtonDelay()
    {
        yield return new WaitForSeconds(delay);
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
        creditsBackBackButton.Select();
    }

    IEnumerator optionsBackButtonDelay()
    {
        yield return new WaitForSeconds(delay);
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
        optionsButton.Select();
    }

    IEnumerator controlsBackButtonDelay()
    {
        yield return new WaitForSeconds(delay);
        mainMenu.SetActive(true);
        controlsMenu.SetActive(false);
        controlsButton.Select();
    }

    IEnumerator creditsBackButtonDelay()
    {
        yield return new WaitForSeconds(delay);
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
        creditsButton.Select();
    }
    #endregion
}
