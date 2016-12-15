using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Deck_Manager : MonoBehaviour {

    public GameObject
        Player1,
        Player2,
        Player1_hand, 
        Player2_hand,
        card1,
        card2,
        card3,
        card4;

    public List<GameObject> 
        deck1, 
        deck2, 
        hand1,
        hand2;

    GameObject Card_go;
    //Camera camera;

    TurnSim turnScript;

    // Use this for initialization
    void Start () {
        //camera = GetComponent<Camera>();
        turnScript = GameObject.Find("TurnManager").GetComponent<TurnSim>();

        deck1 = new List<GameObject>();
        deck2 = new List<GameObject>();
        hand1 = new List<GameObject>();
        hand2 = new List<GameObject>();

        for (int i = 0; i < 5; i++)
        {
            deck1.Add(card1);
            deck1.Add(card2);
        }
        for (int i = 0; i < 5; i++)
        {
            deck2.Add(card3);
            deck2.Add(card4);
        }

        for (int i = 0; i < 3; i++)
        {
            Draw(1);
            Draw(2);
        }

        TurnSwitcher();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    float yPos(int x)
    {
        float y = 0;
        switch (x)
        {
            case 1:
                y = 1.8f + Player1_hand.transform.childCount * 1.5f;
                break;
            case 2:
                y = 1.8f + Player2_hand.transform.childCount * 1.5f;
                break;
        }
        return y;
    }

    float xPos(int x)
    {
        float y = 0;
        switch (x)
        {
            case 1:
                y = -3.6f; 
                break;
            case 2:
                y = 9.6f;
                break;
        }
        return y;
    }

    public void Draw(int x)
    {
        switch (x)
        {
            case 1:
                int rand1 = Random.Range(0, deck1.Count);
                Card_go = (GameObject)Instantiate(deck1[rand1], new Vector3(xPos(1), yPos(1), 1), Quaternion.identity);
                Card_go.transform.SetParent(Player1_hand.transform);
                hand1.Add(Card_go);
                deck1.RemoveAt(rand1);
                break;
            case 2:
                int rand2 = Random.Range(0, deck2.Count);
                Card_go = (GameObject)Instantiate(deck2[rand2], new Vector3(xPos(2), yPos(2), 1), Quaternion.identity);
                Card_go.transform.SetParent(Player2_hand.transform);
                hand2.Add(Card_go);
                deck2.RemoveAt(rand2);
                break;
        }
    }

    void TurnSwitcher(/*bool player1, bool player2*/)
    {
        /*Player1.active = player1;
        Player1_hand.active = player1;
        Plyaer2.active = player2;
        Player2_hand.active = player2;
        Player1.SetActive(player1);
        Player1_hand.SetActive(player1);
        Player2.SetActive(player2);
        Player2_hand.SetActive(player2);*/
        if(turnScript.playerTurn == 1)
        {
            Player1.SetActive(true);
            Player1_hand.SetActive(true);
            Player2.SetActive(false);
            Player2_hand.SetActive(false);
        }
        else if(turnScript.playerTurn == 2)
        {
            Player1.SetActive(false);
            Player1_hand.SetActive(false);
            Player2.SetActive(true);
            Player2_hand.SetActive(true);
        }
    }

    public void OnEndTurn(int x)
    {
        switch (x)
        {
            case 1:
                ReShuffleHand(1);
                if (Player1_hand.transform.childCount < 5 && deck1.Count > 0)
                {
                    Draw(x);
                }
                TurnSwitcher(/*false,true*/);
                break;

            case 2:
                ReShuffleHand(2);
                if (Player2_hand.transform.childCount < 5 && deck1.Count > 0)
                {
                    Draw(x);
                }
                TurnSwitcher(/*true, false*/);
                break;

        }
    }

    //Method makes that there is not empty spaces in list
    public void ReShuffleHand(int player)
    {
        if(player == 1)
        {
            for (int i = 0; i < hand1.Count; i++)
            {
                if (hand1[i] == null)
                {
                    hand1.RemoveAt(i);
                }
            }
        }
        else if (player == 2)
        {
            for (int i = 0; i < hand2.Count; i++)
            {
                if (hand2[i] == null)
                {
                    hand2.RemoveAt(i);
                }
            }
        }
    }

}
