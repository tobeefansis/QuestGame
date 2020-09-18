using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    [SerializeField] private GameObject spawnPoint;
    private void Start()
    {
        Vector3 position = spawnPoint.transform.position;
        PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.identity);
        Debug.Log(playerPrefab.name);
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
    }
    public override void OnLeftRoom() => SceneManager.LoadScene("MainMenu");

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player entered room " + newPlayer.NickName);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player left room " + otherPlayer.IsMasterClient);
        if (otherPlayer.IsMasterClient)
        {
            if (!otherPlayer.IsMasterClient)
            {
                PhotonNetwork.Disconnect();
            }
        }
    }
}
