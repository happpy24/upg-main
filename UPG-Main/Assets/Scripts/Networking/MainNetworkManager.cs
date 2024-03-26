using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;
using System.IO;
using Unity.VisualScripting;
using UnityEngine.ProBuilder.Shapes;

public class MainNetworkManager : NetworkManager
{
    public string firstSceneToLoad;
    
    private string[] scenesToLoad;

    private readonly List<Scene> subScenes = new List<Scene>();

    int i;

    public override void Start()
    {
        base.Start();
        int sceneCount = SceneManager.sceneCountInBuildSettings - 2;
        scenesToLoad = new string[sceneCount];

        for (int i = 0; i < sceneCount; i++)
        {
            scenesToLoad[i] = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i + 2));
        }
    }
    public override void OnServerReady(NetworkConnectionToClient conn)
    {
        base.OnServerReady(conn);

        GameObject player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player);
    }

    public override void OnServerSceneChanged(string sceneName)
    {
        base.OnServerSceneChanged(sceneName);

        SceneManager.LoadSceneAsync("LobbyScene", LoadSceneMode.Additive);
    }

    public override void OnClientSceneChanged()
    {
        base.OnClientSceneChanged();

        SceneManager.LoadSceneAsync("Design_Scene", LoadSceneMode.Additive);
    }
}
