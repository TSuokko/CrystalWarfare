using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject solider;
    public GameObject crystal;
    public GameObject factory;

    // Use this for initialization
    void Start () {
	
	}

    public void Soliders(Vector3 SpawnPos)
    {
        //Instantiate(solider, SpawnPos, Quaternion.identity);
        GameObject sold = (GameObject)Instantiate(solider, SpawnPos, Quaternion.identity);
        if (SpawnPos.y < 4)
        {
            sold.GetComponent<Solider>().ownerSolider = 1;
        }
        else if (SpawnPos.y > 4)
        {
            sold.GetComponent<Solider>().ownerSolider = 2;
        }
    }

    public void Crystals(Vector3 SpawnPos)
    {
        Instantiate(crystal, SpawnPos, Quaternion.identity);
    }

    public void Factory(Vector3 SpawnPos)
    {
        Instantiate(factory, SpawnPos, Quaternion.identity);
    }
}
