using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class Shop : MonoBehaviour
{
    public GameObject shopPrefab;
    public GameObject parent;
    List<ItemManager> shopInventory = new List<ItemManager>();
    TextMeshProUGUI[] itemInfo;
    public GameManager manager;
    Image itemImage;
    List<GameObject> items = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        shopInventory.Add(new DoubleDice(manager.activePlayer));
        shopInventory.Add(new SpeedUp(manager.activePlayer));
        shopInventory.Add(new DoubleDice(manager.activePlayer));

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (parent.transform.childCount == 0)
                for (int i = 0; i < shopInventory.Count; i++)
                {
                    GameObject shopItem = Instantiate(shopPrefab, parent.transform);
                    itemInfo = shopItem.GetComponentsInChildren<TextMeshProUGUI>();
                    itemImage = shopItem.GetComponentsInChildren<Image>()[1];
                    shopInventory[i].GetInfo(itemImage);
                    itemInfo[0].text = shopInventory[i].itemName;
                    itemInfo[1].text = shopInventory[i].cost.ToString();
                }
            else
                foreach (Transform child in parent.transform)
                    Destroy(child.gameObject);
        }
    }
}
