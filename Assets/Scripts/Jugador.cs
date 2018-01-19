using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Jugador : MonoBehaviour {

	public Balon balon;
	public bool balonGolpeado = false;
	public bool balonPies = false;
	public bool selector = false;
	private int vel = 6;
	private int fuerzaGolpeo = 10;
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
    public MngRival equipoRival;


	void Start () {
        falta = false;
        tRobo = false;
        ar = GetComponent<Animator>();
	}

	void Update () {
		Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
        robo = false;
        if (!falta)
        {
            foreach (Collider2D hit in hits)
            {
                if ((hit.name == "balon") && (!balon.interceptado))
                {
                    balonPies = true;
                    selector = true;
                    if (!balonGolpeado)
                    {
                        balon.interceptado = true;
                    }

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
		if ((selector) && (!falta) && (!tRobo)) {
			if (Input.GetAxisRaw ("Vertical") > 0) {
				transform.position += Vector3.up * Time.deltaTime * vel;
				ar.SetBool ("corriendo", true);
				if (flipY)
				{
					transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y);
					flipY = false;
				}
			} else if (Input.GetAxisRaw ("Vertical") < 0) {
				transform.position += Vector3.down * Time.deltaTime * vel;
				ar.SetBool ("corriendo", true);
				if (!flipY)
				{
					transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y);
					flipY = true;
				}
			}

			if (Input.GetAxisRaw ("Horizontal") > 0) {
				transform.position += new Vector3 (1, 0) * Time.deltaTime * vel;
			} else if (Input.GetAxisRaw ("Horizontal") < 0) {
				transform.position -= new Vector3 (1, 0) * Time.deltaTime * vel;
			}
			if (Input.GetKey (KeyCode.Space) && balonPies && !balonGolpeado) {
				balon.ultimoTocado = true;
				balonPies = false;
				balonGolpeado = true;
				balon.interceptado = false;
				balon.tiempo = true;
				balon.fuerzaL = fuerzaGolpeo;
				balon.direccion = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
				balon.golpeoV2 ();
                StartCoroutine (setBalonGolpeadoFalse ());
				StartCoroutine (balon.setBalonTiempoFalse ());

			}
		} else 
		{
			ar.SetBool ("corriendo", false);
			ar.SetBool ("falta", false);
		}
		float dist = transform.position.x - posicion.transform.position.x;
		float dist2 = transform.position.y - posicion.transform.position.y;
		if ((!selector)&&(dist<8) &&(!balon.ultimoTocado)&&(dist2<8)) {
			if (transform.position.y > balon.transform.position.y + 1 || transform.position.y < balon.transform.position.y - 1
			    || transform.position.x > balon.transform.position.x + 1 || transform.position.x < balon.transform.position.x - 1) {
				if (transform.position.y > balon.transform.position.y) {
					transform.position += Vector3.down * Time.deltaTime * vel;
				}
				if (transform.position.y < balon.transform.position.y) {
					transform.position += Vector3.up * Time.deltaTime * vel;
				}
				if (transform.position.x > balon.transform.position.x) {
					transform.position += Vector3.left * Time.deltaTime * vel;
				}
				if (transform.position.x < balon.transform.position.x) {
					transform.position += Vector3.right * Time.deltaTime * vel;
				}
			}
		}
		if ((!balon.interceptado) && (!selector) && (dist < 20)) {
			
		}


	}

	public IEnumerator setBalonGolpeadoFalse()
	{//para no tocar el balon al golpearlo
		yield return new WaitForSeconds(.5f);
		balonGolpeado = false;
		balonPies = false;
	}

	public void conducirBalon()
	{
		if (balonPies && !balonGolpeado)
		{
			Vector3 posbal = new Vector3(transform.position.x, transform.position.y + 0.5f);
			balon.setPosicion(posbal);
		}
	}

    public void movimientoFalta()
    {//pa Entrada
        if ((tRobo)&&(selector))
        {
            transform.position += dirFalta * Time.deltaTime * vel;
        }
    }

    public void Entrada()
    {//pal Fixed
		if ((Input.GetKey(KeyCode.C))&&(selector))
       {
            dirFalta = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            tRobo = true;
			ar.SetBool ("falta", true);
            //movimiento falta en el puto fixed surprise madafaka
            //movimientoFalta();
            StartCoroutine(setTRoboFalse());
            //animacion 
            if (robo)
            {
                equipoRival.limpiarBalonPies();
                //equipoRival.rivalCercano();
                equipoRival.Rival[equipoRival.rivalCercano()].falta = true;
                StartCoroutine (equipoRival.Rival[equipoRival.rivalCercano()].setFaltaFalse());
                balonPies = true;
                //balon.ultimoTocado = true;


            }
       }

    }
	public void hacerFalta()
	{
		if ((balon.interceptado) && (!balon.ultimoTocado))
		{
			Vector3 distancia = new Vector3(3, 3);
			distancia = balon.transform.position - this.transform.position;
			if (distancia.magnitude < 4)
			{
				if (!falta){
					tRobo = true;
					StartCoroutine(setTRoboFalse());
					dirFalta = distancia.normalized;
					if (robo)
					{
						equipoRival.limpiarBalonPies ();
						equipoRival.Rival [equipoRival.rivalCercano ()].falta = true;
						StartCoroutine (equipoRival.Rival[equipoRival.rivalCercano ()].setFaltaFalse());
						balonPies = true;
					}  
				}
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
		if (!falta) {
			movimiento ();
			movimientoFalta();
			conducirBalon();
		}

		marcar ();
		hacerFalta ();

        if (!balonPies)
        {
			Entrada();
            this.tag = "Jugador";
        }
        else
        {
            this.tag = "balonPies";
			selector = true;
			balon.ultimoTocado = true;

		}
    }

}