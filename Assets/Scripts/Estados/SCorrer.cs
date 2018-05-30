using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCorrer : MonoBehaviour {

	private bool selector;
	private bool equipo;
	private int vel;
	public Balon balon;

  void Start () {
        balon = GameObject.FindObjectOfType<Balon>();
    }

	public void setConfiguracion(bool selec,bool team,int speed){
		selector = selec;
		equipo = team;
		vel = speed;
	}
    private void movimiento(){
		if ((selector) && equipo){
		// Vector3 noMove = balon.
			if (!balon.balonFuera) { 
				if (Input.GetAxisRaw("Vertical") > 0)
				transform.position += Vector3.up * Time.deltaTime * vel;
				if (Input.GetAxisRaw("Vertical") < 0)
				transform.position += Vector3.down * Time.deltaTime * vel;
				if (Input.GetAxisRaw("Horizontal") > 0)
				transform.position += new Vector3(1, 0) * Time.deltaTime * vel;
				if (Input.GetAxisRaw("Horizontal") < 0)
				transform.position -= new Vector3(1, 0) * Time.deltaTime * vel;

	      	}
  		}
	}
}