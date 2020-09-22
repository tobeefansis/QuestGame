using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    [SerializeField] private GameObject spawnPoint;
    private void Start()
    {
        Vector3 position = spawnPoint.transform.position;
        PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.identity);
    }
    public void Leave() => PhotonNetwork.LeaveRoom();
    public override void OnLeftRoom() => SceneManager.LoadScene("MainMenu");
    public override void OnPlayerEnteredRoom(Player newPlayer) => Debug.LogFormat("Player entered room " + newPlayer.NickName);
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (otherPlayer.IsMasterClient)
        {
            if (!otherPlayer.IsMasterClient)
            {
                LeaveServer();
            }
        }
    }

    private void LeaveServer()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);
    }
}

/*public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] public GameObject playerPrefab;
    [SerializeField] GameObject spawner;

    void Start()
    {
        Vector3 pos = spawner.transform.position;
        PhotonNetwork.Instantiate(playerPrefab.name, pos, Quaternion.identity);
        Debug.Log(playerPrefab.name);
    }


    public void Leave() => PhotonNetwork.LeaveRoom();
    public void OnLeftRoom() => SceneManager.LoadScene(0);
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        Debug.LogFormat("Plaer {0} entered room", newPlayer.NickName);

      
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player otherPlayer)
    {
          Debug.LogFormat("Plaer {0} left room", otherPlayer.NickName);
        if (otherPlayer.IsMasterClient)
        {
            if (!otherPlayer.IsMasterClient)
            {
                LeaveServer();
            }
        }

    }
  

    public void LeaveServer()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene(0);

    }


}*/