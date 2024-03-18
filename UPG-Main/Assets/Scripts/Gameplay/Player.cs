using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

internal class Player : MonoBehaviour
{
    internal int followOrder;
    public PlayerMovement movement;
    public TextMeshPro roll;
    public float rollMargin;
    public float playerSpeed;
    internal int diceRoll;
    System.Random rand = new System.Random();
    internal Node currentNode;
    internal Node nextNode;
    internal bool usedBoost = false, usedDouble = false;
    ItemManager[] items = new ItemManager[3];

    void Start()
    {
        Invoke("GetStartPos", 1);
    }

    void Update()
    {
        if (diceRoll > 0 && !usedDouble)
            movement.MovePlayer(this, transform);
    }
    internal void AddItem(ItemManager item)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] != null) continue;
            items[i] = item;
            Debug.Log(items[i]);
            return;
        }
    }
    internal void UseItem(int loc)
    {
        if (items[loc] == null) return;
        items[loc].UseItem();
        items[loc] = null;
    }
    /// <summary>
    /// Simulates a dice roll by rolling random numbers for a given amount of time. Then returning a final number
    /// </summary>
    /// <returns></returns>
    internal IEnumerator RollDice(int run)
    {
        roll.enabled = true;
        float timer = 0;
        float rollTime = 1f;
        while (timer < rollTime)
        {
            int tempDice = rand.Next(1, 7);
            roll.text = tempDice.ToString();
            yield return new WaitForSeconds(0.05f);
            timer += 0.05f;
        }
        diceRoll += rand.Next(1, 7);
        if (usedBoost) diceRoll += 5;
        usedBoost = false;
        if(usedDouble && run < 2) StartCoroutine(RollDice(2));
        else usedDouble = false;
        roll.text = diceRoll.ToString();
    }

   

    /// <summary>
    /// Gets the starting position of the player
    /// TODO: Adjust the method to have variable starting positions
    /// </summary>
    void GetStartPos()
    {
        GraphManager manager = GameObject.FindGameObjectWithTag("Tiles").GetComponent<GraphManager>();
        currentNode = manager.board.nodes[0];
        nextNode = currentNode.edge.toNodes[0];
        transform.position = currentNode.position + Vector3.up * (currentNode.radius + transform.localScale.y / 2);
        roll.transform.position = transform.position + Vector3.up * rollMargin;
        roll.enabled = false;
        
    }
}
