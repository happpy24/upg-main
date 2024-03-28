using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;
using System;

public class SceneNetworking : NetworkManager
{
    public delegate void clientDisconnect(NetworkConnectionToClient conn);
    public event clientDisconnect onDisconnect;

#if UNITY_STANDALONE
    public override void OnClientConnect()
    {
        SceneManager.LoadSceneAsync("LobbyScene", LoadSceneMode.Additive);
    }

    public override void OnServerDisconnect(NetworkConnectionToClient conn)
    {
        base.OnServerDisconnect(conn);

        onDisconnect.Invoke(conn);

    }

    public override void OnClientDisconnect()
    {
        base.OnClientDisconnect();

        SceneManager.UnloadSceneAsync("LobbyScene");
    }

#else
    public override void OnClientConnect()
    {
        SceneManager.LoadSceneAsync("DesignScene", LoadSceneMode.Additive);
    }
#endif
}
