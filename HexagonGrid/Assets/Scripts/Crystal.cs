using UnityEngine;
using System.Collections;

public class Crystal : MonoBehaviour {

    public int ownerCrys = 0;
    public int charge = 0;
    public int healt;
    public GameObject soliderPref;
    public Spawn spawner;
    Factory factory;

    void Start()
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawn>();
    }

    public void ChargeCrystal()
    {
        charge += 2;
    }

    public void takeCharges(int value)
    {
        charge -= value;
    }
}
