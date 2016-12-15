using UnityEngine;
using System.Collections;


public class HexagonMap : MonoBehaviour {

	public GameObject hexPref;

    public Spawn spawnScript;

    int mapWidth = 5;
    int mapHeight = 19;

	int hexXCount;
	int hexYCount;

    //float xOffset = 1.51f;
    //float yOffset = 0.4385f;

	float xOffset = 0.76f*2;
	float yOffset = 0.44f;

    float xPos = 0;

    //int xLoop = 0;

    // Use this for initialization
    void Start () {
		for (int y = 0; y < mapHeight; y++) {
			if (y % 2 == 1) {
				mapWidth--;
			}
            
			for (int x = 0; x < mapWidth; x++) {

                xPos = x * xOffset;

                //Spawn On OffSet Row
				if (y % 2 == 1) {
					xPos += xOffset / 2;
				}

				GameObject hex = (GameObject)Instantiate (hexPref, new Vector3 (xPos, y * yOffset, 0), Quaternion.identity);

				hex.name = "Hex " + y + "_" + x;

                Vector3 hexPosToSpawn = new Vector3(hex.transform.position.x, hex.transform.position.y, hex.transform.position.z - 1);

                //Spawn crystals
                if(hex.name == "Hex 0_2" || hex.name == "Hex 3_0" || hex.name == "Hex 3_3") { spawnScript.Crystals(hexPosToSpawn); }
                else if (hex.name == "Hex 18_2" || hex.name == "Hex 15_0" || hex.name == "Hex 15_3") { spawnScript.Crystals(hexPosToSpawn); }

                //Spawn factories
                else if(hex.name == "Hex 5_0" || hex.name == "Hex 5_3" || hex.name == "Hex 2_2") { spawnScript.Factory(hexPosToSpawn); }
                else if (hex.name == "Hex 13_0" || hex.name == "Hex 13_3" || hex.name == "Hex 16_2") { spawnScript.Factory(hexPosToSpawn); }

            }
			mapWidth = 5;
		}

        //Destroy extra haxagon
        Destroy(GameObject.Find("Hex 0_0"));
        Destroy(GameObject.Find("Hex 0_1"));
        Destroy(GameObject.Find("Hex 0_3"));
        Destroy(GameObject.Find("Hex 0_4"));

        Destroy(GameObject.Find("Hex 1_0"));
        Destroy(GameObject.Find("Hex 1_3"));
        Destroy(GameObject.Find("Hex 1_4"));

        Destroy(GameObject.Find("Hex 2_0"));
        Destroy(GameObject.Find("Hex 2_4"));

        Destroy(GameObject.Find("Hex 16_0"));
        Destroy(GameObject.Find("Hex 16_4"));

        Destroy(GameObject.Find("Hex 17_0"));
        Destroy(GameObject.Find("Hex 17_3"));
        Destroy(GameObject.Find("Hex 17_4"));

        Destroy(GameObject.Find("Hex 18_0"));
        Destroy(GameObject.Find("Hex 18_1"));
        Destroy(GameObject.Find("Hex 18_3"));
        Destroy(GameObject.Find("Hex 18_4"));

        Destroy(GameObject.Find("Hex 10_1"));
        Destroy(GameObject.Find("Hex 9_1"));
        Destroy(GameObject.Find("Hex 8_1"));

        Destroy(GameObject.Find("Hex 10_3"));
        Destroy(GameObject.Find("Hex 9_2"));
        Destroy(GameObject.Find("Hex 8_3"));
    }
}