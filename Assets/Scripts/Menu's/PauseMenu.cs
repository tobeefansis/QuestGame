using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public static PauseMenu Instate;


    [SerializeField] private GameObject pauseMenuUI;

    #region Singleton
    private void Awake()
    {
        if (!Instate)
        {
            Instate = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion


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
