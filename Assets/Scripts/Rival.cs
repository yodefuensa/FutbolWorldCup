using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rival : MonoBehaviour {

    // Use this for initialization
    public Balon ball;
    public bool balonGolpeado = false;
    public bool balonPies = false;
    private int vel = 9;
    private int fuerzaGolpeo = 15;
    public GameObject porteriaRival;
    public Vector2 posInicial;
    public GameObject posicionAl;
    public ManagerPersonajes eqContra;
	public float magnitud = 0;
    //zasca te han hecho falta te caes al suelo no te puedes mover durante X tiempo
    public bool falta;
    //zasca te han hecho falta te caes al suelo no te puedes mover durante X tiempo
    public bool robo;
    //cuando se pulse C bloqueamos el movimiento y le damos la direccion de la falta
    public bool tRobo;
    public bool fakeInputC;
    public bool selector;
    public bool flipY = false;
	public Selector seguidor;
    private Animator ar;

    //public bool fakeInputSpace;

    void Start () {
        fakeInputC = false;
        falta = false;
		selector = false;
	}
    // Update is called once per frame
    void Update()
    {
        if (!falta)
        {
            movimiento();
            golpearPelota();
            conducirBalon();
        }
		marcar ();
    }

    public Vector3 getPosicion()
    {
        return transform.position;
    }

    public void setPosicion(Vector3 pos)
    {
        transform.position = pos;
    }

    public IEnumerator setFaltaFalse()
    {//si te hacen falta poner bloqueo
        yield return new WaitForSeconds(2f);
        falta = false;
    }

    public IEnumerator setFakeInputCFalse()
    {//si te hacen falta poner bloqueo
        yield return new WaitForSeconds(2f);
        fakeInputC = false;
    }

    public IEnumerator setTRoboFalse()
    {//tiempo de robo, momento que haces falta y se te bloquea la direcion
        yield return new WaitForSeconds(0.7f);
        tRobo = false;
    }

    private void movimiento()
    {
        if ((selector) && (!falta) && (!tRobo)&& MngScenes.multijugador)
        {
            if (Input.GetAxisRaw("VerticalP2") > 0)
            {
                transform.position += Vector3.up * Time.deltaTime * vel;
                if (flipY)
                {
                    transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y);
                    flipY = false;
                }
            }
            if (Input.GetAxisRaw("VerticalP2") < 0)
            {
                transform.position += Vector3.down * Time.deltaTime * vel;
                if (!flipY)
                {
                    transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y);
                    flipY = true;
                }
            }

            if (Input.GetAxisRaw("HorizontalP2") > 0)
            {
                transform.position += new Vector3(1, 0) * Time.deltaTime * vel;
            }
            if (Input.GetAxisRaw("HorizontalP2") < 0)
            {
                transform.position -= new Vector3(1, 0) * Time.deltaTime * vel;
            }
            if (Input.GetButtonDown("GolpeoP2") && balonPies && !balonGolpeado && !ball.ultimoTocado)
            {
                ball.ultimoTocado = false;
                balonPies = false;
                balonGolpeado = true;
                ball.interceptado = false;
                ball.tiempo = true;
                ball.fuerzaL = fuerzaGolpeo;
                ball.direccion = new Vector2(Input.GetAxisRaw("HorizontalP2"), Input.GetAxisRaw("VerticalP2"));
                ball.golpeoV2();
                StartCoroutine(setBalonGolpeadoFalse());
                StartCoroutine(ball.setBalonTiempoFalse());

            }
			if (Input.GetButtonDown("FaltaP2")){
				hacerFalta(new Vector2(Input.GetAxisRaw("HorizontalP2"), Input.GetAxisRaw("VerticalP2")));
			}
		} 
		Vector3 dist = transform.position - posicionAl.transform.position;
		Vector3 distBalon = posicionAl.transform.position - ball.transform.position;
		if ((dist.magnitude < 17f) && (!selector)&& ball.ultimoTocado&&!balonPies) {
			//si estamos dentro de la zona de accion  y ellos tienen el balon
			if ((transform.position.y > ball.transform.position.y + 1 || transform.position.y < ball.transform.position.y - 1
				|| transform.position.x > ball.transform.position.x + 1 || transform.position.x < ball.transform.position.x - 1) && distBalon.magnitude<16f) {
				//vamos a por el balon
				Vector3 distanciaBalon = ball.transform.position - transform.position;
				transform.position += distanciaBalon.normalized * Time.deltaTime * vel;
				if (distanciaBalon.magnitude < 4f) {
					hacerFalta (distanciaBalon.normalized);
				}

			}
			if ((dist.magnitude < 17f) && (!selector) && (!ball.ultimoTocado) && !balonPies) {//zona de accion y yo tengo el balon
				if (transform.position.y > ball.transform.position.y) {
					transform.position += Vector3.down * Time.deltaTime * vel;
				}
				if (transform.position.y < ball.transform.position.y)
					transform.position += Vector3.up * Time.deltaTime * vel;
			}
				
		}

		if (!ball.ultimoTocado && balonPies && !MngScenes.multijugador) {
			Vector3 distancia = porteriaRival.transform.position - transform.position;
			transform.position += distancia.normalized * Time.deltaTime * vel;

		}

		if ((dist.magnitude > 17f) && (!selector)&& !balonPies) {//si estamos fuera de la zona y no somos el selector
			if (transform.position.y < posicionAl.transform.position.y)
				transform.position += Vector3.up * Time.deltaTime * vel;
			if (transform.position.y > posicionAl.transform.position.y)
				transform.position += Vector3.down * Time.deltaTime * vel;
			if (transform.position.x < posicionAl.transform.position.x)
				transform.position += Vector3.right * Time.deltaTime * vel;
			if (transform.position.x > posicionAl.transform.position.x)
				transform.position += Vector3.left * Time.deltaTime * vel;
		}



    }


    public void hacerFalta(Vector3 dirFalta)
    {//vector normalizado 
		tRobo = true;
		if (tRobo) {
			StartCoroutine (setTRoboFalse ());
			Vector3 distancia = new Vector3 (3, 3);
			GameObject jugadorConPelota = GameObject.FindGameObjectWithTag ("balonPies");
			distancia = jugadorConPelota.transform.position - transform.position;
			transform.position += dirFalta * Time.deltaTime * vel/5;
			if (distancia.magnitude < 2f){
				eqContra.jugadores [eqContra.jugadorCercano ()].balonPies = false;
				eqContra.jugadores [eqContra.jugadorCercano ()].falta = true;
				StartCoroutine (eqContra.jugadores [eqContra.jugadorCercano ()].setFaltaFalse ());
				ball.interceptado = false;
			}
		}     
    
    }


    public void conducirBalon()
    {
        if (balonPies && !balonGolpeado)
        {
            Vector3 posbal = new Vector3(transform.position.x, transform.position.y + 0.5f);
            ball.setPosicion(posbal);
        }
    }


	public IEnumerator setBalonGolpeadoFalse()
	{//para no tocar el balon al golpearlo
		yield return new WaitForSeconds(.5f);
		balonGolpeado = false;
		balonPies = false;
	}

	public void golpearPelota(){
		if (balonPies) {
			Vector3 distanciaPorteria = new Vector3();
			distanciaPorteria = porteriaRival.transform.position - transform.position;
			if (distanciaPorteria.magnitude < 17) {
				Debug.Log ("igual te has pasado con la distancia de golpeo");
				ball.ultimoTocado = false;
				balonPies = false;
				balonGolpeado = true;
				ball.interceptado = false;
				ball.tiempo = true;
				ball.fuerzaL = fuerzaGolpeo;
				ball.direccion = distanciaPorteria.normalized;
				StartCoroutine (setBalonGolpeadoFalse ());
				StartCoroutine (ball.setBalonTiempoFalse ());
			}

		}
	}
	private void marcar() {
		if ((selector)&&(MngScenes.multijugador)){
			Vector3 posicionNuestra = new Vector3(transform.position.x, transform.position.y);
			seguidor.setPosicion(posicionNuestra);
		}
	}


    public void FixedUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
        if (!falta)
        {
            foreach (Collider2D hit in hits)
            {
                if ((hit.name == "balon")&&(!ball.interceptado))
                {
                    balonPies = true;
					selector = true;
                    if (!balonGolpeado)
                    {
                        ball.interceptado = true;
                    }

                }
                if (balonPies)
                    ball.ultimoTocado = false;
				//if (hit.tag == "balonPies")
				//	robo = true;

            }
            
        }

        if (!balonPies)
            this.tag = "Rival";
        else
            this.tag = "balonPies";
    }



}
