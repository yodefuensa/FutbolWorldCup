using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MngScenes : MonoBehaviour {

    public static string pais;
    public static string alineacion;
    public static string p1pais;
    public static string p1Ali;
    public static string p2pais;
    public static string p2Ali;
	public static bool multijugador;


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnGUI()
    {
       // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
    }

	public void salir(){
		Application.Quit();
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
			    SceneManager.LoadScene("pruebasV2");
			break;
            case "opciones":
                SceneManager.LoadScene("controles");
                break;
            default:
                SceneManager.LoadScene("menu");
                break;
        }

    }
    public void creditos() {
        SceneManager.LoadScene("creditos");
    }
    public void multi()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "menu":
                SceneManager.LoadScene("SelectSelecMulti1");
                break;
            case "SelectSelecMulti1":
                SceneManager.LoadScene("SelectAliMulti1");
                break;
            case "SelectAliMulti1":
                SceneManager.LoadScene("SelectSelecMulti2");
                break;
            case "SelectSelecMulti2":
                SceneManager.LoadScene("SelectAliMulti2");
                break;
            case "SelectAliMulti2":
                SceneManager.LoadScene("Multi");
                break;
        }
    }

    public void multiBack()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "SelectSelecMulti1":
                SceneManager.LoadScene("menu");
                break;
            case "SelectAliMulti1":
                SceneManager.LoadScene("SelectSelecMulti1");
                break;
            case "SelectSelecMulti2":
                SceneManager.LoadScene("SelectAliMulti1");
                break;
            case "SelectAliMulti2":
                SceneManager.LoadScene("SelectSelecMulti2");
                break;

        }
    }

    public void crontroles()
    {
        SceneManager.LoadScene("controles");
    }
    public void opciones()
    {
        SceneManager.LoadScene("opciones");
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
            case "opciones":
                SceneManager.LoadScene("menu");
                break;
            case "controles":
                SceneManager.LoadScene("opciones");
                break;
        }
    }
    public void pruebas()
    {
        SceneManager.LoadScene("pruebasV2");
    }
	public void multiON(){
		multijugador = true;
	}
	public void multiOFF(){
		multijugador = false;
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

    public void rusiaP1()
    {
        p1pais = "rusia";
    }
    public void spainP1()
    {
        p1pais = "spain";
    }
    public void argentinaP1()
    {
        p1pais = "argentina";
    }
    public void brasilP1()
    {
        p1pais = "brasil";
    }
    public void chinaP1()
    {
        p1pais = "china";
    }
    public void japonP1()
    {
        p1pais = "japon";
    }
    public void alemaniaP1()
    {
        p1pais = "alemania";
    }
    public void usaP1()
    {
        p1pais = "usa";
    }
    public void aliAP1()
    {
        p1Ali = "A";
    }
    public void aliBP1()
    {
        p1Ali = "B";
    }

    public void rusiaP2()
    {
        p2pais = "rusia";
    }
    public void spainP2()
    {
        p2pais = "spain";
    }
    public void argentinaP2()
    {
        p2pais = "argentina";
    }
    public void brasilP2()
    {
        p2pais = "brasil";
    }
    public void chinaP2()
    {
        p2pais = "china";
    }
    public void japonP2()
    {
        p2pais = "japon";
    }
    public void alemaniaP2()
    {
        p2pais = "alemania";
    }
    public void usaP2()
    {
        p2pais = "usa";
    }
    public void aliAP2()
    {
        p2Ali = "A";
    }
    public void aliBP2()
    {
        p2Ali = "B";
    }
}
