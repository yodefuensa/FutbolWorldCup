using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngPartido : MonoBehaviour {
    public Balon balon;
	public Vector3 balonPosicionSaque;
    public GameObject esquina1;
    public GameObject esquina4;
    public Palo palo1;
    public Palo palo3;
    public ManagerPersonajes mngEqui;
    public MngRival mngRiv;
    public int gol;
    public int golesRivales;
    private bool quienSaca;
    private int ObGol;
    private int ObGol2;


    void Start () {
        gol = 0;
        golesRivales = 0;
        ObGol = 0;
        ObGol2 = 0;
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
        //meter opciones de tiempo
        if (quienSaca)
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
            }
			//cambiar por NOT cuando implemente los rivales
            if (balon.ultimoTocado)
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


    public void observador()
    {
        if (ObGol < gol)
        {
            Debug.Log("observador 1");
            ObGol = gol;
            quienSaca = true;
            saqueInicial();
        }
        else if (ObGol2 < golesRivales)
        {
            quienSaca = false;
            Debug.Log("observador 2");
            ObGol2 = golesRivales;
            saqueInicial();
        }
       
    }




    private void FixedUpdate()
    {
        gol = gol + palo1.Marcar();
        golesRivales = golesRivales + palo3.Marcar();
		saquesBanda ();
        observador();
    }

}
