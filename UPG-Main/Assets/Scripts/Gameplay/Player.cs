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
    public Image[] itemFrames = new Image[3];
    ItemManager[] items = new ItemManager[3];
    internal Artifact[] artifacts = new Artifact[4];
    bool diceRolling = false;
    public int ArtifactID = 0;

    void Start()
    {
        Invoke("GetStartPos", 1);
    }

    void Update()
    {
        if (diceRoll > 0 && !diceRolling)
            movement.MovePlayer(this, transform);
    }
    internal void AddItem(ItemManager item)
    {
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i] != null) continue;
            items[i] = item;
            Debug.Log("Items: " + items[i]);
            Debug.Log("Item Frames: " + itemFrames[i]);
            items[i].GetInfo(itemFrames[i]);
            return;
        }
    }
    internal void UseItem(int loc)
    {
        if (items[loc] == null) return;
        items[loc].UseItem();
        items[loc] = null;
        itemFrames[loc].sprite = null;
    }
    /// <summary>
    /// Simulates a dice roll by rolling random numbers for a given amount of time. Then returning a final number
    /// </summary>
    /// <returns></returns>
    internal IEnumerator RollDice(int run, string startString)
    {
        diceRolling = true;
        roll.enabled = true;
        float timer = 0;
        float rollTime = 1f;
        int tempDice = 0;
        while (timer < rollTime)
        {
            tempDice = rand.Next(1, 7);
            roll.text = startString + tempDice.ToString();
            yield return new WaitForSeconds(0.05f);
            timer += 0.05f;
        }
        roll.text = startString + tempDice.ToString();
        diceRoll += tempDice;
        if (usedBoost)
            diceRoll += 5;
        usedBoost = false;
        if(usedDouble && run < 2) 
            StartCoroutine(RollDice(2, diceRoll.ToString() + "   "));
        else usedDouble = false;
        roll.text = diceRoll.ToString();
        yield return new WaitForSeconds(1.5f);
        diceRolling = false;
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
