using Org.BouncyCastle.Crypto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;

public class LobbyManager : MonoBehaviour
{
    [Header("Background sprite")]
    public Sprite sprite;

    [Header("Room code text")]
    [SerializeField] private TextMeshProUGUI roomCodeText;

    [Header("list of added spawn spaces")]
    public  List<GameObject> playersSprites;

    private int codeNumber;

    private void Start()
    {

        codeNumber = Random.Range(1000, 10000);

        SetRoomCodeText();

        SpawnInPlayerBackgrounds();
    }


    void SpawnInPlayerBackgrounds()
    {
        Vector3 position = new Vector3(900, 1000, 0);
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

    //sets the room code for this game instance
    void SetRoomCodeText()
    {
        //add check to codenumber in database so you don't have a room with the same code
        roomCodeText.text = codeNumber.ToString();
    }

    //connect to the database
    IEnumerator ConnectToDatabase()
    {
        using (UnityWebRequest www = UnityWebRequest.Post("https://www.my-server.com/myapi", "{ \"field1\": 1, \"field2\": 2 }", "application/json"))
        {
            yield return www;
        }
    }
}
