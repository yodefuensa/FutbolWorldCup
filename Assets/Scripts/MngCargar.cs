using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngCargar : MonoBehaviour {

    public GameObject spain;
	public GameObject brasil;
	public GameObject usa;
	public GameObject argentina;
	public GameObject japon;
	public GameObject china;
	public GameObject rusia;
	public GameObject alemania;
    public GameObject balon;
	public GameObject guia;
	public GameObject equiRiv;
	public GameObject mngJugadores;
	public GameObject AliA;
	public GameObject AliB;
    public GameObject AlRiv;
    public GameObject rival;
	public GameObject portero;
	public GameObject porteroR;

	private GameObject rival0;
	private GameObject rival1;
	private GameObject rival2;
	private GameObject rival3;
	private GameObject rival4;
	private GameObject rival5;	
	private GameObject rival6;
	private GameObject rival7;
	private GameObject rival8;
	private GameObject rival9;

	private GameObject jugador0;
	private GameObject jugador1;
	private GameObject jugador2;
	private GameObject jugador3;
	private GameObject jugador4;
	private GameObject jugador5;
	private GameObject jugador6;
	private GameObject jugador7;
	private GameObject jugador8;
	private GameObject jugador9;

	// Use this for initialization
	void Start () {
		jugador0.GetComponent<Jugador> ().posicion = GameObject.Find ("posicion");
		jugador1.GetComponent<Jugador> ().posicion = GameObject.Find ("posicion2");
		jugador2.GetComponent<Jugador> ().posicion = GameObject.Find ("posicion3");
		jugador3.GetComponent<Jugador> ().posicion = GameObject.Find ("posicion4");
		jugador4.GetComponent<Jugador> ().posicion = GameObject.Find ("posicion5");
		jugador5.GetComponent<Jugador> ().posicion = GameObject.Find ("posicion6");
		jugador6.GetComponent<Jugador> ().posicion = GameObject.Find ("posicion7");
		jugador7.GetComponent<Jugador> ().posicion = GameObject.Find ("posicion8");
		jugador8.GetComponent<Jugador> ().posicion = GameObject.Find ("posicion9");
		jugador9.GetComponent<Jugador> ().posicion = GameObject.Find ("posicion10");

		rival0.GetComponent<Rival> ().posicionAl = GameObject.Find ("posicionR");
		rival1.GetComponent<Rival> ().posicionAl = GameObject.Find ("posicion2R");
		rival2.GetComponent<Rival> ().posicionAl = GameObject.Find ("posicion3R");
		rival3.GetComponent<Rival> ().posicionAl = GameObject.Find ("posicion4R");
		rival4.GetComponent<Rival> ().posicionAl = GameObject.Find ("posicion5R");
		rival5.GetComponent<Rival> ().posicionAl = GameObject.Find ("posicion6R");
		rival6.GetComponent<Rival> ().posicionAl = GameObject.Find ("posicion7R");
		rival7.GetComponent<Rival> ().posicionAl = GameObject.Find ("posicion8R");
		rival8.GetComponent<Rival> ().posicionAl = GameObject.Find ("posicion9R");
		rival9.GetComponent<Rival> ().posicionAl = GameObject.Find ("posicion10R");

	}

    private void Awake()
    {//antes de cargar la escena
		rival0 = Instantiate (rival, new Vector2(transform.position.x+6f,transform.position.y+6f), Quaternion.identity);
		rival1 = Instantiate (rival, new Vector2( transform.position.x-6f,transform.position.y+6f), Quaternion.identity);
		rival2 = Instantiate (rival, new Vector2(transform.position.x-20f,transform.position.y+15f), Quaternion.identity);
		rival3 = Instantiate (rival, new Vector2( transform.position.x-10f,transform.position.y+15f), Quaternion.identity);
		rival4 = Instantiate (rival, new Vector2(transform.position.x+10f,transform.position.y+15f), Quaternion.identity);
		rival5 = Instantiate (rival, new Vector2(transform.position.x+20f,transform.position.y+15f), Quaternion.identity);
		rival6 = Instantiate (rival, new Vector2( transform.position.x-20f,transform.position.y+35f), Quaternion.identity);
		rival7 = Instantiate (rival, new Vector2(transform.position.x-10f,transform.position.y+35f), Quaternion.identity);
		rival8 = Instantiate (rival, new Vector2( transform.position.x+10f,transform.position.y+35f), Quaternion.identity);
		rival9 = Instantiate (rival, new Vector2(transform.position.x+20f,transform.position.y+35f), Quaternion.identity);

		portero = Instantiate (portero, new Vector2(transform.position.x,transform.position.y-55f), Quaternion.identity);
		porteroR = Instantiate (porteroR, new Vector2(transform.position.x,transform.position.y+55f), Quaternion.identity);

		if (MngScenes.pais == "spain") {
			jugador0 = Instantiate (spain, new Vector2(transform.position.x+3f,transform.position.y-3f), Quaternion.identity);
			jugador1 = Instantiate (spain, new Vector2(transform.position.x-3f,transform.position.y-3f), Quaternion.identity);
			jugador2 = Instantiate (spain, new Vector2(transform.position.x-20f,transform.position.y-15f), Quaternion.identity);
			jugador3 = Instantiate (spain, new Vector2(transform.position.x-10f,transform.position.y-15f), Quaternion.identity);
			jugador4 = Instantiate (spain, new Vector2(transform.position.x+10f,transform.position.y-15f), Quaternion.identity);
			jugador5 = Instantiate (spain, new Vector2(transform.position.x+20f,transform.position.y-15f), Quaternion.identity);
			jugador6 = Instantiate (spain, new Vector2(transform.position.x-20f,transform.position.y-35f), Quaternion.identity);
			jugador7 = Instantiate (spain, new Vector2(transform.position.x-10f,transform.position.y-35f), Quaternion.identity);
			jugador8 = Instantiate (spain, new Vector2(transform.position.x+10f,transform.position.y-35f), Quaternion.identity);
			jugador9 = Instantiate (spain, new Vector2(transform.position.x+20f,transform.position.y-35f), Quaternion.identity);
		}
		if (MngScenes.pais == "brasil") {
			jugador0 = Instantiate (brasil, new Vector2(transform.position.x+3f,transform.position.y-3f), Quaternion.identity);
			jugador1 = Instantiate (brasil, new Vector2(transform.position.x-3f,transform.position.y-3f), Quaternion.identity);
			jugador2 = Instantiate (brasil, new Vector2(transform.position.x-20f,transform.position.y-15f), Quaternion.identity);
			jugador3 = Instantiate (brasil, new Vector2(transform.position.x-10f,transform.position.y-15f), Quaternion.identity);
			jugador4 = Instantiate (brasil, new Vector2(transform.position.x+10f,transform.position.y-15f), Quaternion.identity);
			jugador5 = Instantiate (brasil, new Vector2(transform.position.x+20f,transform.position.y-15f), Quaternion.identity);
			jugador6 = Instantiate (brasil, new Vector2(transform.position.x-20f,transform.position.y-35f), Quaternion.identity);
			jugador7 = Instantiate (brasil, new Vector2(transform.position.x-10f,transform.position.y-35f), Quaternion.identity);
			jugador8 = Instantiate (brasil, new Vector2(transform.position.x+10f,transform.position.y-35f), Quaternion.identity);
			jugador9 = Instantiate (brasil, new Vector2(transform.position.x+20f,transform.position.y-35f), Quaternion.identity);
		}
		if (MngScenes.pais == "usa") {
			jugador0 = Instantiate (usa, new Vector2(transform.position.x+3f,transform.position.y-3f), Quaternion.identity);
			jugador1 = Instantiate (usa, new Vector2(transform.position.x-3f,transform.position.y-3f), Quaternion.identity);
			jugador2 = Instantiate (usa, new Vector2(transform.position.x-20f,transform.position.y-15f), Quaternion.identity);
			jugador3 = Instantiate (usa, new Vector2(transform.position.x-10f,transform.position.y-15f), Quaternion.identity);
			jugador4 = Instantiate (usa, new Vector2(transform.position.x+10f,transform.position.y-15f), Quaternion.identity);
			jugador5 = Instantiate (usa, new Vector2(transform.position.x+20f,transform.position.y-15f), Quaternion.identity);
			jugador6 = Instantiate (usa, new Vector2(transform.position.x-20f,transform.position.y-35f), Quaternion.identity);
			jugador7 = Instantiate (usa, new Vector2(transform.position.x-10f,transform.position.y-35f), Quaternion.identity);
			jugador8 = Instantiate (usa, new Vector2(transform.position.x+10f,transform.position.y-35f), Quaternion.identity);
			jugador9 = Instantiate (usa, new Vector2(transform.position.x+20f,transform.position.y-35f), Quaternion.identity);
		}
		if (MngScenes.pais == "argentina") {
			jugador0 = Instantiate (argentina, new Vector2(transform.position.x+3f,transform.position.y-3f), Quaternion.identity);
			jugador1 = Instantiate (argentina, new Vector2(transform.position.x-3f,transform.position.y-3f), Quaternion.identity);
			jugador2 = Instantiate (argentina, new Vector2(transform.position.x-20f,transform.position.y-15f), Quaternion.identity);
			jugador3 = Instantiate (argentina, new Vector2(transform.position.x-10f,transform.position.y-15f), Quaternion.identity);
			jugador4 = Instantiate (argentina, new Vector2(transform.position.x+10f,transform.position.y-15f), Quaternion.identity);
			jugador5 = Instantiate (argentina, new Vector2(transform.position.x+20f,transform.position.y-15f), Quaternion.identity);
			jugador6 = Instantiate (argentina, new Vector2(transform.position.x-20f,transform.position.y-35f), Quaternion.identity);
			jugador7 = Instantiate (argentina, new Vector2(transform.position.x-10f,transform.position.y-35f), Quaternion.identity);
			jugador8 = Instantiate (argentina, new Vector2(transform.position.x+10f,transform.position.y-35f), Quaternion.identity);
			jugador9 = Instantiate (argentina, new Vector2(transform.position.x+20f,transform.position.y-35f), Quaternion.identity);
		}
		if (MngScenes.pais == "alemania") {
			jugador0 = Instantiate (alemania, new Vector2(transform.position.x+3f,transform.position.y-3f), Quaternion.identity);
			jugador1 = Instantiate (alemania, new Vector2(transform.position.x-3f,transform.position.y-3f), Quaternion.identity);
			jugador2 = Instantiate (alemania, new Vector2(transform.position.x-20f,transform.position.y-15f), Quaternion.identity);
			jugador3 = Instantiate (alemania, new Vector2(transform.position.x-10f,transform.position.y-15f), Quaternion.identity);
			jugador4 = Instantiate (alemania, new Vector2(transform.position.x+10f,transform.position.y-15f), Quaternion.identity);
			jugador5 = Instantiate (alemania, new Vector2(transform.position.x+20f,transform.position.y-15f), Quaternion.identity);
			jugador6 = Instantiate (alemania, new Vector2(transform.position.x-20f,transform.position.y-35f), Quaternion.identity);
			jugador7 = Instantiate (alemania, new Vector2(transform.position.x-10f,transform.position.y-35f), Quaternion.identity);
			jugador8 = Instantiate (alemania, new Vector2(transform.position.x+10f,transform.position.y-35f), Quaternion.identity);
			jugador9 = Instantiate (alemania, new Vector2(transform.position.x+20f,transform.position.y-35f), Quaternion.identity);
		}
		if (MngScenes.pais == "japon") {
			jugador0 = Instantiate (japon, new Vector2(transform.position.x+3f,transform.position.y-3f), Quaternion.identity);
			jugador1 = Instantiate (japon, new Vector2(transform.position.x-3f,transform.position.y-3f), Quaternion.identity);
			jugador2 = Instantiate (japon, new Vector2(transform.position.x-20f,transform.position.y-15f), Quaternion.identity);
			jugador3 = Instantiate (japon, new Vector2(transform.position.x-10f,transform.position.y-15f), Quaternion.identity);
			jugador4 = Instantiate (japon, new Vector2(transform.position.x+10f,transform.position.y-15f), Quaternion.identity);
			jugador5 = Instantiate (japon, new Vector2(transform.position.x+20f,transform.position.y-15f), Quaternion.identity);
			jugador6 = Instantiate (japon, new Vector2(transform.position.x-20f,transform.position.y-35f), Quaternion.identity);
			jugador7 = Instantiate (japon, new Vector2(transform.position.x-10f,transform.position.y-35f), Quaternion.identity);
			jugador8 = Instantiate (japon, new Vector2(transform.position.x+10f,transform.position.y-35f), Quaternion.identity);
			jugador9 = Instantiate (japon, new Vector2(transform.position.x+20f,transform.position.y-35f), Quaternion.identity);
		}
		if (MngScenes.pais == "rusia") {
			jugador0 = Instantiate (rusia, new Vector2(transform.position.x+3f,transform.position.y-3f), Quaternion.identity);
			jugador1 = Instantiate (rusia, new Vector2(transform.position.x-3f,transform.position.y-3f), Quaternion.identity);
			jugador2 = Instantiate (rusia, new Vector2(transform.position.x-20f,transform.position.y-15f), Quaternion.identity);
			jugador3 = Instantiate (rusia, new Vector2(transform.position.x-10f,transform.position.y-15f), Quaternion.identity);
			jugador4 = Instantiate (rusia, new Vector2(transform.position.x+10f,transform.position.y-15f), Quaternion.identity);
			jugador5 = Instantiate (rusia, new Vector2(transform.position.x+20f,transform.position.y-15f), Quaternion.identity);
			jugador6 = Instantiate (rusia, new Vector2(transform.position.x-20f,transform.position.y-35f), Quaternion.identity);
			jugador7 = Instantiate (rusia, new Vector2(transform.position.x-10f,transform.position.y-35f), Quaternion.identity);
			jugador8 = Instantiate (rusia, new Vector2(transform.position.x+10f,transform.position.y-35f), Quaternion.identity);
			jugador9 = Instantiate (rusia, new Vector2(transform.position.x+20f,transform.position.y-35f), Quaternion.identity);
		}		
		if (MngScenes.pais == "china") {
			jugador0 = Instantiate (china, new Vector2(transform.position.x+3f,transform.position.y-3f), Quaternion.identity);
			jugador1 = Instantiate (china, new Vector2(transform.position.x-3f,transform.position.y-3f), Quaternion.identity);
			jugador2 = Instantiate (china, new Vector2(transform.position.x-20f,transform.position.y-15f), Quaternion.identity);
			jugador3 = Instantiate (china, new Vector2(transform.position.x-10f,transform.position.y-15f), Quaternion.identity);
			jugador4 = Instantiate (china, new Vector2(transform.position.x+10f,transform.position.y-15f), Quaternion.identity);
			jugador5 = Instantiate (china, new Vector2(transform.position.x+20f,transform.position.y-15f), Quaternion.identity);
			jugador6 = Instantiate (china, new Vector2(transform.position.x-20f,transform.position.y-35f), Quaternion.identity);
			jugador7 = Instantiate (china, new Vector2(transform.position.x-10f,transform.position.y-35f), Quaternion.identity);
			jugador8 = Instantiate (china, new Vector2(transform.position.x+10f,transform.position.y-35f), Quaternion.identity);
			jugador9 = Instantiate (china, new Vector2(transform.position.x+20f,transform.position.y-35f), Quaternion.identity);
		}


		jugador0.GetComponent<Jugador> ().selector = true;
		jugador0.GetComponent<Jugador> ().balon = balon.GetComponent<Balon> ();
		jugador1.GetComponent<Jugador> ().balon = balon.GetComponent<Balon> ();
		jugador2.GetComponent<Jugador> ().balon = balon.GetComponent<Balon> ();
		jugador3.GetComponent<Jugador> ().balon = balon.GetComponent<Balon> ();
		jugador4.GetComponent<Jugador> ().balon = balon.GetComponent<Balon> ();
		jugador5.GetComponent<Jugador> ().balon = balon.GetComponent<Balon> ();
		jugador6.GetComponent<Jugador> ().balon = balon.GetComponent<Balon> ();
		jugador7.GetComponent<Jugador> ().balon = balon.GetComponent<Balon> ();
		jugador8.GetComponent<Jugador> ().balon = balon.GetComponent<Balon> ();
		jugador9.GetComponent<Jugador> ().balon = balon.GetComponent<Balon> ();
		jugador0.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador1.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador2.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador3.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador4.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador5.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador6.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador7.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador8.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador9.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador0.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador1.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador2.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador3.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador4.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador5.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador6.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador7.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador8.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador9.GetComponent<Jugador> ().seguidor = guia.GetComponent<Selector> ();
		jugador0.GetComponent<Jugador> ().equipoRival = equiRiv.GetComponent<MngRival> ();
		jugador1.GetComponent<Jugador> ().equipoRival = equiRiv.GetComponent<MngRival> ();
		jugador2.GetComponent<Jugador> ().equipoRival = equiRiv.GetComponent<MngRival> ();
		jugador3.GetComponent<Jugador> ().equipoRival = equiRiv.GetComponent<MngRival> ();
		jugador4.GetComponent<Jugador> ().equipoRival = equiRiv.GetComponent<MngRival> ();
		jugador5.GetComponent<Jugador> ().equipoRival = equiRiv.GetComponent<MngRival> ();
		jugador6.GetComponent<Jugador> ().equipoRival = equiRiv.GetComponent<MngRival> ();
		jugador7.GetComponent<Jugador> ().equipoRival = equiRiv.GetComponent<MngRival> ();
		jugador8.GetComponent<Jugador> ().equipoRival = equiRiv.GetComponent<MngRival> ();
		jugador9.GetComponent<Jugador> ().equipoRival = equiRiv.GetComponent<MngRival> ();

		mngJugadores.GetComponent<ManagerPersonajes> ().balon = balon.GetComponent<Balon> ();
		mngJugadores.GetComponent<ManagerPersonajes> ().jugadores [0] = jugador0.GetComponent<Jugador> ();
		mngJugadores.GetComponent<ManagerPersonajes> ().jugadores [1] = jugador1.GetComponent<Jugador> ();
		mngJugadores.GetComponent<ManagerPersonajes> ().jugadores [2] = jugador2.GetComponent<Jugador> ();
		mngJugadores.GetComponent<ManagerPersonajes> ().jugadores [3] = jugador3.GetComponent<Jugador> ();
		mngJugadores.GetComponent<ManagerPersonajes> ().jugadores [4] = jugador4.GetComponent<Jugador> ();
		mngJugadores.GetComponent<ManagerPersonajes> ().jugadores [5] = jugador5.GetComponent<Jugador> ();
		mngJugadores.GetComponent<ManagerPersonajes> ().jugadores [6] = jugador6.GetComponent<Jugador> ();
		mngJugadores.GetComponent<ManagerPersonajes> ().jugadores [7] = jugador7.GetComponent<Jugador> ();
		mngJugadores.GetComponent<ManagerPersonajes> ().jugadores [8] = jugador8.GetComponent<Jugador> ();
		mngJugadores.GetComponent<ManagerPersonajes> ().jugadores [9] = jugador9.GetComponent<Jugador> ();
		mngJugadores.GetComponent<ManagerPersonajes> ().benji = portero.GetComponent<PorteroV2> ();

		equiRiv.GetComponent<MngRival> ().Rival [0] = rival0.GetComponent < Rival> ();
		equiRiv.GetComponent<MngRival> ().Rival [1] = rival1.GetComponent < Rival> ();
		equiRiv.GetComponent<MngRival> ().Rival [2] = rival2.GetComponent < Rival> ();
		equiRiv.GetComponent<MngRival> ().Rival [3] = rival3.GetComponent < Rival> ();
		equiRiv.GetComponent<MngRival> ().Rival [4] = rival4.GetComponent < Rival> ();
		equiRiv.GetComponent<MngRival> ().Rival [5] = rival5.GetComponent < Rival> ();
		equiRiv.GetComponent<MngRival> ().Rival [6] = rival6.GetComponent < Rival> ();
		equiRiv.GetComponent<MngRival> ().Rival [7] = rival7.GetComponent < Rival> ();
		equiRiv.GetComponent<MngRival> ().Rival [8] = rival8.GetComponent < Rival> ();
		equiRiv.GetComponent<MngRival> ().Rival [9] = rival9.GetComponent < Rival> ();
		equiRiv.GetComponent<MngRival> ().benji = porteroR.GetComponent <PorteroV2Rival> ();

		rival0.GetComponent<Rival> ().ball = balon.GetComponent<Balon> ();
		rival1.GetComponent<Rival> ().ball = balon.GetComponent<Balon> ();
		rival2.GetComponent<Rival> ().ball = balon.GetComponent<Balon> ();
		rival3.GetComponent<Rival> ().ball = balon.GetComponent<Balon> ();
		rival4.GetComponent<Rival> ().ball = balon.GetComponent<Balon> ();
		rival5.GetComponent<Rival> ().ball = balon.GetComponent<Balon> ();
		rival6.GetComponent<Rival> ().ball = balon.GetComponent<Balon> ();
		rival7.GetComponent<Rival> ().ball = balon.GetComponent<Balon> ();
		rival8.GetComponent<Rival> ().ball = balon.GetComponent<Balon> ();
		rival9.GetComponent<Rival> ().ball = balon.GetComponent<Balon> ();

		rival0.GetComponent<Rival> ().eqContra = mngJugadores.GetComponent<ManagerPersonajes> ();
		rival1.GetComponent<Rival> ().eqContra = mngJugadores.GetComponent<ManagerPersonajes> ();
		rival2.GetComponent<Rival> ().eqContra = mngJugadores.GetComponent<ManagerPersonajes> ();
		rival3.GetComponent<Rival> ().eqContra = mngJugadores.GetComponent<ManagerPersonajes> ();
		rival4.GetComponent<Rival> ().eqContra = mngJugadores.GetComponent<ManagerPersonajes> ();
		rival5.GetComponent<Rival> ().eqContra = mngJugadores.GetComponent<ManagerPersonajes> ();
		rival6.GetComponent<Rival> ().eqContra = mngJugadores.GetComponent<ManagerPersonajes> ();
		rival7.GetComponent<Rival> ().eqContra = mngJugadores.GetComponent<ManagerPersonajes> ();
		rival8.GetComponent<Rival> ().eqContra = mngJugadores.GetComponent<ManagerPersonajes> ();
		rival9.GetComponent<Rival> ().eqContra = mngJugadores.GetComponent<ManagerPersonajes> ();

		rival0.GetComponent<Rival> ().porteriaRival = GameObject.Find ("porteria"); 
		rival1.GetComponent<Rival> ().porteriaRival = GameObject.Find ("porteria"); 
		rival2.GetComponent<Rival> ().porteriaRival = GameObject.Find ("porteria"); 
		rival3.GetComponent<Rival> ().porteriaRival = GameObject.Find ("porteria"); 
		rival4.GetComponent<Rival> ().porteriaRival = GameObject.Find ("porteria"); 
		rival5.GetComponent<Rival> ().porteriaRival = GameObject.Find ("porteria"); 
		rival6.GetComponent<Rival> ().porteriaRival = GameObject.Find ("porteria"); 
		rival7.GetComponent<Rival> ().porteriaRival = GameObject.Find ("porteria"); 
		rival8.GetComponent<Rival> ().porteriaRival = GameObject.Find ("porteria"); 
		rival9.GetComponent<Rival> ().porteriaRival = GameObject.Find ("porteria"); 

		portero.GetComponent<PorteroV2>().balon = balon.GetComponent<Balon> ();
		portero.GetComponent<PorteroV2> ().posicion = GameObject.Find ("porteria");
		porteroR.GetComponent<PorteroV2Rival>().balon = balon.GetComponent<Balon> ();
		porteroR.GetComponent<PorteroV2Rival>().posicion = GameObject.Find ("porteria2");

		if (MngScenes.alineacion == "A") {
			GameObject PosicionesDeLosCojones = Instantiate (AliA, transform.position, Quaternion.identity);
		}
		if (MngScenes.alineacion == "B") {
			GameObject PosicionesDeLosCojones = Instantiate (AliB, transform.position, Quaternion.identity);
		}
        GameObject PosicionRival = Instantiate(AlRiv, transform.position, Quaternion.identity);


    }

    // Update is called once per frame
    void Update () {
		
	}
}
