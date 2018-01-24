using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MngScenes : MonoBehaviour {

    public static string pais;
    public static string alineacion;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnGUI()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
		    case "SelectAlineacion":
			    SceneManager.LoadScene("pruebas");
			break;
            default:
                SceneManager.LoadScene("menu");
                break;
        }

    }
    public void options()
    {
        SceneManager.LoadScene("options");
    }
    public void Back()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "SelectSeleccion":
                SceneManager.LoadScene("menu");
                break;
            case "SelectAlineacion":
                SceneManager.LoadScene("SelectSeleccion");
                break;
            default:
                SceneManager.LoadScene("menu");
                break;
        }
    }

public void rusia()
    {
        pais = "rusia";
    }
    public void spain()
    {
        pais = "spain";
    }
    public void argentina()
    {
        pais = "argentina";
    }
    public void brasil()
    {
        pais = "brasil";
    }
    public void china()
    {
        pais = "china";
    }
    public void japon()
    {
        pais = "japon";
    }
    public void alemania()
    {
        pais = "alemania";
    }
    public void usa()
    {
        pais = "usa";
    }
    public void aliA()
    {
        alineacion = "A";
    }
    public void aliB()
    {
        alineacion = "B";
    }

}
