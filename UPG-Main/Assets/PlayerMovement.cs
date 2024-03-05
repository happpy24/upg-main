using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    Node currentNode;
    public GameObject Arrow;
    List<GameObject> arrows = new List<GameObject>();
    public float playerSpeed = 5;
    int diceRoll = 0;
    System.Random rand = new System.Random();
    public TextMeshPro roll;
    public float rollMargin = 1;

    void Start()
    {
        Invoke("GetStartPos", 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(RollDice());
        if (diceRoll > 0)
            MovePlayer();
    }
    void GetStartPos() 
    {
        GraphManager manager = GameObject.FindGameObjectWithTag("Tiles").GetComponent<GraphManager>();
        currentNode = manager.board.nodes[0];
        transform.position = currentNode.position + Vector3.up * (currentNode.radius + transform.localScale.y / 2);
        roll.transform.position = transform.position + Vector3.up * rollMargin;
        roll.enabled = false;
 
        SpawnArrows();
    }
    void MovePlayer()
    {
        Node nextNode = currentNode.edge.toNodes[0];
        Vector3 target = nextNode.position + Vector3.up * (currentNode.radius + transform.localScale.y / 2);
        transform.position = Vector3.MoveTowards(transform.position, target, playerSpeed);
        if(transform.position == target)
        {
            currentNode = nextNode;
            diceRoll--;
            roll.enabled = diceRoll > 0;
            roll.text = diceRoll.ToString();
        }
        SpawnArrows();
    }
    void SpawnArrows()
    {
        foreach (GameObject arrow in arrows)
            Destroy(arrow);
        if (currentNode.edge.toNodes.Count > 1)
        {
            foreach (Node toNode in currentNode.edge.toNodes)
            {
                GameObject arrow = Instantiate(Arrow, Vector3.zero, transform.rotation);
                ArrowPointer pointer = arrow.GetComponent<ArrowPointer>();
                pointer.to = toNode.position;
                arrows.Add(arrow);
            }
        }
    }
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

}
