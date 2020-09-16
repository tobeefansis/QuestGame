using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMultiplayer : MonoBehaviour
{
    private PhotonView photonView;
    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }
    private void Update()
    {
        if (!photonView.IsMine)
            return;
    }
}
