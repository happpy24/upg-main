using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class InitPlayer : NetworkBehaviour
{
    //event that gets called when the player client is spawned in
    public delegate void PlayerSpawned(string name);
    public static event PlayerSpawned onSpawned;

    public Text playerNameText;

    public string playerName;

    private void Start()
    {
        playerName = netId.ToString();

        onSpawned.Invoke(playerName);
    }

    public void NameChanger(string str)
    {
        if (isLocalPlayer)
        {
            playerNameText.text = str;
        }
    }
}
