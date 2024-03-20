using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Runtime.CompilerServices;

public class HostNetworkManager : NetworkManager
{
    //place holder parameter to check wether someone has actually joined
    public delegate void OnPlayerJoined(int id);
    public static event OnPlayerJoined onPlayerJoined;

    int i;

    //ran when the server adds a new client.
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        LobbyManager lobbyManager = FindObjectOfType<LobbyManager>();
       
        if (lobbyManager)
        {
            if (lobbyManager.playersSprites[i].transform.childCount == 0)
            {
                Debug.Log(lobbyManager.playersSprites[i].transform.position);
                GameObject player = Instantiate(playerPrefab, lobbyManager.playersSprites[i].transform);
                player.transform.position = lobbyManager.playersSprites[i].transform.position;
                i++;
            }
        }
        //onPlayerJoined.Invoke(conn.connectionId);
    }

    //ran when a client leaves the game
    public override void OnClientDisconnect()
    {
        base.OnClientDisconnect();

    }
}
