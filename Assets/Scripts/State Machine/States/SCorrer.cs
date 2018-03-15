using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCorrer : State {

    [Header("Estados a los que puede ir")]
    public State stParado;
    public State stFalta;
    public State stBalonPies;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
				if (Input.GetButtonDown("Falta")){
                    StateMachine.ChangeState(stFalta);                    
                }
			}
			if (Input.GetButtonDown("Golpeo")){}
		}

    }

    private void movimientoP2()
    {
        if ((selector) && !equipo && MngScenes.multijugador)
        {
            if (!balon.balonFuera)
            {
                if (Input.GetAxisRaw("VerticalP2") > 0)
                    transform.position += Vector3.up * Time.deltaTime * vel;
                if (Input.GetAxisRaw("VerticalP2") < 0)
                    transform.position += Vector3.down * Time.deltaTime * vel;
                if (Input.GetAxisRaw("HorizontalP2") > 0)
                    transform.position += new Vector3(1, 0) * Time.deltaTime * vel;
                if (Input.GetAxisRaw("HorizontalP2") < 0)
                    transform.position -= new Vector3(1, 0) * Time.deltaTime * vel;
                if (Input.GetButtonDown("FaltaP2")){}
            }
            if (Input.GetButtonDown("GolpeoP2") && balonPies && !balonGolpeado){}
        }

    }


    private void stupidAI(){
        bool team = false;
		//team variable a la que asignamos true o false para saber quien tiene la pelota si nuestro equipo o el rival
        if (GameObject.FindGameObjectWithTag("balonPies") != null)
            team = GameObject.FindGameObjectWithTag("balonPies").GetComponent<JugadorV2>().equipo;

        Vector3 dist = transform.position - posicion.transform.position;
        if (balonPies && !MngScenes.multijugador && !equipo)
        {//no es multi, tenemos el balon en los pies y somos la ia corremos a porteria
            Vector3 distancia = porteriaRival.transform.position - transform.position;
            transform.position += distancia.normalized * Time.deltaTime * vel;
        }
        if ((dist.magnitude < 17f) && (!selector))
        {//si estamos dentro de la zona de accion
            if (!balon.interceptado)
            {
                Vector3 distanciaBalon = balon.transform.position - transform.position;
                transform.position += distanciaBalon.normalized * Time.deltaTime * vel;            
            }else
            {
                if ((team != equipo)&& !PorteroV2.esPortero)
                {
                    Vector3 distanciaBalon = balon.transform.position - transform.position;
                    transform.position += distanciaBalon.normalized * Time.deltaTime * vel;
                    if ((distanciaBalon.magnitude < 4f) && balon.interceptado && !balon.balonFuera && team != equipo){
                        ar.SetBool("falta", true);
                        hacerFalta(distanciaBalon.normalized);
                    }
                }                  
            }
        }

        if ((dist.magnitude > 16f) && (!selector))
        {//si estamos fuera de la zona y no somos el selector
            transform.position -= dist.normalized * Time.deltaTime * vel;
        }
    }

    private void animatorObserver (){
		if (lastPosition < transform.position.y) {
			ar.SetBool ("corriendo", true);
			if (flipY) {
				transform.localScale = new Vector3 (transform.localScale.x, -transform.localScale.y);
				flipY = false;
			}
			lastPosition = transform.position.y;
		}
		if (lastPosition > transform.position.y){
			ar.SetBool ("corriendo", true);
			if (!flipY) {
				transform.localScale = new Vector3 (transform.localScale.x, -transform.localScale.y);
				flipY = true;
			}
			lastPosition = transform.position.y;
		}

	}





}
