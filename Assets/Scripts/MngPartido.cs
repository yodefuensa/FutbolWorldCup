using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MngPartido : MonoBehaviour {
    public Balon balon;
	public Vector3 balonPosicionSaque;
    public GameObject esquina1;
    public GameObject esquina4;
    public Palo palo1;
    public Palo palo3;
    public ManagerPersonajes mngEqui;
    public MngRival mngRiv;
	public GameObject menu;
    public int gol;
    public int golesRivales;
    private bool quienSaca;
    private int ObGol;
    private int ObGol2;
	public Text marcador;
	public Text tiempo;
    public static bool visible;
	private float time;
	private float min;



    void Start () {
        gol = 0;
        golesRivales = 0;
        ObGol = 0;
        ObGol2 = 0;
		min = 0;
        visible = false;
	}
	
	void Update () {		
	}

	public void ordeanar()
	{//ordenado la propiedad jugadores de mngEqui, en base a la propiedad magnitud de los jugadores,
		for (int x = 0; x < mngEqui.jugadores.Length-1; x++)
		{
			for (int k = 0; k < mngEqui.jugadores.Length-1 - x;k++ )
			{

				if (mngEqui.jugadores[k].magnitud < mngEqui.jugadores[k + 1].magnitud)
				{
					Jugador aux;
					aux = mngEqui.jugadores[k];
					mngEqui.jugadores[k] = mngEqui.jugadores[k + 1];
					mngEqui.jugadores[k + 1] = aux;
				}

			}
		}
	}
	public void ordeanar2()
	{//ordenado la propiedad jugadores de mngEqui, en base a la propiedad magnitud de los jugadores,
		for (int x = 0; x < mngRiv.Rival.Length-1; x++)
		{
			for (int k = 0; k < mngRiv.Rival.Length-1 - x;k++ )
			{

				if (mngRiv.Rival[k].magnitud < mngRiv.Rival[k + 1].magnitud)
				{
					Rival aux;
					aux = mngRiv.Rival[k];
					mngRiv.Rival[k] = mngRiv.Rival[k + 1];
					mngRiv.Rival[k + 1] = aux;
				}

			}
		}
	}

    private void colocarPersonajesSaque()
    {
        mngEqui.jugadores[0].posicionInicial = new Vector2(-3.05f,- 1.43f);
        mngEqui.jugadores[1].posicionInicial = new Vector2(3.28f, -1.43f);
        mngEqui.jugadores[2].posicionInicial = new Vector2(-15f, -12f);
        mngEqui.jugadores[3].posicionInicial = new Vector2(15f, -12f);
        mngEqui.jugadores[4].posicionInicial = new Vector2(-10.3f, -24.3f);
        mngEqui.jugadores[5].posicionInicial = new Vector2(0f, -24.3f);
        mngEqui.jugadores[6].posicionInicial = new Vector2(10.3f, -24.3f);
        mngEqui.jugadores[7].posicionInicial = new Vector2(-20.5f, -38.7f);
        mngEqui.jugadores[8].posicionInicial = new Vector2(0f, -38.7f);
        mngEqui.jugadores[9].posicionInicial = new Vector2(20.5f, -38.7f);

        mngRiv.Rival[0].posInicial = new Vector2(-8.6f, 10.1f);
        mngRiv.Rival[1].posInicial = new Vector2(8.6f, 10.1f);
        mngRiv.Rival[2].posInicial = new Vector2(-15f, 12f);
        mngRiv.Rival[3].posInicial = new Vector2(15f, 12f);
        mngRiv.Rival[4].posInicial = new Vector2(-10.3f, 24.3f);
        mngRiv.Rival[5].posInicial = new Vector2(10.3f, 24.3f);
        mngRiv.Rival[6].posInicial = new Vector2(-20.5f, 38.7f);
        mngRiv.Rival[7].posInicial = new Vector2(0f, 38.7f);
        mngRiv.Rival[8].posInicial = new Vector2(20.5f, +38.7f);
        mngRiv.Rival[9].posInicial = new Vector2(20.5f, +38.7f);
    }
    private void colocarPersonajesSaqueRival()
    {
        mngEqui.jugadores[0].posicionInicial = new Vector2(-8.6f, -10.43f);
        mngEqui.jugadores[1].posicionInicial = new Vector2(8.6f, -10.43f);
        mngEqui.jugadores[2].posicionInicial = new Vector2(-15f, -12f);
        mngEqui.jugadores[3].posicionInicial = new Vector2(15f, -12f);
        mngEqui.jugadores[4].posicionInicial = new Vector2(-10.3f, -24.3f);
        mngEqui.jugadores[5].posicionInicial = new Vector2(0f, -24.3f);
        mngEqui.jugadores[6].posicionInicial = new Vector2(10.3f, -24.3f);
        mngEqui.jugadores[7].posicionInicial = new Vector2(-20.5f, -38.7f);
        mngEqui.jugadores[8].posicionInicial = new Vector2(0f, -38.7f);
        mngEqui.jugadores[9].posicionInicial = new Vector2(20.5f, -38.7f);

        mngRiv.Rival[0].posInicial = new Vector2(-3.05f, 1.43f);
        mngRiv.Rival[1].posInicial = new Vector2(3.05f, 1.43f);
        mngRiv.Rival[2].posInicial = new Vector2(-15f, 12f);
        mngRiv.Rival[3].posInicial = new Vector2(15f, 12f);
        mngRiv.Rival[4].posInicial = new Vector2(-10.3f, 24.3f);
        mngRiv.Rival[5].posInicial = new Vector2(10.3f, 24.3f);
        mngRiv.Rival[6].posInicial = new Vector2(-20.5f, 38.7f);
        mngRiv.Rival[7].posInicial = new Vector2(0f, 38.7f);
        mngRiv.Rival[8].posInicial = new Vector2(20.5f, +38.7f);
        mngRiv.Rival[9].posInicial = new Vector2(20.5f, +38.7f);
        
    }

    private void saqueInicial()
    {
		mngEqui.limpiarBalonPies();
		mngRiv.limpiarBalonPies ();
		balon.interceptado = false;
        if (!quienSaca)
        {
            colocarPersonajesSaque();
            balon.setPosicion(new Vector3(0f, 0f));
            for (int n = 0; n < 10; n++)
            {
                mngEqui.jugadores[n].transform.position = mngEqui.jugadores[n].posicionInicial;
            }
            for (int m = 0; m < 10; m++)
            {
                mngRiv.Rival[m].transform.position = mngRiv.Rival[m].posInicial;
            }
            balon.direccion = new Vector3(0, 0);

        }else {
            colocarPersonajesSaqueRival();
            balon.setPosicion(new Vector3(0f, 0f));
            for (int n = 0; n < 10; n++)
            {
                mngEqui.jugadores[n].transform.position = mngEqui.jugadores[n].posicionInicial;
            }
            for (int m = 0; m < 10; m++)
            {
                mngRiv.Rival[m].transform.position = mngRiv.Rival[m].posInicial;
            }
            balon.direccion = new Vector3(0, 0);

        }

    }

    private void saquesBanda()
    {

		if (((balon.transform.position.x < esquina1.transform.position.x) || (balon.transform.position.x > esquina4.transform.position.x)) && !balon.balonFuera)
		{
			Debug.Log ("esta fuera hostias");
			balon.balonFuera = true;
			balonPosicionSaque = new Vector2 (balon.transform.position.x, balon.transform.position.y);
			if (balon.ultimoTocado){
                //SACA EQUIPO RIVAL
				for (int n = 0; n < mngRiv.Rival.Length -1; n++){	
					Vector3 distancia = new Vector3(3, 3); 
					distancia = mngRiv.Rival[n].transform.position - balon.transform.position;
					mngRiv.Rival[n].magnitud = distancia.magnitude;
				}
				ordeanar2();
				if (balon.transform.position.x > 36f) {
					mngRiv.Rival[0].transform.position = new Vector2 (balonPosicionSaque.x + .7f, balonPosicionSaque.y);
					balon.transform.position = new Vector2 (balonPosicionSaque.x, balonPosicionSaque.y);
				}
				if (balon.transform.position.x < -36f) {
					mngRiv.Rival [0].transform.position = new Vector2 (balonPosicionSaque.x - .7f, balonPosicionSaque.y);
					balon.transform.position = new Vector2 (balonPosicionSaque.x, balonPosicionSaque.y);
				}

            }
            if (!balon.ultimoTocado)
			{//SACA TU EQUIPO
				for (int n = 0; n < mngEqui.jugadores.Length -1; n++){	
					Vector3 distancia = new Vector3(3, 3); 
					distancia = mngEqui.jugadores[n].transform.position - balon.transform.position;
					mngEqui.jugadores[n].magnitud = distancia.magnitude;
				}
				ordeanar ();
				if (balon.transform.position.x > 36f) {
					mngEqui.jugadores [0].transform.position = new Vector2 (balonPosicionSaque.x + .7f, balonPosicionSaque.y);
					balon.transform.position = new Vector2 (balonPosicionSaque.x, balonPosicionSaque.y);
				}
				if (balon.transform.position.x < -36f) {
					mngEqui.jugadores [0].transform.position = new Vector2 (balonPosicionSaque.x - .7f, balonPosicionSaque.y);
					balon.transform.position = new Vector2 (balonPosicionSaque.x, balonPosicionSaque.y);
				}
			} 

		}
		if ((balon.transform.position.x > esquina1.transform.position.x) && (balon.transform.position.x < esquina4.transform.position.x)) {
			balon.balonFuera = false;
		}
    }

	public void saquePorteria(){
		if ((balon.transform.position.y > esquina1.transform.position.y) && !balon.balonFuera) {
			Debug.Log ("esta fuera hostias Portero");
			balon.balonFuera = true;
			if (balon.ultimoTocado) {
				//saca equipo rival
				mngRiv.benji.transform.position = new Vector3 (esquina1.transform.position.x + 15f, esquina1.transform.position.y - .7f);
				balon.transform.position = new Vector2 (esquina1.transform.position.x + 15f, esquina1.transform.position.y - 1.4f);
		}if ((balon.transform.position.y < esquina4.transform.position.y) && !balon.balonFuera){
			balon.balonFuera = true;
				if (!balon.ultimoTocado) {
					mngEqui.benji.transform.position = new Vector3 (esquina4.transform.position.x - 15f, esquina4.transform.position.y + .7f);
					balon.transform.position = new Vector2 (esquina4.transform.position.x-15f, esquina4.transform.position.y + 1.4f);
				}
		}
		//	balon.balonFuera = false;
		}
	}

    public void menuPause()
    {
        if (Input.GetKey(KeyCode.Joystick1Button7))
        {
			menu.transform.localPosition = new Vector3 (0, 0,4f);
			Time.timeScale = 0;
            visible = true;
        }

    }
    public void mainMenu()
    {
        if (visible){
            SceneManager.LoadScene("menu");
            Time.timeScale = 1f;
        }
    }
    public void restart()
    {
        if (visible)
        {
            SceneManager.LoadScene("pruebas");
            Time.timeScale = 1f;
            
        }
    }

    public void menuPauseContinue() {
        if (visible)
        {
            menu.transform.position = new Vector3(-50f, 0, 4f);
            Time.timeScale = 1f;
            visible = false;
        }
	}



    public void observador()
    {
        if (ObGol < gol)
        {
            Debug.Log("observador 1");
            ObGol = gol;
            quienSaca = true;
            saqueInicial();
        }
        if (ObGol2 < golesRivales)
        {
            quienSaca = false;
            Debug.Log("observador 2");
            ObGol2 = golesRivales;
            saqueInicial();
        }
       
    }

	private void actualizarMarcador()
	{
		if (marcador.text != gol + " - " + golesRivales) 
		{
			marcador.text = gol + " - " + golesRivales;
		}	
	
	}
	private void actualizarTiempo()
	{
		time += Time.deltaTime*12;
		if (Mathf.Round (time) == 59) {
			time = 0;
			min = min + 1;
		}
        float num = Mathf.Round(time);

        if (num<10)
			tiempo.text = "Time: " + min + ":" + "0"  + Mathf.Round(time);
		if (tiempo.text != "Time: " + min + ":" + Mathf.Round (time))
			tiempo.text = "Time: " + min + ":" + Mathf.Round(time);
		
	}



    private void FixedUpdate()
    {
        gol = gol + palo1.Marcar();
        golesRivales = golesRivales + palo3.Marcar();
		saquesBanda ();
        observador();
		saquePorteria ();
		actualizarMarcador ();
		actualizarTiempo ();
		menuPause ();
    }

}
