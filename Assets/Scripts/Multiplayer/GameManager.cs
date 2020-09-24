using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject spawnPoint;
    private void Start()
    {
        Vector3 position = spawnPoint.transform.position;
        PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.identity);
    }
    public override void OnLeftRoom()
    {
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenu");
    }
    public override void OnPlayerEnteredRoom(Player newPlayer) => Debug.LogFormat("Player entered room " + newPlayer.NickName);
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            OnLeftRoom();
        }
    }

    public void LeaveServer() // Использовать на кнопку
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            OnLeftRoom();
        }
    }
}
