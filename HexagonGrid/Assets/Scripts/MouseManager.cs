using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour {

	GridMove moveScript;
    Crystal crystal;
    Solider solider;
    Factory factory;
    TurnSim turnMan;

    public GameObject clicked;

    Solider firstHitter, secondHitter;

    Text popupText;

	// Use this for initialization
	void Start () {
        turnMan = TurnSim.FindObjectOfType<TurnSim>();
        //prevGO = GameObject.Find("TurnManager");
        popupText = GameObject.Find("PopUpText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {

		//Raycast from camera to mouse
		Ray rayCM = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hitObj;

		if(Physics.Raycast(rayCM, out hitObj) == true) 
		{
			Debug.Log (hitObj.transform.name);	

			GameObject hitGameObj = hitObj.transform.gameObject;

            if (hitGameObj.name == "Card"/*hitGameObj.name == "card_soldier(Clone)" || hitGameObj.name == "card_tank(Clone)" || hitGameObj.name == "card_robot(Clone)" || hitGameObj.name == "card_robotank(Clone)"*/)
            {
                MouseOverCard(hitGameObj);
            }
            else if (hitGameObj.name == "Solider(Clone)" || hitGameObj.name == "Solider2(Clone)") 
			{
                MouseOverSolider(hitGameObj);
			}
            else if (hitGameObj.gameObject.name == "hexagon_texture") 
			{
				MouseOverTile (hitGameObj);
			}
            else if (hitGameObj.gameObject.tag == "Factory")
            {
                MouseOverFactory(hitGameObj);
            }
            

        }
	
	}

    void MouseOverCard(GameObject foundGameObj)
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked = foundGameObj;
        }
    }

    void MouseOverFactory(GameObject foundGameObj)
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (clicked.name == "Card")
            {
                Destroy(clicked.transform.parent.gameObject);
                clicked = foundGameObj;
                if (clicked.transform.position.y < 4 && turnMan.playerTurn == 1) { foundGameObj.GetComponent<Factory>().Highlight(); }
                else if (clicked.transform.position.y > 4 && turnMan.playerTurn == 2) { foundGameObj.GetComponent<Factory>().Highlight(); }

            }
            else if(clicked.tag == "Solider")
            {
                if(foundGameObj.GetComponent<Factory>().ownerPlayer != clicked.GetComponent<Solider>().ownerPlayer)
                {
                    foundGameObj.GetComponent<Factory>().healt -= clicked.GetComponent<Solider>().attack;
                    clicked.GetComponent<Solider>().attackInTurn -= 1;
                    clicked = null;
                }
            }
        }
    }

    void MouseOverTile(GameObject foundGameObj)
    {
        if(Input.GetMouseButtonDown(0))
        {
            //Check What Have Clicked
            if(clicked.tag == "Factory")
            {
                //Check turn
                if (clicked.transform.position.y < 4 && turnMan.playerTurn == 1)
                {
                    Vector2 lenght = (Vector2)foundGameObj.transform.position - (Vector2)clicked.transform.position;

                    //Spawn soldier only around factory
                    if (lenght.magnitude <= 1f)
                    {
                        clicked.GetComponent<Factory>().SpawnSolider(new Vector3(foundGameObj.transform.position.x, foundGameObj.transform.position.y, -2));
                        clicked.GetComponent<Factory>().Unhighlight();
                        clicked = null;
                    }
                }
                else if(clicked.transform.position.y > 4 && turnMan.playerTurn == 2)
                {
                    Vector2 lenght = (Vector2)foundGameObj.transform.position - (Vector2)clicked.transform.position;

                    //Spawn soldier only around factory
                    if (lenght.magnitude <= 1f)
                    {
                        clicked.GetComponent<Factory>().SpawnSolider(new Vector3(foundGameObj.transform.position.x, foundGameObj.transform.position.y, -2));
                        clicked.GetComponent<Factory>().Unhighlight();
                        clicked = null;
                    }
                }
            }
            else if(clicked.tag == "Solider")
            {
                //Check if it is player turn solider
                if(clicked.GetComponent<Solider>().ownerPlayer == turnMan.playerTurn)
                {
                    //Check if we move solider (only one hexagon lenght and one time)
                    Vector2 lenght = (Vector2)foundGameObj.transform.position - (Vector2)clicked.transform.position;
                    if(lenght.magnitude <= 1f && clicked.GetComponent<Solider>().moveInTurn > 0)
                    {
                        clicked.GetComponent<Solider>().Move(foundGameObj.transform.position);
                        clicked.GetComponent<Solider>().moveInTurn -= 1;
                        clicked = null;
                    }
                }
            }
        }
    }

    void MouseOverSolider(GameObject foundGameObj)
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Check what have been press previously
            if (clicked == null)
            {
                if (foundGameObj.GetComponent<Solider>().ownerPlayer == turnMan.playerTurn)
                {
                    clicked = foundGameObj;
                }
            }
            else if(clicked.tag == "Solider")
            {
                if(foundGameObj.GetComponent<Solider>().ownerPlayer != clicked.GetComponent<Solider>().ownerPlayer)
                {
                    Vector2 lenght = (Vector2)foundGameObj.transform.position - (Vector2)clicked.transform.position;

                    if (lenght.magnitude <= 1f)
                    {
                        foundGameObj.GetComponent<Solider>().healt -= clicked.GetComponent<Solider>().attack;
                        clicked.GetComponent<Solider>().attackInTurn -= 1;

                        clicked = null;
                    }
                }
            }
        }
    }

    /*
	void MouseOverTile(GameObject foundObj)
	{
		if (Input.GetMouseButtonDown (0) == true) {
			if (moveScript != null) {
                //solider = moveScript.gameObject.GetComponent<Solider>();
                if (solider.moveInTurn > 0)
                {
                    moveScript.dest = (Vector2)foundObj.GetComponentInParent<Transform>().position;
                    solider.moveInTurn -= 1;
                }
            }
            
            prevGO = foundObj;
        }
	}

	void MouseOverSolider(GameObject foundObj)
	{
		if (Input.GetMouseButtonDown(0)) {
            solider = foundObj.GetComponent<Solider>();
            moveScript = foundObj.GetComponent<GridMove>();
            if (GameObject.FindObjectOfType<TurnSim>().playerTurn == solider.ownerPlayer)
            {
                if (prevGO.name == "Solider(Clone)" || prevGO.name == "Solider2(Clone)" && foundObj.gameObject.name != prevGO.name)
                {
                    Attack(foundObj);
                }
                else
                {
                    moveScript = foundObj.GetComponent<GridMove>();
                }
            }
            prevGO = foundObj;
        }
	}

    void MouseOverFactory(GameObject foundObj)
    {
        if(Input.GetMouseButtonDown(0))
        {
           
            if (factory.transform.position.y < 4)
            {
                if (turnMan.playerTurn == 1)
                {
                    //Find Where To Spawn With Click
                    factory = foundObj.GetComponent<Factory>();
                    //factory.SpawnSolider(new Vector3(factory.transform.position.x, factory.transform.position.y + 1, -1));
                }
            }
            else if(factory.transform.position.y > 4)
            {
                if (turnMan.playerTurn == 2)
                {
                    factory = foundObj.GetComponent<Factory>();
                    //factory.SpawnSolider(new Vector3(factory.transform.position.x, factory.transform.position.y - 1, -1));
                }
            }
            prevGO = foundObj;
        }
    }

    void Attack(GameObject foundObj)
    {
        firstHitter = foundObj.GetComponent<Solider>();
        secondHitter = prevGO.gameObject.GetComponent<Solider>();

                
        if (firstHitter.transform.position.magnitude <= moveScript.maxMove)
        {
            secondHitter.healt -= firstHitter.attack;
            firstHitter.healt -= secondHitter.attack;
        }
      
    }
    */



}
