using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCorrer : State {

    public Balon balon;
    private float lastPosition = 0;
    public GameObject posicion;
    public bool flipY = false;
    //robo es para saber si podremos robar la pelota
    public bool robo;

    [Header("Estados a los que puede ir")]
    public State stParado;
    public State stFalta;
    public State stBalonPies;
 

	void Start () {
        balon = GameObject.FindObjectOfType<Balon>();
        ar = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        movimiento();
        animatorObserver();
        stupidAI();
        marcar();
        hit();
	}

    void FixedUpdate()
    {
        animatorObserver();
        if (equipo)
            this.tag = "Jugador";
        else if (!equipo)
            this.tag = "Rival";
    }

    private void hit()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (Collider2D hit in hits)
        {
            if ((hit.name == "balon") && (!balon.interceptado)/*balon cuenta atras && (!balonGolpeado)*/)
            {
                selector = true;
                balon.interceptado = true;
                StopCoroutine("balon.setBalonTiempoFalse");
                st.ChangeState(stBalonPies);
            }

        }
        
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
                    st.ChangeState(stFalta);                    
                }
			}
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
                if (Input.GetButtonDown("FaltaP2")){
                    st.ChangeState(stFalta);
                }
            }
        }

    }


    private void stupidAI(){
        bool team = false;
		//team variable a la que asignamos true o false para saber quien tiene la pelota si nuestro equipo o el rival
        if (GameObject.FindGameObjectWithTag("balonPies") != null)
            team = GameObject.FindGameObjectWithTag("balonPies").GetComponent<JugadorV2>().equipo;

        Vector3 dist = transform.position - posicion.transform.position;
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
                        st.ChangeState(stFalta);
                    }
                }                  
            }
            if ((dist.magnitude < 17f) && (!selector) && team == equipo)
            {//zona de accion y yo tengo el balon
                if (!PorteroV2.esPortero)
                {
                    if (transform.position.y > balon.transform.position.y)
                        transform.position += Vector3.down * Time.deltaTime * vel;

                    if (transform.position.y < balon.transform.position.y)
                        transform.position += Vector3.up * Time.deltaTime * vel;
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
