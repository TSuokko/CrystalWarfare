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

	// Use this for initialization
	void Start () {
        canvasText = GameObject.Find("TextTurn").GetComponent<Text>(); ;
        //Debug.Log(canvasText);

        canvasText.text = "Turn: " + turn + " \n Player: " + playerTurn;
    }

    public void nextTurn()
    {
        if (playerTurn == 1)
        {
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

            turn += 1;
            playerTurn = 1;

            soliderArr = FindObjectsOfType<Solider>();

            for (int i = 0; i < soliderArr.Length; i++)
            {
                soliderArr[i].moveInTurn = 1;
            }

            factoryArr = FindObjectsOfType<Factory>();

            for (int i = 0; i < factoryArr.Length; i++)
            {
                
            }

            canvasText.text = "Turn: " + turn + " \n Player: " + playerTurn;
        }
    }
}
