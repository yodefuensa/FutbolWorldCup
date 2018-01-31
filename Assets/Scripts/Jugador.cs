using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Jugador : MonoBehaviour {

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
    public MngRival equipoRival;
	private float lastPosition = 0;

    private void Awake()
    {

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
            conducirBalon();
        }
        marcar();

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
					StopCoroutine ("balon.setBalonTiempoFalse");

                }
                if (hit.tag == "balonPies")
                {
                    robo = true;
                }
            }
        }

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

    private void movimiento()
    {
        if ((selector) && (!falta) && (!tRobo))
        {
           // Vector3 noMove = balon.
            if (!balon.balonFuera) { 
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    transform.position += Vector3.up * Time.deltaTime * vel;
                    ar.SetBool("corriendo", true);
                    if (flipY)
                    {
                        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y);
                        flipY = false;
                    }
                }
                if (Input.GetAxisRaw("Vertical") < 0)
                {
                    transform.position += Vector3.down * Time.deltaTime * vel;
                    ar.SetBool("corriendo", true);
                    if (!flipY)
                    {
                        transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y);
                        flipY = true;
                    }
                }

                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    transform.position += new Vector3(1, 0) * Time.deltaTime * vel;
                }
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    transform.position -= new Vector3(1, 0) * Time.deltaTime * vel;
                }
                if (Input.GetButtonDown("Falta"))
                {
                    ar.SetBool("falta", true);
                    hacerFalta(new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
                }
            }
            if (Input.GetButtonDown("Golpeo") && balonPies && !balonGolpeado && balon.ultimoTocado)
            {
                balon.ultimoTocado = true;
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
        Vector3 dist = transform.position - posicion.transform.position;
		Vector3 distBalon = posicion.transform.position - balon.transform.position;
        if ((dist.magnitude < 17f) && (!selector))
        {
            //si estamos dentro de la zona de accion
            if (!balon.ultimoTocado)
            {// y ellos tienen el balon
			
                if ((transform.position.y > balon.transform.position.y + 1 || transform.position.y < balon.transform.position.y - 1
					|| transform.position.x > balon.transform.position.x + 1 || transform.position.x < balon.transform.position.x - 1) && distBalon.magnitude<16f)
                {//vamos a por el balon
					Vector3 distanciaBalon = balon.transform.position - transform.position;
					transform.position += distanciaBalon.normalized * Time.deltaTime * vel;
					if ((distanciaBalon.magnitude < 4f)&& balon.interceptado && !balon.balonFuera&& !PorteroV2Rival.esPortero) {
						ar.SetBool ("falta", true);
						hacerFalta (distanciaBalon.normalized);
					}
                }
            }
			if ((dist.magnitude<17f) && (!selector) && (balon.ultimoTocado))
            {//zona de accion y yo tengo el balon
                if (transform.position.y > balon.transform.position.y)
                {
                    transform.position += Vector3.down * Time.deltaTime * vel;
                }
                if (transform.position.y < balon.transform.position.y)
                    transform.position += Vector3.up * Time.deltaTime * vel;
            }
        }
        if ((dist.magnitude>16f) &&(!selector)) 
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

	public IEnumerator setBalonGolpeadoFalse()
	{//para no tocar el balon al golpearlo
		yield return new WaitForSeconds(.5f);
		balonGolpeado = false;
		balonPies = false;
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
                    equipoRival.Rival[equipoRival.rivalCercano()].balonPies = false;
                    equipoRival.Rival[equipoRival.rivalCercano()].falta = true;
                    StartCoroutine(equipoRival.Rival[equipoRival.rivalCercano()].setFaltaFalse());
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
		

	void FixedUpdate()
	{
		if (!selector)
			animatorObserver ();

        if (!balonPies)
            this.tag = "Jugador";
        else
        {
            this.tag = "balonPies";
			selector = true;
			balon.ultimoTocado = true;

		}
        
    }

}