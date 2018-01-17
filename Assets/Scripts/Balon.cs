using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balon : MonoBehaviour
{ 
	Collider2D[] hits;
	Vector3 posicion = new Vector3(0, 0);
	public bool ultimoTocado; 
	//true tu equipo, false equipo rival para ultimo tocado
	public bool interceptado = false;
	public bool balonFuera;

	public int fuerzaL = 4;
	public bool tiempo = false;
	public Vector3 direccion = new Vector3(0,0);
	// Use this for initialization

	void Start(){
        interceptado = false;
    }

	void awake(){
		balonFuera = false;

	}	

	void Update(){
	}

	private void FixedUpdate(){
		golpeoV2 ();
	}

	public void setDireccion(Vector3 direccion,int fuerza)
	{
		transform.position = direccion * fuerza; 
	}

	public Collider2D[] GolpeoBalon()
	{//palfixed, ver si algo TOCA balon
		hits = Physics2D.OverlapCircleAll (transform.position, 0.8f);

		foreach (Collider2D hit in hits) {
			if (hit.name == "balon")
			{//WTF 
				Debug.Log ("toca");
			}
		}
		return hits;
	}

	public Vector3 getPosicion()
	{
		return transform.position;
	}

	public void setPosicion(Vector3 pos)
	{
		posicion = pos;
		transform.position = posicion;
	}


	public void golpeoV2 ()
    {
		if ((!interceptado) && (tiempo))
        {
			transform.position += direccion * Time.deltaTime * fuerzaL;
			interceptado = false;
	    }
		
	}


	public IEnumerator setBalonTiempoFalse()
	{//para no tocar el balon al golpearlo
		for (int n = 0; n < 50; n++)
		{            
			yield return new WaitForSeconds(.1f);
		}
		tiempo = false;

	}




}