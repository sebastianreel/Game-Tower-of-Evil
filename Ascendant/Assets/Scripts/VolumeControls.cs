/*
 * Antonio Massa
 * Updated 4/16/2023
 */
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControls : MonoBehaviour
{
    #region Serialized Variables
    [SerializeField] private AudioMixerGroup masterGroup;
    [SerializeField] private AudioMixerGroup musicGroup;
    [SerializeField] private AudioMixerGroup soundGroup;
    [SerializeField] private AudioMixerGroup voiceGroup;

    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundSlider;
    [SerializeField] private Slider voiceSlider;
    #endregion

    #region Unity Functions
    private void Awake()
    {
        masterSlider.onValueChanged.AddListener(setMasterVolume);
        musicSlider.onValueChanged.AddListener(setMusicVolume);
        soundSlider.onValueChanged.AddListener(setSoundVolume);
        voiceSlider.onValueChanged.AddListener(setVoiceVolume);
    }

    private void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        soundSlider.value = PlayerPrefs.GetFloat("SoundVolume");
        voiceSlider.value = PlayerPrefs.GetFloat("VoiceVolume");
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterSlider.value);
        PlayerPrefs.SetFloat("VoiceVolume", voiceSlider.value);
        PlayerPrefs.SetFloat("SoundVolume", soundSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }
    #endregion

    #region Listener Functions
    private void setVoiceVolume(float value)
    {
        voiceGroup.audioMixer.SetFloat("VoiceVolume", Mathf.Log10(value) * 20);
    }

    private void setSoundVolume(float value)
    {
        soundGroup.audioMixer.SetFloat("SoundVolume", Mathf.Log10(value) * 20);
    }

    private void setMusicVolume(float value)
    {
        musicGroup.audioMixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
    }

    private void setMasterVolume(float value)
    {
        masterGroup.audioMixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
    }
    #endregion
}

