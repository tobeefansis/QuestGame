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
        PhotonNetwork.LoadLevel("Game2");
    }
    public void LoadHouse()
    {
        PhotonNetwork.LoadLevel("WorkingSceneSV");
    }
}
