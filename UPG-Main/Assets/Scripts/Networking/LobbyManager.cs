using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviour
{
    [Header("Background sprite")]
    public Sprite sprite;

    [Header("Room code text")]
    [SerializeField] private TextMeshProUGUI roomCodeText;

    [Header("list of added spawn spaces")]
    internal List<GameObject> playersSprites = new List<GameObject>();

    private int codeNumber;

    private void Start()
    {

        codeNumber = Random.Range(1000, 10000);

        SpawnInPlayerBackgrounds();
    }

    void SpawnInPlayerBackgrounds()
    {
        Vector3 position = new Vector3(400, 500, 0);
        Vector3 scale = new Vector3(2.5f, 2.5f, 2.5f);

        for (int i = 0; i < 4; i++)
        {
            GameObject playerBackground = new GameObject("SpawnPoint", typeof(Image));
            if (playerBackground)
            {
                playersSprites.Add(playerBackground);

                playerBackground.GetComponent<Image>().sprite = sprite;

                playerBackground.transform.SetParent(this.transform);

                playerBackground.transform.localScale = scale;
                playerBackground.transform.position = position;

                position.x += 250.0f;
            }
        }
    }
}
