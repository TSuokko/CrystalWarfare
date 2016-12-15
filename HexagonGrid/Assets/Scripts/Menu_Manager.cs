using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Menu_Manager : MonoBehaviour {

    public GameObject
        Menu,
        Rules;

	// Use this for initialization
	void Start () {
        Rules.SetActive(false);
    }

    public void OnStartPress(){
        Application.LoadLevel(1);
    }

    public void OnRulesPress(){
        Menu.SetActive(false);
        Rules.SetActive(true);
    }

    public void OnRulesExitPress()
    {
        Menu.SetActive(true);
        Rules.SetActive(false);
    }

    public void OnQuitPress(){
        Application.Quit();
    }
}
