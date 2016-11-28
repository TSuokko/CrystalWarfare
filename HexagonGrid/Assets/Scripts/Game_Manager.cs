using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game_Manager : MonoBehaviour {

    public GameObject 
        PlayerHand1,
        PlayerHand2;

    public GameObject 
        card1,
        card2,
        card3,
        card4;

    public List<GameObject> 
        DeckList1,
        DeckList2,
        HandList1,
        HandList2;

    GameObject Card_go;

    // Use this for initialization
    void Start () {
        DeckList1 = new List<GameObject>();
        DeckList2 = new List<GameObject>();
        HandList1 = new List<GameObject>();
        HandList2 = new List<GameObject>();


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

        PlayerHand2.active = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnCardClick()
    {

    }

    public void Discard()
    {
        Destroy(Card_go);
    }

    public void Draw(int x)
    {
        switch (x)
        {
            case 1:
                if (DeckList1.Count > 0)
                {
                    int rand1 = Random.Range(0, DeckList1.Count);
                    Card_go = (GameObject)Instantiate(DeckList1[rand1]);

                    if (HandList1.Count < 5)
                    {
                        Card_go.transform.SetParent(PlayerHand1.transform);
                        DeckList1.RemoveAt(rand1);
                        HandList1.Add(Card_go);
                    }
                    else
                    {
                        Discard();
                    }
                }
                break;

            case 2:
                if (DeckList2.Count > 0)
                {
                    int rand2 = Random.Range(0, DeckList2.Count);
                    Card_go = (GameObject)Instantiate(DeckList1[rand2]);

                    if (HandList1.Count < 5)
                    {
                        Card_go.transform.SetParent(PlayerHand2.transform);
                        DeckList2.RemoveAt(rand2);
                        HandList2.Add(Card_go);
                    }
                    else
                    {
                        Discard();
                    }
                }
                break;

        }
    }

    void TurnSwitcher(bool player1, bool player2)
    {
        PlayerHand1.active = player1;
        PlayerHand2.active = player2;

        if (player1)
        {
            Draw(1);
        }
        
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
