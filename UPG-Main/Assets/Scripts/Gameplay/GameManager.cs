using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int round = 0;

    [SerializeField]
    private GameObject playerPrefab;
    public GameObject players;

    public DummyData dummyData;


    private void Start()
    {
        // TEMP ADDING PLAYERS
        for (int i = 0; i < 4; i++)
        {
            GameObject Player = Instantiate(playerPrefab);
            Player.transform.SetParent(players.transform);
        }

        dummyData.GiveNames();

        if (round == 0)
        {
            TriggerOpening();
        }
        Debug.Log("It is now Round "+round);
    }

    void Update()
    {
        
    }

    void TriggerOpening()
    {
        Debug.Log("Triggered Opening");
        round++;
    }
}
