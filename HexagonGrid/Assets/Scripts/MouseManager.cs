using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {

	GridMove moveScript;
    Crystal crystal;
    Solider solider;
    Factory factory;
    TurnSim turnMan;

    GameObject prevGO;

    Solider firstHitter, secondHitter;

	// Use this for initialization
	void Start () {
        turnMan = TurnSim.FindObjectOfType<TurnSim>();
        prevGO = GameObject.Find("TurnManager");
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

            if (hitGameObj.name == "Solider(Clone)" || hitGameObj.name == "Solider2(Clone)") 
			{
                MouseOverSolider(hitGameObj);
			} 
			else if (hitGameObj.gameObject.name == "Hexa") 
			{
				MouseOverTile (hitGameObj);
			}
            else if (hitGameObj.gameObject.tag == "Factory")
            {
                MouseOverFactory(hitGameObj);
            }

        }
	
	}

	void MouseOverTile(GameObject foundObj)
	{
		if (Input.GetMouseButtonDown (0) == true) {
			if (moveScript != null) {
                solider = moveScript.gameObject.GetComponent<Solider>();
                if (solider.moveInTurn > 0)
                {
                    moveScript.dest = (Vector2)foundObj.GetComponentInParent<Transform>().position;
                    solider.moveInTurn -= 1;
                    prevGO = foundObj;
                }
            }
		}
	}

	void MouseOverSolider(GameObject foundObj)
	{
		if (Input.GetMouseButtonDown(0)) {
            solider = foundObj.GetComponent<Solider>();
            
            if (GameObject.FindObjectOfType<TurnSim>().playerTurn == solider.ownerPlayer)
            {
                if (prevGO.name == "Solider(Clone)" || prevGO.name == "Solider2(Clone)")
                {
                    Attack(foundObj);
                }
                else
                {
                    moveScript = foundObj.GetComponent<GridMove>();
                    prevGO = foundObj;
                }
            }
		}
	}

    void MouseOverFactory(GameObject foundObj)
    {
        if(Input.GetMouseButtonDown(0))
        {
            factory = foundObj.GetComponent<Factory>();
            if (factory.transform.position.y < 4)
            {
                if (turnMan.playerTurn == 1)
                {
                    factory.SpawnSolider(new Vector3(factory.transform.position.x, factory.transform.position.y + 1, -1));
                }
            }
            else if(factory.transform.position.y > 4)
            {
                if (turnMan.playerTurn == 2)
                {
                    factory.SpawnSolider(new Vector3(factory.transform.position.x, factory.transform.position.y - 1, -1));
                }
            }
        }
    }

    void Attack(GameObject foundObj)
    {
        if(Input.GetMouseButtonDown(0))
        {
                firstHitter = foundObj.GetComponent<Solider>();
                secondHitter = prevGO.gameObject.GetComponent<Solider>();

                if (firstHitter.ownerPlayer == turnMan.playerTurn)
                {
                
                    if (firstHitter.transform.position.magnitude <= moveScript.maxMove)
                    {
                        secondHitter.healt -= firstHitter.attack;
                        firstHitter.healt -= secondHitter.attack;
                    }
                }
        }
    }
}
