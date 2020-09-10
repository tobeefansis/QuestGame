using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioMixer))]

public class MainMenu : MonoBehaviour
{
    
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource buttonSound;
    public void Countinue()
    {
        // Если есть сохраненная игра - кнопка активна, продолжает игру (interactable set active)
    }
    public void NewGame()
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // Добавить функционал создания новой игры
    }
    public void ResetProgress()
    {
        // Добавить функционал удаления сохранения
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PlayClickSound()
    {
        buttonSound.Play();
    }
    #region VolumeSettings
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
    }
    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }
    public void SetSoundsVolume(float volume)
    {
        audioMixer.SetFloat("soundsVolume", volume);
    }
    #endregion
}
