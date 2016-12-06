using UnityEngine;
using System.Collections;

public class Factory : MonoBehaviour {

    public int charges = 0;
    public int healt = 2;
    Solider solider;
    Spawn spawner;
    Crystal[] nCrystal;
    Crystal crystal;

    public Material normalMaterial;
    public Material highlightMaterial;

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
