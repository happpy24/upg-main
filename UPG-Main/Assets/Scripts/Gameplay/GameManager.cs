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
    public DummyData dummyData;
    Player activePlayer;


    private void Start()
    {
        // TEMP ADDING PLAYERS
        for (int i = 0; i < 4; i++)
        {
            GameObject Player = Instantiate(playerPrefab);
            players[i] = Player;
            players[i].transform.SetParent(playerParent.transform);
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
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(activePlayer.GetComponent<Player>().RollDice(1));
    }

    void TriggerOpening()
    {
        Debug.Log("Triggered Opening");
        round++;
    }
}
