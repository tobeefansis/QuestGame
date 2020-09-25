using UnityEngine;
using System.Collections;
using Photon.Pun;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System.Collections.Generic;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    public GameObject Player;
    
    public List<InteractiveObject> interactiveObjects = new List<InteractiveObject>();

    private void Start()
    {
        PhotonNetwork.Instantiate(Player.name, new Vector3(), Quaternion.identity);
    }

    public void Leave()
    {
        PhotonNetwork.LeaveRoom();
    }
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
    public override void OnPlayerEnteredRoom(Player player)
    {
        Debug.LogFormat($"Player {player.NickName} Entered room");
    }

    public override void OnPlayerLeftRoom(Player player)
    {
        Debug.LogFormat($"Player {player.NickName} left room");

    }
}
