using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_Manager : MonoBehaviour {

    public GameObject
        Player1,
        Plyaer2,
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

    // Use this for initialization
    void Start () {
        //camera = GetComponent<Camera>();

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

    void TurnSwitcher(bool player1, bool player2)
    {
        Player1.active = player1;
        Player1_hand.active = player1;
        Plyaer2.active = player2;
        Player2_hand.active = player2;
    }

    public void OnEndTurn(int x)
    {
        switch (x)
        {
            case 1:
                TurnSwitcher(false,true);
                if (Player1_hand.transform.childCount < 5 && deck1.Count > 0)
                {
                    Draw(x);
                }
                break;

            case 2:
                TurnSwitcher(true, false);
                if (Player2_hand.transform.childCount < 5 && deck1.Count > 0)
                {
                    Draw(x);
                }
                break;

        }
    }

}
