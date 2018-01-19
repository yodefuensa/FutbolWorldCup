using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rival : MonoBehaviour {

    // Use this for initialization
    public Balon ball;
    public bool balonGolpeado = false;
    public bool balonPies = false;
    private int vel = 6;
    private int fuerzaGolpeo = 10;
    public GameObject porteriaRival;
    public Vector2 posInicial;
    public ManagerPersonajes eqContra;
    public Vector3 dirFalta;
	public float magnitud = 0;
    //zasca te han hecho falta te caes al suelo no te puedes mover durante X tiempo
    public bool falta;
    //zasca te han hecho falta te caes al suelo no te puedes mover durante X tiempo
    public bool robo;
    //cuando se pulse C bloqueamos el movimiento y le damos la direccion de la falta
    public bool tRobo;
    public bool fakeInputC;
	//public bool fakeInputSpace;

    void Start () {
        fakeInputC = false;
        falta = false;
	}
	// Update is called once per frame
	void Update () {
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

    public void perseguir()
    {
		if ((!balonPies)&&(!falta))
        {
            if (transform.position.y > ball.transform.position.y + 1 || transform.position.y < ball.transform.position.y - 1
                   || transform.position.x > ball.transform.position.x + 1 || transform.position.x < ball.transform.position.x - 1)
            {
                if (transform.position.y > ball.transform.position.y)
                {
                    transform.position += Vector3.down * Time.deltaTime * vel;
                }
                if (transform.position.y < ball.transform.position.y)
                {
                    transform.position += Vector3.up * Time.deltaTime * vel;
                }
                if (transform.position.x > ball.transform.position.x)
                {
                    transform.position += Vector3.left * Time.deltaTime * vel;
                }
                if (transform.position.x < ball.transform.position.x)
                {
                    transform.position += Vector3.right * Time.deltaTime * vel;
                }
            }
        }
    }
    public void movimientoFalta()
    {//pa Entrada
		if ((tRobo) && (fakeInputC))
        {
            transform.position += dirFalta * Time.deltaTime * vel;
        }
    }

    public void hacerFalta()
    {
		if ((ball.interceptado) && (ball.ultimoTocado))
        {
            Vector3 distancia = new Vector3(3, 3);
            distancia = ball.transform.position - this.transform.position;
			if (distancia.magnitude < 4)
            {
				if (!falta){
	                fakeInputC = true;
	                StartCoroutine(setFakeInputCFalse());
					if (fakeInputC)
	                {
	                    tRobo = true;
	                    StartCoroutine(setTRoboFalse());
	                    dirFalta = distancia.normalized;
						if (robo)
						{
							eqContra.limpiarBalonPies ();
							eqContra.jugadores [eqContra.jugadorCercano ()].falta = true;
							StartCoroutine (eqContra.jugadores [eqContra.jugadorCercano ()].setFaltaFalse ());
							balonPies = true;
						}  
                    }
                }
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

    public void balonEnPies()
    {
        if (balonPies)
        {
            if (transform.position.y > porteriaRival.transform.position.y)
            {
                transform.position += Vector3.down * Time.deltaTime * vel;
            }
            if (transform.position.y < porteriaRival.transform.position.y)
            {
                transform.position += Vector3.up * Time.deltaTime * vel;
            }
            if (transform.position.x > porteriaRival.transform.position.x)
            {
                transform.position += Vector3.left * Time.deltaTime * vel;
            }
            if (transform.position.x < porteriaRival.transform.position.x)
            {
                transform.position += Vector3.right * Time.deltaTime * vel;
            }
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


    public void FixedUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
        if (!falta)
        {
            robo = false;
            foreach (Collider2D hit in hits)
            {
                if ((hit.name == "balon")&&(!ball.interceptado))
                {
                    balonPies = true;
                    if (!balonGolpeado)
                    {
                        ball.interceptado = true;
                    }

                }
                if (balonPies)
                    ball.ultimoTocado = false;
                if (hit.tag == "balonPies")
                    robo = true;
            }
            
        }
		golpearPelota ();
		conducirBalon ();
		balonEnPies ();
		hacerFalta ();
		movimientoFalta ();
        if (!balonPies)
            this.tag = "Rival";
        else
            this.tag = "balonPies";
    }

}
