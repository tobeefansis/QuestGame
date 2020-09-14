using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour, IPause
{
    public static bool isPaused = false;
    [SerializeField] GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                PauseManager.Instance.Pause();
            }
            else
            {
                PauseManager.Instance.Resume();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
    }
    public void Save()
    {
        // Функционал для сохранения игры
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
