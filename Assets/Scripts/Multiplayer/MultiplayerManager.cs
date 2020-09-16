using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;
    private void Start()
    {
        Vector3 position = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f));
        PhotonNetwork.Instantiate(PlayerPrefab.name, position, Quaternion.identity);
    }
    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player entered room " + newPlayer.NickName);
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player left room " + otherPlayer.IsMasterClient);
    }
}
