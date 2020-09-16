using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public Text log;
    void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(1,69);
        Log("Player name set as " + PhotonNetwork.NickName);

        PhotonNetwork.GameVersion = "1.0a";
        Log("Current game version is " + PhotonNetwork.GameVersion);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.ConnectUsingSettings();

    }
    public override void OnConnectedToMaster()
    {
        Log("Connected to master");
    }
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions {MaxPlayers = 2});
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom()
    {
        Log("Joined the room");
        PhotonNetwork.LoadLevel("WorkingSceneSV");
    }
    private void Log(string message)
    {
        Debug.Log(message);
        log.text += "\n";
        log.text += message;
    }
}
