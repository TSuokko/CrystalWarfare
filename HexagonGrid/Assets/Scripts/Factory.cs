using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour {

    public int charges = 0;
    public int healt = 2;
    public int ownerPlayer = 0;
    Solider solider;
    Spawn spawner;
    Crystal[] nCrystal;
    Crystal crystal;

    public Material normalMaterial;
    public Material highlightMaterial;

    void Update()
    {
        if (healt <= 0) { ZeroHealth(); }
    }

    void ZeroHealth()
    {
        Destroy(gameObject);
    }

    public void SpawnSolider(Vector3 spawnPos)
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawn>();

        nCrystal = FindObjectsOfType<Crystal>();

        //Check charges
        for (int i = 0; i < nCrystal.Length; i++)
        {
            Vector2 lenght = (Vector2)gameObject.transform.position - (Vector2)nCrystal[i].transform.position;

            if (lenght.magnitude < 1f)
            {
                if (nCrystal[i].charge >= 2)
                {
                    spawner.Soliders(spawnPos);
                    nCrystal[i].takeCharges(2);
                }
            }
        }
    }
    public void SpawnTank(Vector3 spawnPos)
    {
        spawner = GameObject.Find("Spawner").GetComponent<Spawn>();

        nCrystal = FindObjectsOfType<Crystal>();

        //Check charges
        for (int i = 0; i < nCrystal.Length; i++)
        {
            Vector2 lenght = (Vector2)gameObject.transform.position - (Vector2)nCrystal[i].transform.position;

            if (lenght.magnitude < 1f)
            {
                if (nCrystal[i].charge >= 2)
                {
                    spawner.Tanks(spawnPos);
                    nCrystal[i].takeCharges(6);
                }
            }
        }
    }

    public int CheckCrystalCarges(int chargecheck)
    {
        int ret = 0;
        charges = 0;

        nCrystal = FindObjectsOfType<Crystal>();

        //Check charges
        for (int i = 0; i < nCrystal.Length; i++)
        {
            Vector2 lenght = (Vector2)gameObject.transform.position - (Vector2)nCrystal[i].transform.position;

            if (lenght.magnitude < 1f)
            {
                charges += nCrystal[i].charge;
            }
        }

        if(charges >= chargecheck)
        {
            ret = 1;
        }

        return ret;
    }

    public void Highlight()
    {
        gameObject.GetComponent<MeshRenderer>().material = highlightMaterial;
    }

    public void Unhighlight()
    {
        gameObject.GetComponent<MeshRenderer>().material = normalMaterial;
    }

    public void DrawCard()
    {
        if (charges >= 4)
        {
            Debug.Log("DRAW!");
        }
    }

    public void DestroyFactory()
    {
        Destroy(gameObject);
    }
}
