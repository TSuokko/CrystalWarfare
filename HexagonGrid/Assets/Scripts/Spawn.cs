using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject soldier;
    public GameObject tank;
    public GameObject robot;
    public GameObject robotank;
    public GameObject crystal;
    public GameObject factory;

    GameObject spawnedPawn;

    // Use this for initialization
    void Start () {
	
	}

    public void Soliders(Vector3 SpawnPos)
    {
        if (SpawnPos.y <= 4)
        {
            spawnedPawn = (GameObject)Instantiate(soldier, SpawnPos, Quaternion.identity);
        }
        else if (SpawnPos.y >= 4)
        {
            spawnedPawn = (GameObject)Instantiate(robot, SpawnPos, Quaternion.identity);
        }

        if (SpawnPos.y < 4)
        {
            spawnedPawn.GetComponent<Solider>().ownerPlayer = 1;
        }
        else if (SpawnPos.y > 4)
        {
            spawnedPawn.GetComponent<Solider>().ownerPlayer = 2;
        }
    }
    public void Tanks(Vector3 SpawnPos)
    {
        if (SpawnPos.y <= 4)
        {
            spawnedPawn = (GameObject)Instantiate(tank, SpawnPos, Quaternion.identity);
        }
        else if (SpawnPos.y >= 4)
        {
            spawnedPawn = (GameObject)Instantiate(robotank, SpawnPos, Quaternion.identity);
        }

        if (SpawnPos.y < 4)
        {
            spawnedPawn.GetComponent<Tank>().ownerPlayer = 1;
        }
        else if (SpawnPos.y > 4)
        {
            spawnedPawn.GetComponent<Tank>().ownerPlayer = 2;
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
