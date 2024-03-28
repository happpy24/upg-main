using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AddPlayerName : MonoBehaviour
{
    public void SetLobbyName(string name)
    {
        GameObject playerNameObj = new GameObject("PlayerNameOBJ", typeof(TextMeshProUGUI));

        TextMeshProUGUI text = playerNameObj.GetComponent<TextMeshProUGUI>();  

        text.text = name;
        text.alignment = TextAlignmentOptions.Center;   

        playerNameObj.transform.SetParent(this.transform);
        playerNameObj.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 75.0f, this.transform.position.z);
    }
}
