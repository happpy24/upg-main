using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class InitPlayer : NetworkBehaviour
{
    public Text playerNameText;

    public void NameChanger(string str)
    {
        if (isLocalPlayer)
        {
            playerNameText.text = str;
        }
    }
}
