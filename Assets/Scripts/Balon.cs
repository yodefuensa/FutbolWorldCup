using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balon : MonoBehaviour
{ 
	Vector3 posicion = new Vector3(0, 0);
	public bool ultimoTocado; 
	//true tu equipo, false equipo rival para ultimo tocado
	public bool interceptado = false;
	public bool balonFuera;

	public int fuerzaL = 15;
	public Vector3 direccion = new Vector3(0,0);
	// Use this for initialization

	void Start(){
        interceptado = false;
    }

	void awake(){
		balonFuera = false;
	}	

	private void Update(){
		golpeoV2 ();
	}

	public void setDireccion(Vector3 direccion,int fuerza){
		transform.position = direccion * fuerza; 
	}


	public void setPosicion(Vector3 pos)
	{
		posicion = pos;
		transform.position = posicion;
	}


	public void golpeoV2 (){
		if (!interceptado ){
			transform.position += direccion * Time.deltaTime * fuerzaL;
			if (fuerzaL>0)
				StartCoroutine(setBalonTiempoFalse());
      	}
    }
	public IEnumerator setBalonTiempoFalse()
  	{//parar balon     
        yield return new WaitForSeconds(1f);
        if (fuerzaL>0)
            fuerzaL--;
    }
    



}