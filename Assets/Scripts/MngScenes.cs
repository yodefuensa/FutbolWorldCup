using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MngScenes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    


	public void Escenas()
	{

        switch (SceneManager.GetActiveScene().name)
        {
            case "menu":
                SceneManager.LoadScene("SelectSeleccion");
                break;
            case "SelectSeleccion":
                SceneManager.LoadScene("SelectAlineacion");
                break;
            default:
                SceneManager.LoadScene("menu");
                break;
        }



    }
}
