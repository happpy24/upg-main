using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.UI;
using TMPro;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;

internal class GameManager : MonoBehaviour
{
    internal int round = 0;

    [SerializeField]
    private GameObject playerPrefab;
    public GameObject playerParent;
    internal GameObject[] players = new GameObject[4];
    public Player player1;
    public DummyData dummyData;
    internal Player activePlayer;
    private bool LoopRunning = false;

    [SerializeField]
    private GameObject[] debugText;
    
    private void Start()
    {
        // TEMP ADDING PLAYERS
        for (int i = 0; i < 4; i++)
        {
            GameObject Player = Instantiate(playerPrefab);
            players[i] = Player;
            players[i].transform.SetParent(playerParent.transform);
            players[i].GetComponent<Player>().itemFrames = player1.itemFrames;

        }

        dummyData.GiveNames();

        if (round == 0)
        {
            TriggerOpening();
        }

        // Debug moment
        for (int i = 0;i < 4; i++)
        {
            debugText[i].GetComponent<TextMeshProUGUI>().text = players[i].name;
            Vector3 playerPos = players[i].transform.position;
            debugText[i + 4].GetComponent<TextMeshProUGUI>().text = Mathf.Floor(playerPos.x).ToString() + Mathf.Floor(playerPos.y).ToString() + Mathf.Floor(playerPos.z).ToString();
        }

        activePlayer = players[0].GetComponent<Player>();
        Debug.Log("It is now Round "+round);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            activePlayer.AddItem(new DoubleDice(activePlayer));
        if (Input.GetKeyDown(KeyCode.W))
            activePlayer.AddItem(new SpeedUp(activePlayer));
        if(Input.GetKeyDown(KeyCode.E))
            activePlayer.AddItem(new Artifact(activePlayer));
        if (Input.GetKeyDown(KeyCode.Alpha1))
            activePlayer.UseItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            activePlayer.UseItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            activePlayer.UseItem(2);


        if (!LoopRunning)
            StartCoroutine(RoundLoop());

        // Debug moment
        for (int i = 0; i < 4; i++)
        {
            Vector3 playerPos = players[i].transform.position;
            debugText[i + 4].GetComponent<TextMeshProUGUI>().text = Mathf.Floor(playerPos.x).ToString() + Mathf.Floor(playerPos.y).ToString() + Mathf.Floor(playerPos.z).ToString();
        }
    }

    /// <summary>
    /// Shows opening at the start of the game.
    /// </summary>
    void TriggerOpening()
    {
        Debug.Log("Triggered Opening");
        round++;
    }

    /// <summary>
    /// Loops for each instance of Player in the Gamemanager to form a complete round.
    /// </summary>
    IEnumerator RoundLoop()
    {
        // dit zou niet mogen werken - mad fps drops door deze line - idc - backlog in sprint 12 ofzo
        LoopRunning = true;
        for (int i = 0; i < players.Length; i++)
        {
            activePlayer = players[i].GetComponent<Player>();

            // Wait for space key press to roll dice
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));

            // Roll dice for the active player
            yield return StartCoroutine(activePlayer.RollDice(1, ""));
            Debug.Log("Player moving:" + activePlayer.name);
            yield return new WaitUntil(() => activePlayer.diceRoll <= 0);
        }
        SceneManager.LoadScene("Minigame1", LoadSceneMode.Additive);
        round++;
        Debug.Log("It is now Round " + round);
        LoopRunning = false;
    }
}
