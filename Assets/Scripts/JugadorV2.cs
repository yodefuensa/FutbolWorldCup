using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class JugadorV2 : MonoBehaviour {

	public Balon balon;
	public bool balonGolpeado = false;
	public bool balonPies = false;
	public bool selector = false;
	private int vel = 12;
	private int fuerzaGolpeo = 15;
    //robo es para saber si podremos robar la pelota
    public bool robo;
    //cuando se pulse C bloqueamos el movimiento y le damos la direccion de la falta
    public bool tRobo;
    //zasca te han hecho falta te caes al suelo no te puedes mover durante X tiempo
    public bool falta;
    //magnitud se usa en el manager partido, para saber que jugadores estaran mas cerca al salir la pelota
    public Vector3 dirFalta;
	public float magnitud = 0;
    public Vector3 posicionInicial;
	public GameObject posicion;
	private Animator ar;
	public bool flipY = false;
	public Selector seguidor;
   // public GameObject equipoRivalGO;
    public MngEquiV2 equipoRival;
	private float lastPosition = 0;
    public bool equipo;
    public GameObject porteriaRival;

    private void Awake(){
		posicionInicial = new Vector2 (transform.position.x, transform.position.y);
		falta = false;
    }

    void Start () {
        falta = false;
        tRobo = false;
        ar = GetComponent<Animator>();
	}

	void Update () {
        if (!falta)
        {
            movimiento();
            movimientoP2();
            stupidAI();
            conducirBalon();
        }
        marcar();
        hit();

	}
    void FixedUpdate(){
        if (!selector)
            animatorObserver();
        if ((!balonPies) && (equipo))
            this.tag = "Jugador";
        else if ((!balonPies) && (!equipo))
            this.tag = "Rival";
        else
        {
            this.tag = "balonPies";
            selector = true;
            if (equipo)
                balon.ultimoTocado = true;
            else
                balon.ultimoTocado = false;
        }
    }

    public IEnumerator setBalonGolpeadoFalse()
    {//para no tocar el balon al golpearlo
        yield return new WaitForSeconds(.5f);
        balonGolpeado = false;
        balonPies = false;
    }
    public IEnumerator setFaltaFalse()
    {//si te hacen falta poner bloqueo
        yield return new WaitForSeconds(2f);
        falta = false;
    }

    public IEnumerator setTRoboFalse()
    {//tiempo de robo, momento que haces falta y se te bloquea la direcion
        yield return new WaitForSeconds(0.7f);
        tRobo = false;
		ar.SetBool ("falta", false);
    }

    private void hit(){
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
        robo = false;
        if (!falta)
        {
            foreach (Collider2D hit in hits)
            {
                if ((hit.name == "balon") && (!balon.interceptado) && (!balonGolpeado))
                {
                    balonPies = true;
                    selector = true;
                    balon.interceptado = true;
                    StopCoroutine("balon.setBalonTiempoFalse");

                }
                if (hit.tag == "balonPies")
                {
                    robo = true;
                }
            }
        }
    }

    private void movimiento(){
        if ((selector) && (!falta) && (!tRobo)&& equipo)
        {
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
                if (Input.GetButtonDown("Falta"))
                {
                    Vector3 distanciaBalon = balon.transform.position - transform.position;
                    hacerFalta(distanciaBalon.normalized);
                }
            }
            if (Input.GetButtonDown("Golpeo") && balonPies && !balonGolpeado)
            {
                if (equipo)
                    balon.ultimoTocado = true;
                if (!equipo)
                    balon.ultimoTocado = false;
                balonPies = false;
                balonGolpeado = true;
                balon.interceptado = false;
                balon.tiempo = true;
                balon.fuerzaL = fuerzaGolpeo;
                balon.direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                balon.golpeoV2();
                StartCoroutine(setBalonGolpeadoFalse());
                StartCoroutine(balon.setBalonTiempoFalse());
            }
        }

    }
    private void movimientoP2()
    {
        if ((selector) && (!falta) && (!tRobo) && !equipo&& MngScenes.multijugador)
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
                if (Input.GetButtonDown("FaltaP2"))
                {
                    Vector3 distanciaBalon = balon.transform.position - transform.position;
                    hacerFalta(distanciaBalon.normalized);
                }
            }
            if (Input.GetButtonDown("GolpeoP2") && balonPies && !balonGolpeado)
            {
                if (equipo)
                    balon.ultimoTocado = true;
                if (!equipo)
                    balon.ultimoTocado = false;
                balonPies = false;
                balonGolpeado = true;
                balon.interceptado = false;
                balon.tiempo = true;
                balon.fuerzaL = fuerzaGolpeo;
                balon.direccion = new Vector2(Input.GetAxisRaw("HorizontalP2"), Input.GetAxisRaw("VerticalP2"));
                balon.golpeoV2();
                StartCoroutine(setBalonGolpeadoFalse());
                StartCoroutine(balon.setBalonTiempoFalse());
            }
        }

    }

    private void stupidAI(){
        bool team = false;
        if (GameObject.FindGameObjectWithTag("balonPies") != null)
        {
            team = GameObject.FindGameObjectWithTag("balonPies").GetComponent<JugadorV2>().equipo;
        }
        Vector3 dist = transform.position - posicion.transform.position;
        Vector3 distBalon = posicion.transform.position - balon.transform.position;
        if ((dist.magnitude < 17f) && (!selector))
        {//si estamos dentro de la zona de accion
            if (!balon.interceptado)
            {
                Vector3 distanciaBalon = balon.transform.position - transform.position;
                transform.position += distanciaBalon.normalized * Time.deltaTime * vel;            
            }else
            {
                if (team != equipo)
                {
                    Vector3 distanciaBalon = balon.transform.position - transform.position;
                    transform.position += distanciaBalon.normalized * Time.deltaTime * vel;
                    if ((distanciaBalon.magnitude < 4f) && balon.interceptado && !balon.balonFuera && !PorteroV2.esPortero)
                    {
                        ar.SetBool("falta", true);
                        hacerFalta(distanciaBalon.normalized);
                    }
                }
            }

            
            if ( balonPies && !MngScenes.multijugador&& !equipo)
            {
                Vector3 distancia = porteriaRival.transform.position - transform.position;
                transform.position += distancia.normalized * Time.deltaTime * vel;
            }

            if ((dist.magnitude < 17f) && (!selector) && team == equipo)
            {//zona de accion y yo tengo el balon
                if (transform.position.y > balon.transform.position.y)
                {
                    transform.position += Vector3.down * Time.deltaTime * vel;
                }
                if (transform.position.y < balon.transform.position.y)
                    transform.position += Vector3.up * Time.deltaTime * vel;
            }
        }
        if ((dist.magnitude > 16f) && (!selector))
        {//si estamos fuera de la zona y no somos el selector
            transform.position -= dist.normalized * Time.deltaTime * vel;
        }
    }

	private void animatorObserver (){
		if (lastPosition == transform.position.y)
			ar.SetBool ("corriendo", false);
		if (lastPosition < transform.position.y) {
			ar.SetBool ("corriendo", true);
			if (flipY) {
				transform.localScale = new Vector3 (transform.localScale.x, -transform.localScale.y);
				flipY = false;
			}
			lastPosition = transform.position.y;
		}
		if (lastPosition > transform.position.y) {
			ar.SetBool ("corriendo", true);
			if (!flipY) {
				transform.localScale = new Vector3 (transform.localScale.x, -transform.localScale.y);
				flipY = true;
			}
			lastPosition = transform.position.y;
		}
	}

	public void hacerFalta(Vector3 dirFalta)
	{//vector normalizado 
		tRobo = true;
		if (tRobo) {
			StartCoroutine (setTRoboFalse ());
			Vector3 distancia = new Vector3 (3, 3);
			GameObject jugadorConPelota = GameObject.FindGameObjectWithTag ("balonPies");
			transform.position += dirFalta * Time.deltaTime * vel/3;
			if (jugadorConPelota != null){
                distancia = jugadorConPelota.transform.position - transform.position;  
                if (distancia.magnitude < 2f){
                    equipoRival.jugadores[equipoRival.jugadorCercano()].balonPies = false;
                    equipoRival.jugadores[equipoRival.jugadorCercano()].falta = true;
                    StartCoroutine(equipoRival.jugadores[equipoRival.jugadorCercano()].setFaltaFalse());
                    balon.interceptado = false;
                }
			}
		}  
	}


	public void conducirBalon()
	{
		if (balonPies && !balonGolpeado)
		{ 
			if (flipY) {
				Vector3 posbal = new Vector3 (transform.position.x, transform.position.y - 0.5f);
				balon.setPosicion (posbal);
			}
			if (!flipY){
				Vector3 posbal = new Vector3 (transform.position.x, transform.position.y + 0.5f);
				balon.setPosicion (posbal);
			}
		}
	}

	private void marcar() {
		if (selector){
			Vector3 posicionNuestra = new Vector3(transform.position.x, transform.position.y);
			seguidor.setPosicion(posicionNuestra);
		}
	}

}