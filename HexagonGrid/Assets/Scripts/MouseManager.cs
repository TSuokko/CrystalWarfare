using UnityEngine;
using System.Collections;

public class MouseManager : MonoBehaviour {

	GridMove moveScript;
    Crystal crystal;
    Solider solider;

	// Use this for initialization
	void Start () {
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

			if (hitGameObj.tag == "Movable") 
			{
                MouseOverPawn(hitGameObj);
			} 
			else if (hitGameObj.gameObject.name == "Hexa") 
			{
				MouseOverTile (hitGameObj);
			}
            else if (hitGameObj.gameObject.tag == "Crystal")
            {
                MouseOverCrystal(hitGameObj);
            }
        }
	
	}

	void MouseOverTile(GameObject foundObj)
	{
		if (Input.GetMouseButtonDown (0) == true) {
			if (moveScript != null) {
                if (solider.movet > 0)
                {
                    moveScript.dest = (Vector2)foundObj.GetComponentInParent<Transform>().position;
                    Debug.Log("Move DeathStar");
                    solider.movet -= 1;
                }
            }
		}
	}

	void MouseOverPawn(GameObject foundObj)
	{
		if (Input.GetMouseButtonDown(0)) {
            if (foundObj.name == "Solider(Clone)" || foundObj.name == "Solider2(Clone)")
            {
                solider = foundObj.GetComponent<Solider>();

                //Debug.Log(GameObject.FindObjectOfType<TurnSim>().playerTurn);

                if (GameObject.FindObjectOfType<TurnSim>().playerTurn == solider.ownerSolider)
                {
                    moveScript = foundObj.GetComponent<GridMove>();
                }
            }

		}
	}

    void MouseOverCrystal(GameObject foundObj)
    {
        if(Input.GetMouseButtonDown(0))
        {
            crystal = foundObj.GetComponent<Crystal>();
            if (crystal.transform.position.y < 5)
            {
                crystal.SpawSolider(new Vector3(crystal.transform.position.x, crystal.transform.position.y + 1, -1));
            }
            else if(crystal.transform.position.y > 5)
            {
                crystal.SpawSolider(new Vector3(crystal.transform.position.x, crystal.transform.position.y - 1, -1));
            }
        }
    }
}
