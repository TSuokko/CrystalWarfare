using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float height = 9f;
    public float width = 16f;

	// Use this for initialization
	void Start () {
        Camera.main.aspect = width / height;
        Screen.SetResolution(1920, 1080, true);
	}
}
