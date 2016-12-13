using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TurnSim : MonoBehaviour {

    Crystal crystal;

    Crystal[] crystalArr;
    Solider[] soliderArr;
    Factory[] factoryArr;

    public int turn = 1;
    public int playerTurn = 1;
    Text canvasText;
    Text canvasPopup;

    int player1Fact = 0;
    int player2Fact = 0;

    float timer = 2f;

    bool startCount = false;

	// Use this for initialization
	void Start () {
        canvasText = GameObject.Find("TextTurn").GetComponent<Text>();
        canvasPopup = GameObject.Find("PopUpText").GetComponent<Text>();
        //Debug.Log(canvasText);

        canvasText.text = "Turn: " + turn + " \n Player: " + playerTurn;
        canvasPopup.text = "Game Starts!";
        startCount = true;
    }

    void Update()
    {
        if(startCount == true)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                GameObject.Find("PopUpText").SetActive(false);
                startCount = false;
                timer = 3f;
            }
        }
    }

    public void nextTurn()
    {
        if (playerTurn == 1)
        {
            PlayerWinCheck();

            playerTurn = 2;

            canvasText.text = "Turn: " + turn + " \n Player: " + playerTurn;


        }
        else if(playerTurn == 2)
        {
            crystalArr = FindObjectsOfType<Crystal>();

            for (int i = 0; i < crystalArr.Length; i++)
            {
                crystalArr[i].ChargeCrystal();
            }

            soliderArr = FindObjectsOfType<Solider>();

            for (int i = 0; i < soliderArr.Length; i++)
            {
                soliderArr[i].moveInTurn = 1;
                soliderArr[i].attackInTurn = 1;
            }

            PlayerWinCheck();

            turn += 1;
            playerTurn = 1;

            canvasText.text = "Turn: " + turn + " \n Player: " + playerTurn;
        }
    }

    void PlayerWinCheck()
    {
        factoryArr = FindObjectsOfType<Factory>();

        for (int i = 0; i < factoryArr.Length; i++)
        {
            if (factoryArr[i].transform.position.y < 4)
            {
                player1Fact++;
            }
            if (factoryArr[i].transform.position.y > 4)
            {
                player2Fact++;
            }
        }
        if (player1Fact == 0 || player2Fact == 0)
        {
            if (player1Fact == 0)
            {
                canvasPopup.text = "Player 2 Wins!";
            }
            else if (player2Fact == 0)
            {
                canvasPopup.text = "Player 1 Wins!";
            }
        }
        Debug.Log("Player 1 Factorys: " + player1Fact);
        Debug.Log("Player 2 Factorys: " + player2Fact);
        player1Fact = 0;
        player2Fact = 0;
    }
}
