using UnityEngine;
using System.Collections;

public class Crystal : MonoBehaviour {

    public int ownerCrys = 0;
    public int charge = 0;
    public GameObject soliderPref;

    public void ChargeCrystal()
    {
        charge += 2;
    }

    public void SpawSolider(Vector3 spawnPos)
    {
        if (charge >= soliderPref.GetComponent<Solider>().crystalCost)
        {
            GameObject sold = (GameObject)Instantiate(soliderPref, spawnPos, Quaternion.identity);
            if (spawnPos.y < 5)
            {
                sold.GetComponent<Solider>().ownerSolider = 1;
            }
            else if (spawnPos.y > 5)
            {
                sold.GetComponent<Solider>().ownerSolider = 2;
            }
            charge -= 2;
        }
    }

    public void DrawCard()
    {
        if (charge >= 4)
        {
            Debug.Log("DRAW!");
        }
    }

    public void DestroyCrystal()
    {
        Destroy(gameObject);
    }
}
