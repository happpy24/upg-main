using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
        activePlayer = players[0].GetComponent<Player>();
        Debug.Log("It is now Round "+round);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && activePlayer.diceRoll < 1)
            StartCoroutine(activePlayer.GetComponent<Player>().RollDice(1, ""));
        if (Input.GetKeyDown(KeyCode.Q))
            activePlayer.AddItem(new DoubleDice(activePlayer));
        if (Input.GetKeyDown(KeyCode.W))
            activePlayer.AddItem(new SpeedUp(activePlayer));
        if (Input.GetKeyDown(KeyCode.Alpha1))
            activePlayer.UseItem(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            activePlayer.UseItem(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            activePlayer.UseItem(2);


    }

    void TriggerOpening()
    {
        Debug.Log("Triggered Opening");
        round++;
    }
}
