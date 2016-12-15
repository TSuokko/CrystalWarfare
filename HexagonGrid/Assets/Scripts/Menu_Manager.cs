using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu_Manager : MonoBehaviour {

    public GameObject
        Menu,
        Rules;

	// Use this for initialization
	void Start () {
        Rules.active = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnStartPress(){
        
    }

    public void OnRulesPress(){
        Menu.active = false;
        Rules.active = true;
    }

    public void OnRulesExitPress()
    {
        Menu.active = true;
        Rules.active = false;
    }

    public void OnQuitPress(){

    }
}
