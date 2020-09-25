using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon;
using Photon.Pun;

public class LevelLoader : MonoBehaviour
{
    public void LoadUnderground()
    {
        SceneManager.LoadScene("Game1");
    }
    public void LoadHouse()
    {
        SceneManager.LoadScene("WorkingSceneSV1");
    }
    public void LoadUndergroundMulti()
    {
        PhotonNetwork.LoadLevel("Game2");
    }
    public void LoadHouseMulti()
    {
        PhotonNetwork.LoadLevel("WorkingSceneSV2");
    }
}
