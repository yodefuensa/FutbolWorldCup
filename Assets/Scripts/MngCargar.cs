using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngCargar : MonoBehaviour {

    public GameObject[] spain;
    public GameObject balon;

	// Use this for initialization
	void Start () {
		//despues de cargar la escena
	}

    private void Awake()
    {//antes de cargar la escena
        GameObject jugador1 = Instantiate(spain[0], transform.position, Quaternion.identity);
        GameObject jugador2 = Instantiate(spain[1], transform.position, Quaternion.identity);
        jugador1.GetComponent<Jugador>().balon = balon.GetComponent<Balon>();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
