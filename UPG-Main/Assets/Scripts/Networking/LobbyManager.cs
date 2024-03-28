using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class LobbyManager : MonoBehaviour
{
    [Header("Background sprite")]
    [SerializeField]private Sprite spawnSprite;

    [Header("Player Sprite")]
    [SerializeField] private Sprite playerSprite;

    [Header("list of added spawn spaces")]
    private List<GameObject> playersSprites = new List<GameObject>();

    private int playerCount = 0;

    void Start()
    {
        SpawnSprite();
    }

    private void OnEnable()
    {
        InitPlayer.onSpawned += PlayerJoined;
        SceneNetworking.FindObjectOfType<SceneNetworking>().onDisconnect += PlayerLeft;
    }

    private void OnDisable()
    {
        InitPlayer.onSpawned -= PlayerJoined;
    }

    /// <summary>
    /// Spawns sprites into the scene which the players will spawn on.
    /// </summary>
    private void SpawnSprite()
    {
        Vector3 position = new Vector3(850, 500, 0);
        Vector3 scale = new Vector3(1.5f, 1.5f, 1.5f);

        for (int i = 0; i < 4; i++)
        {
            GameObject playerBackground = new GameObject("SpawnPoint", typeof(Image));

            if (playerBackground)
            {
                playersSprites.Add(playerBackground);

                playerBackground.GetComponent<Image>().sprite = spawnSprite;

                playerBackground.transform.SetParent(this.transform);

                playerBackground.transform.localScale = scale;
                playerBackground.transform.position = position;

                position.x += 250.0f;
            }
        }
    }

    /// <summary>
    /// Called when a client joins the game, spawns in player sprite on corrosponding platform.
    /// </summary>
    private void PlayerJoined(string name)
    {
        playerCount++;

        GameObject player = new GameObject(name, typeof(Image));

        //set image sprite
        Image playerImage = player.GetComponent<Image>();

        if (playerImage)
        {
            playerImage.sprite = playerSprite;
            playerImage.color = Color.blue;
        }

        //set the parent of the Gameobject and position
        player.transform.SetParent(playersSprites[playerCount - 1].transform);
        player.transform.position = new Vector3(playersSprites[playerCount - 1].transform.position.x, playersSprites[playerCount - 1].transform.position.y + 30.0f,0.0f);

        player.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    /// <summary>
    /// Called when a player leaves the game server side removes the corrosponding player from the lobby
    /// </summary>
    /// <param name="conn"></param>
    private void PlayerLeft(NetworkConnectionToClient conn)
    {
        GameObject playerToRemove = GameObject.Find(conn.connectionId.ToString());

        if (playerToRemove)
        {
            Destroy(playerToRemove);
        }
    }
}
