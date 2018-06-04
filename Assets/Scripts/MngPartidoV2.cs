using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MngPartidoV2 : MonoBehaviour {
    public Balon balon;
	public Vector3 balonPosicionSaque;
    public GameObject esquina1;
    public GameObject esquina4;
    public Palo palo1;
    public Palo palo3;
    public MngEquiV2 mngEqui;
    public MngEquiV2 mngRiv;
	public GameObject menu;
    public int gol;
    public int golesRivales;
    private bool quienSaca;
    private int ObGol;
    private int ObGol2;
	public Text marcador;
	public Text tiempo;
    public GameObject win;
    public GameObject lose;
    public GameObject extraTime;
    public static bool visible;
	private float time;
	private float min;
	public AudioClip goal, arbitro;



    void Start () {
        gol = 0;
        golesRivales = 0;
        ObGol = 0;
        ObGol2 = 0;
		min = 0;
        visible = false;
		mngAudio.instance.playSfxClip (arbitro);

    }

    private void FixedUpdate()
    {
        gol = gol + palo1.Marcar();
        golesRivales = golesRivales + palo3.Marcar();
        saquesBanda();
        observador();
        saquePorteria();
        actualizarMarcador();
        actualizarTiempo();
        menuPause();
        corner();
        fin();
        balonPorteroPies();
        limpiarBugBalonEnMasDeUnPutoPie();
    }


    public void ordeanar()
	{//ordenado la propiedad jugadores de mngEqui, en base a la propiedad magnitud de los jugadores,
		for (int x = 0; x < mngEqui.jugadores.Length-1; x++)
		{
			for (int k = 0; k < mngEqui.jugadores.Length-1 - x;k++ )
			{

				if (mngEqui.jugadores[k].magnitud < mngEqui.jugadores[k + 1].magnitud)
				{
					JugadorV2 aux;
					aux = mngEqui.jugadores[k];
					mngEqui.jugadores[k] = mngEqui.jugadores[k + 1];
					mngEqui.jugadores[k + 1] = aux;
				}

			}
		}
	}
	public void ordeanar2()
	{//ordenado la propiedad jugadores de mngEqui, en base a la propiedad magnitud de los jugadores,
		for (int x = 0; x < mngRiv.jugadores.Length-1; x++)
		{
			for (int k = 0; k < mngRiv.jugadores.Length-1 - x;k++ )
			{

				if (mngRiv.jugadores[k].magnitud < mngRiv.jugadores[k + 1].magnitud)
				{
					JugadorV2 aux;
					aux = mngRiv.jugadores[k];
					mngRiv.jugadores[k] = mngRiv.jugadores[k + 1];
					mngRiv.jugadores[k + 1] = aux;
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

        mngRiv.jugadores[0].posicionInicial = new Vector2(-8.6f, 10.1f);
        mngRiv.jugadores[1].posicionInicial = new Vector2(8.6f, 10.1f);
        mngRiv.jugadores[2].posicionInicial = new Vector2(-15f, 12f);
        mngRiv.jugadores[3].posicionInicial = new Vector2(15f, 12f);
        mngRiv.jugadores[4].posicionInicial = new Vector2(-10.3f, 24.3f);
        mngRiv.jugadores[5].posicionInicial = new Vector2(10.3f, 24.3f);
        mngRiv.jugadores[6].posicionInicial = new Vector2(-20.5f, 38.7f);
        mngRiv.jugadores[7].posicionInicial = new Vector2(0f, 38.7f);
        mngRiv.jugadores[8].posicionInicial = new Vector2(20.5f, +38.7f);
        mngRiv.jugadores[9].posicionInicial = new Vector2(20.5f, +38.7f);
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

        mngRiv.jugadores[0].posicionInicial = new Vector2(-3.05f, 1.43f);
        mngRiv.jugadores[1].posicionInicial = new Vector2(3.05f, 1.43f);
        mngRiv.jugadores[2].posicionInicial = new Vector2(-15f, 12f);
        mngRiv.jugadores[3].posicionInicial = new Vector2(15f, 12f);
        mngRiv.jugadores[4].posicionInicial = new Vector2(-10.3f, 24.3f);
        mngRiv.jugadores[5].posicionInicial = new Vector2(10.3f, 24.3f);
        mngRiv.jugadores[6].posicionInicial = new Vector2(-20.5f, 38.7f);
        mngRiv.jugadores[7].posicionInicial = new Vector2(0f, 38.7f);
        mngRiv.jugadores[8].posicionInicial = new Vector2(20.5f, +38.7f);
        mngRiv.jugadores[9].posicionInicial = new Vector2(20.5f, +38.7f);
        
    }

    private void saqueInicial()
    {
        if (!quienSaca)
        {
            colocarPersonajesSaque();
            balon.setPosicion(new Vector3(0f, 0f));
            for (int n = 0; n < 10; n++){
                mngEqui.jugadores[n].transform.position = mngEqui.jugadores[n].posicionInicial;
            }
            for (int m = 0; m < 10; m++){
                mngRiv.jugadores[m].transform.position = mngRiv.jugadores[m].posicionInicial;
            }
            balon.direccion = new Vector3(0, 0);
            balon.interceptado = false;
        }
        else {
            colocarPersonajesSaqueRival();
            balon.setPosicion(new Vector3(0f, 0f));
            for (int n = 0; n < 10; n++){
                mngEqui.jugadores[n].transform.position = mngEqui.jugadores[n].posicionInicial;
            }
            for (int m = 0; m < 10; m++)            {
                mngRiv.jugadores[m].transform.position = mngRiv.jugadores[m].posicionInicial;
            }
            balon.direccion = new Vector3(0, 0);
            balon.interceptado = false;
        }
    }

    private void saquesBanda()
    {
		int aux=0;
		if (((balon.transform.position.x < esquina1.transform.position.x) || (balon.transform.position.x > esquina4.transform.position.x)) && !balon.balonFuera)
		{
			Debug.Log ("esta fuera hostias");
			balon.balonFuera = true;
            balonPosicionSaque = new Vector2 (balon.transform.position.x, balon.transform.position.y);
			if (balon.ultimoTocado){
                //SACA EQUIPO RIVAL
				for (int n = 0; n < mngRiv.jugadores.Length -1; n++){	
					Vector3 distancia = new Vector3(3, 3); 
					distancia = mngRiv.jugadores[n].transform.position - balon.transform.position;
					mngRiv.jugadores[n].magnitud = distancia.magnitude;
				}
				for (int m = 0; m < mngEqui.jugadores.Length - 1; m++) {
					if (mngEqui.jugadores [m].balonPies == true)
						aux = m;
				}
				ordeanar2();
				if (balon.transform.position.x > 36f) {
					mngRiv.jugadores[0].transform.position = new Vector2 (balonPosicionSaque.x + .7f, balonPosicionSaque.y);
					mngEqui.jugadores [aux].balonPies = false;
					mngEqui.jugadores [aux].transform.position =new Vector2 (mngEqui.jugadores [aux].transform.position .x - 3f, mngEqui.jugadores [aux].transform.position .y);
					mngRiv.jugadores[0].balonPies = true;
					mngRiv.jugadores[0].selector = true;
					balon.transform.position = new Vector2 (balonPosicionSaque.x, balonPosicionSaque.y);
				}
				if (balon.transform.position.x < -36f) {
					mngRiv.jugadores[0].transform.position = new Vector2 (balonPosicionSaque.x - .7f, balonPosicionSaque.y);
					mngEqui.jugadores [aux].balonPies = false;
					mngEqui.jugadores [aux].transform.position =new Vector2 (mngEqui.jugadores [aux].transform.position .x + 3f, mngEqui.jugadores [aux].transform.position .y);
					mngRiv.jugadores[0].balonPies = true;
					mngRiv.jugadores[0].selector = true;
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
				for (int m = 0; m < mngRiv.jugadores.Length - 1; m++) {
					if (mngRiv.jugadores[m].balonPies == true)
						aux = m;
				}
				ordeanar ();
				if (balon.transform.position.x > 36f) {
					mngEqui.jugadores [0].transform.position = new Vector2 (balonPosicionSaque.x + .7f, balonPosicionSaque.y);
					mngRiv.jugadores[aux].balonPies = false;
					mngRiv.jugadores[aux].transform.position =new Vector2 (mngRiv.jugadores[aux].transform.position .x - 3f,mngRiv.jugadores[aux].transform.position .y);
					balon.transform.position = new Vector2 (balonPosicionSaque.x, balonPosicionSaque.y);
					mngEqui.jugadores [0].balonPies = true;

				}
				if (balon.transform.position.x < -36f) {
					mngEqui.jugadores [0].transform.position = new Vector2 (balonPosicionSaque.x - .7f, balonPosicionSaque.y);
					mngRiv.jugadores[aux].balonPies = false;
					mngRiv.jugadores[aux].transform.position =new Vector2 (mngRiv.jugadores[aux].transform.position .x - 3f,mngRiv.jugadores[aux].transform.position .y);
					balon.transform.position = new Vector2 (balonPosicionSaque.x, balonPosicionSaque.y);
					mngEqui.jugadores [0].balonPies = true;
				}
			}

		}
		if ((balon.transform.position.x > esquina1.transform.position.x) && (balon.transform.position.x < esquina4.transform.position.x)) {
			balon.balonFuera = false;
		}
    }
    public void corner()
    {
        int aux = 0;
        if ((balon.transform.position.y < esquina4.transform.position.y) && balon.ultimoTocado){
            //saca el equipo rival
            balon.balonFuera = true;
           
			for (int n = 0; n < mngRiv.jugadores.Length - 1; n++) {	
				Vector3 distancia = new Vector3 (3, 3); 
				distancia = mngRiv.jugadores[n].transform.position - balon.transform.position;
				mngRiv.jugadores[n].magnitud = distancia.magnitude;
			}
            ordeanar2();
            for (int m = 0; m < mngEqui.jugadores.Length - 1; m++)
            {
                if (mngEqui.jugadores[m].balonPies == true)
                    aux = m;
            }
            mngEqui.jugadores[aux].balonPies = false;
            mngEqui.jugadores[aux].transform.position = new Vector2(mngEqui.jugadores[aux].transform.position.x - 5f, mngEqui.jugadores[aux].transform.position.y - 5f);
            balon.transform.position = new Vector2(esquina4.transform.position.x + .01f, esquina4.transform.position.y+.01f);
            mngRiv.jugadores[0].transform.position = new Vector2(balon.transform.position.x + .7f, balon.transform.position.y);
            mngRiv.jugadores[0].balonPies = true;
            mngRiv.jugadores[0].selector = true;
        }
        if ((balon.transform.position.y > esquina1.transform.position.y) && !balon.ultimoTocado)
        {// saca tu equipo
            balon.balonFuera = true;         
			for (int n = 0; n < mngEqui.jugadores.Length -1; n++){	
				Vector3 distancia = new Vector3(3, 3); 
				distancia = mngEqui.jugadores[n].transform.position - balon.transform.position;
				mngEqui.jugadores[n].magnitud = distancia.magnitude;
			}
            for (int m = 0; m < mngRiv.jugadores.Length - 1; m++)
            {
                if (mngRiv.jugadores[m].balonPies == true)
                    aux = m;
            }
            ordeanar();
            mngRiv.jugadores[aux].balonPies = false;
            balon.transform.position = new Vector2(esquina1.transform.position.x - .01f, esquina1.transform.position.y);
            mngEqui.jugadores[0].transform.position = new Vector2(balon.transform.position.x - .7f, balon.transform.position.y);
            mngEqui.jugadores[0].balonPies = true;
        }
    }

	public void saquePorteria(){
        int aux = 0;
		if ((balon.transform.position.y > esquina1.transform.position.y) && !balon.balonFuera && balon.ultimoTocado) {
			Debug.Log ("esta fuera hostias Portero");
			balon.balonFuera = true;
            for (int m = 0; m < mngEqui.jugadores.Length - 1; m++)
            {
                if (mngEqui.jugadores[m].balonPies == true)
                    aux = m;
            }
            //saca equipo rival
            mngEqui.jugadores[aux].balonPies = false;
            balon.transform.position = new Vector2(esquina1.transform.position.x + 15f, esquina1.transform.position.y - 1.4f);
            mngRiv.benji.transform.position = new Vector3(esquina1.transform.position.x + 15f, esquina1.transform.position.y - .7f);
            mngRiv.benji.balonPies = true;
            
		}
        if ((balon.transform.position.y < esquina4.transform.position.y) && !balon.balonFuera && !balon.ultimoTocado)
        {
            Debug.Log("esta fuera hostias Portero");
            balon.balonFuera = true;
            for (int m = 0; m < mngRiv.jugadores.Length - 1; m++)
            {
                if (mngRiv.jugadores[m].balonPies == true)
                    aux = m;
            }
            balon.balonFuera = true;
            mngRiv.jugadores[aux].balonPies = false;
            mngEqui.benji.transform.position = new Vector3(esquina4.transform.position.x - 15f, esquina4.transform.position.y + .7f);
            balon.transform.position = new Vector2(esquina4.transform.position.x - 15f, esquina4.transform.position.y + 1.4f);
            mngEqui.benji.balonPies = true;
            
        }
	}
	//	balon.balonFuera = false;



    public void menuPause()
    {
		if (Input.GetButtonDown("Pause")|| Input.GetKeyDown(KeyCode.Escape))
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
            if (!MngScenes.multijugador){
                SceneManager.LoadScene("pruebasV2");
                Time.timeScale = 1f;
            }
            if (MngScenes.multijugador){
                SceneManager.LoadScene("Multi");
                Time.timeScale = 1f;
            }

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
    private IEnumerator setTimeOne()
    {//para no tocar el balon al golpearlo
        yield return new WaitForSeconds(.3f);
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }

    private void fin()
    {
        if ((min >= 90) && (gol!=golesRivales)){
            if (gol > golesRivales) {
                win.transform.localPosition = new Vector3(0, 0, 4f);
                StartCoroutine(setTimeOne());
                Time.timeScale = 0.05f;
            }
            if (golesRivales > gol) {
                lose.transform.localPosition = new Vector3(0, 0, 4f);
                StartCoroutine(setTimeOne());
                Time.timeScale = 0.05f;
            }
        }
        if ((min > 90) && (gol == golesRivales)) {
            extraTime.transform.localPosition = new Vector3(-187f, 187f, 4f);
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
			mngAudio.instance.playSfxClip (goal);
		}	
	
	}
	private void actualizarTiempo()
	{

        time += Time.deltaTime*20;
		if (Mathf.Round (time) == 59) {
			time = 0;
			min = min + 1;
		}
        float num = Mathf.Round(time);
        if (num < 10)
			tiempo.text =  min + ":" + "0"  + num ;
		else 
			tiempo.text = min + ":" + num ;
		
	}

    private void balonPorteroPies()
    {
        if (mngEqui.benji.balonPies == true)
        {
            mngEqui.limpiarBalonPies();
            mngRiv.limpiarBalonPies();
        }
        if (mngRiv.benji.balonPies == true)
        {
            mngEqui.limpiarBalonPies();
            mngRiv.limpiarBalonPies();
        }

    }
    private void limpiarBugBalonEnMasDeUnPutoPie()
    {
        int count = 0;
        for (int n = 0; n < mngEqui.jugadores.Length; n++)
        {
            if (mngEqui.jugadores[n].balonPies == true)
                count++;
        }
        for (int n = 0; n < mngRiv.jugadores.Length; n++)
        {
            if (mngRiv.jugadores[n].balonPies == true)
                count++;
        }
        if (count > 1){
            Debug.Log("la que has liado pollito");
            for (int m = 0; m < mngEqui.jugadores.Length; m++){
                mngEqui.jugadores[m].balonPies = false;
            }
            for (int n = 0; n < mngRiv.jugadores.Length; n++){
                mngRiv.jugadores[n].balonPies = false;
            }
            balon.interceptado = false;
        }
        
    }


}
