using System.Collections;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int followOrder;
    public PlayerMovement movement;
    public TextMeshPro roll;
    public float rollMargin;
    public float playerSpeed;
    public int diceRoll;
    System.Random rand = new System.Random();
    public Node currentNode;
    public Node nextNode;

    void Start()
    {
        Invoke("GetStartPos", 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(RollDice());
        if (diceRoll > 0)
            movement.MovePlayer(this, transform);
    }
    /// <summary>
    /// Simulates a dice roll by rolling random numbers for a given amount of time. Then returning a final number
    /// </summary>
    /// <returns></returns>
    IEnumerator RollDice()
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
        diceRoll = rand.Next(1, 7);
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

    /// <summary>
    /// Handles the turn and turn order in the game
    /// </summary>
    void Turn()
    {
    }
}
