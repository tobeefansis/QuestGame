using UnityEngine;
using System.Collections;

public class SaveController : MonoBehaviour
{
    #region Singltone
    public static SaveController instance { get; private set; }

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(this);

        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    public bool IsNewGame { get; set; }
    public static bool IsEnd => PlayerPrefs.GetString("IsEnd", "") != "";
    public static void End() => PlayerPrefs.SetString("IsEnd", "Win");
    public void SetGameSatus(bool isNewGame)
    {
        IsNewGame = isNewGame;
    }

}