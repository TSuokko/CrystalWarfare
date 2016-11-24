using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    public GameObject Solider;
    public GameObject Crystal;
    public GameObject Linker;

    // Use this for initialization
    void Start () {
	
	}

    public void Soliders(Vector3 SpawnPos)
    {
        Instantiate(Solider, SpawnPos, Quaternion.identity);
    }

    public void Crystals(Vector3 SpawnPos)
    {
        Instantiate(Crystal, SpawnPos, Quaternion.identity);
    }

    public void Linkers(Vector3 SpawnPos)
    {
        Instantiate(Linker, SpawnPos, Quaternion.identity);
    }
}
