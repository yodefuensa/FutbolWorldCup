using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Jugador : MonoBehaviour {

	public Balon balon;
	public bool balonGolpeado = false;
	public bool balonPies = false;
	public bool selector = false;
	private int vel = 8;
	public int fuerzaGolpeo = 20;
    //robo es para saber si podremos robar la pelota
    public bool robo;
    //cuando se pulse C bloqueamos el movimiento y le damos la direccion de la falta
    public bool tRobo;
    //zasca te han hecho falta te caes al suelo no te puedes mover durante X tiempo
    public bool falta;
    //magnitud se usa en el manager partido, para saber que jugadores estaran mas cerca al salir la pelota
    public Vector3 dirFalta;
	public float magnitud = 0;
    public Vector2 posicionInicial;
	public GameObject posicion;
	private Animator ar;
	public bool flipY = false;


	void Start () {
        falta = false;
        tRobo = false;
		ar = GetComponent<Animator>();
	}

	void Update () {
		Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
		if (hits.Length > 1) {
			foreach (Collider2D hit in hits) {
				if (hit.name == "balon") {
					balonPies = true;
					selector = true;
					if (!balonGolpeado) {
						balon.interceptado = true;
					}
                    robo = true;
                }
                else
                {
                    robo = false;
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
				balon.fuerzaL = fuerzaGolpeo;
				balon.direccion = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
				balon.golpeoV2 ();
				//StartCoroutine(balon.Golpeo(fuerzaGolpeo));
				StartCoroutine (setBalonGolpeadoFalse ());
				StartCoroutine (balon.setBalonTiempoFalse ());

			}
		} else 
		{
			ar.SetBool ("corriendo", false);
			ar.SetBool ("parado", true);
		}
	}

	public IEnumerator setBalonGolpeadoFalse()
	{//para no tocar el balon al golpearlo
		for (int n = 0; n < 10; n++)
		{
			yield return new WaitForSeconds(.1f);
		}
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
            Debug.Log("ME CAGO EN DIOS 2");
            transform.position += dirFalta * Time.deltaTime * vel;
        }
    }

    public void Entrada()
    {//pal Fixed
       if (Input.GetKey(KeyCode.C))
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
                
            }
       }

    }
		

	void FixedUpdate()
	{
        Entrada();
		movimiento();
		conducirBalon();
        movimientoFalta();
	}

}