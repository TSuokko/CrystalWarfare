using UnityEngine;
using System.Collections;

public class Solider : MonoBehaviour {

    public int ownerSolider = 0;
    public int movet = 1;
    public int crystalCost = 2;
    public int healt = 2;
    public int movementLenght = 1;
    public int attack = 1;

    void Update()
    {
        if(healt <= 0) { ZeroHealth(); }
    }

    void ZeroHealth()
    {
        Destroy(gameObject);
    }
    

}
