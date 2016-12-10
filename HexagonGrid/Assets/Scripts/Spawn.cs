using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject solider1;
    public GameObject solider2;
    public GameObject crystal;
    public GameObject factory;

    GameObject soldSpawn;

    // Use this for initialization
    void Start () {
	
	}

    public void Soliders(Vector3 SpawnPos)
    {
        if (SpawnPos.y <= 4)
        {
            soldSpawn = (GameObject)Instantiate(solider1, SpawnPos, Quaternion.identity);
        }
        else if (SpawnPos.y >= 4)
        {
            soldSpawn = (GameObject)Instantiate(solider2, SpawnPos, Quaternion.identity);
        }

        if (SpawnPos.y < 4)
        {
            soldSpawn.GetComponent<Solider>().ownerPlayer = 1;
        }
        else if (SpawnPos.y > 4)
        {
            soldSpawn.GetComponent<Solider>().ownerPlayer = 2;
        }
    }

    public void Crystals(Vector3 SpawnPos)
    {
        GameObject crysGO = (GameObject)Instantiate(crystal, SpawnPos, Quaternion.identity);
        if(SpawnPos.y < 4) { crysGO.GetComponent<Crystal>().ownerPlayer = 1; }
        else if (SpawnPos.y > 4) { crysGO.GetComponent<Crystal>().ownerPlayer = 2; }
    }

    public void Factory(Vector3 SpawnPos)
    {
        GameObject facGO = (GameObject)Instantiate(factory, SpawnPos, Quaternion.identity);
        if (SpawnPos.y < 4) { facGO.GetComponent<Factory>().ownerPlayer = 1; }
        else if (SpawnPos.y > 4) { facGO.GetComponent<Factory>().ownerPlayer = 2; }
    }
}
