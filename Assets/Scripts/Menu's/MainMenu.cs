using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioMixer))]

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private AudioSource buttonSound;

    #region MainMenu
    public void Countinue()
    {

        SaveController.instance.IsNewGame = SaveController.IsEnd;
        SceneManager.LoadScene("Game1");
        // Если есть сохраненная игра - кнопка активна, продолжает игру (interactable set active)
    }
    public void NewGame()
    {
        SaveController.instance.IsNewGame = true;
        SceneManager.LoadScene("Game1");
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
    #endregion
    #region Settings
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
    #region Multiplayer
    #endregion

}
