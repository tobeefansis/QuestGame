using System.Collections;
using System.Collections.Generic;

using Photon.Pun;

using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Text LogText;

    private void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.value;
        Log("playerName = " + PhotonNetwork.NickName);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Log("OnConnectedToMaster");
    }

    public void JoinToRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
    }

    public override void OnJoinedRoom()
    {
        Log("On Joined to Room");
        PhotonNetwork.LoadLevel("Game2");
    }

    void Log(string text)
    {
        Debug.Log(text);
        LogText.text += "\n";
        LogText.text += text;
    }
}
