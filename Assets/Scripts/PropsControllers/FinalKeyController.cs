using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalKeyController : MonoBehaviour
{
    public void TakeKey()
    {
        FinalDoorController.playerHaveKey = true;
    }
}
