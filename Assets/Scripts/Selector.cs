using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour {

	public Vector3 posicion = new Vector3(0, 0);

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void setPosicion(Vector3 pos)
	{
		posicion = pos;
		transform.position = posicion;
	}


}
