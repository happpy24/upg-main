using Mirror;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class InitPlayer : NetworkBehaviour
{
    public Text playerNameText;

    void Start()
    {
        if (isLocalPlayer)
        {
#if !UNITY_WEBGL
            string playername = "DefaultPlayer";
            playerNameText.text = playername;
#else 
            string playerName = GetPlayerNameFromLocalStorage();

            if(!string.IsNullOrEmpty(playerName))
            {
                playerNameText.text = playerName;
            }
            else
            {
                playerNameText.text = "DefaultPlayer";
            }
#endif
        }
    }

#if UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern string GetPlayerNameFromLocalStorage();
#endif
}
