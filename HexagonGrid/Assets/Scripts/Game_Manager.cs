using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_Manager : MonoBehaviour {

    public GameObject PlayerHand1;
    public GameObject PlayerHand2;

    public GameObject card1;
    public GameObject card2;
    public GameObject card3;
    public GameObject card4;

    public List<GameObject> DeckList1;
    public List<GameObject> DeckList2;

    GameObject Card_go;

    public int hand1Size;
    public int hand2Size;

    // Use this for initialization
    void Start () {
        DeckList1 = new List<GameObject>();
        DeckList2 = new List<GameObject>();

        PlayerHand2.active = false;

        for (int i = 0; i < 5; i++)
        {
            DeckList1.Add(card1);
            DeckList1.Add(card2);
            DeckList2.Add(card3);
            DeckList2.Add(card4);
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

    public void OnCardClick()
    {

    }

    public void Draw(int x)
    {
        switch (x)
        {
            case 1:
                int rand1 = Random.Range(0, DeckList1.Count);
                Card_go = (GameObject)Instantiate(DeckList1[rand1], new Vector3(1,1,1), Quaternion.identity);
                Card_go.transform.SetParent(PlayerHand1.transform);
                DeckList1.RemoveAt(rand1);
                hand1Size++;
                break;
            case 2:
                int rand2 = Random.Range(0, DeckList2.Count);
                Card_go = (GameObject)Instantiate(DeckList1[rand2], new Vector3(1, 1, 1), Quaternion.identity);
                Card_go.transform.SetParent(PlayerHand2.transform);
                DeckList2.RemoveAt(rand2);
                hand1Size++;
                break;
        }
    }

    void TurnSwitcher(bool player1, bool player2)
    {
        PlayerHand1.active = player1;
        if (player1)
        {
            Draw(1);
        }
        PlayerHand2.active = player2;
        if (player2)
        {
            Draw(2);
        }
    }

    public void OnEndTurnClick(int x)
    {
        switch (x)
        {
            case 1:
                TurnSwitcher(false, true);
                break;
            case 2:
                TurnSwitcher(true, false);
                break;

        }
    }

    public void OnAreaClick()
    {

    }

}
