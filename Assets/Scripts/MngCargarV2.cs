using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngCargarV2 : MonoBehaviour {

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
	public GameObject guia2;
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
		jugador0.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion");
		jugador1.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion2");
		jugador2.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion3");
		jugador3.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion4");
		jugador4.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion5");
		jugador5.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion6");
		jugador6.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion7");
		jugador7.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion8");
		jugador8.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion9");
		jugador9.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion10");

		rival0.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicionR");
		rival1.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion2R");
		rival2.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion3R");
		rival3.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion4R");
		rival4.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion5R");
		rival5.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion6R");
		rival6.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion7R");
		rival7.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion8R");
		rival8.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion9R");
		rival9.GetComponent<JugadorV2> ().posicion = GameObject.Find ("posicion10R");

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

	//	if (MngScenes.pais == "spain") {
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
	//	}
		


		jugador0.GetComponent<JugadorV2> ().selector = true;
		jugador0.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		jugador1.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		jugador2.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		jugador3.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		jugador4.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		jugador5.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		jugador6.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		jugador7.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		jugador8.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		jugador9.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		jugador0.GetComponent<JugadorV2> ().seguidor = guia.GetComponent<Selector> ();
		jugador1.GetComponent<JugadorV2> ().seguidor = guia.GetComponent<Selector> ();
		jugador2.GetComponent<JugadorV2> ().seguidor = guia.GetComponent<Selector> ();
		jugador3.GetComponent<JugadorV2> ().seguidor = guia.GetComponent<Selector> ();
		jugador4.GetComponent<JugadorV2> ().seguidor = guia.GetComponent<Selector> ();
		jugador5.GetComponent<JugadorV2> ().seguidor = guia.GetComponent<Selector> ();
		jugador6.GetComponent<JugadorV2> ().seguidor = guia.GetComponent<Selector> ();
		jugador7.GetComponent<JugadorV2> ().seguidor = guia.GetComponent<Selector> ();
		jugador8.GetComponent<JugadorV2> ().seguidor = guia.GetComponent<Selector> ();
		jugador9.GetComponent<JugadorV2> ().seguidor = guia.GetComponent<Selector> ();
		jugador0.GetComponent<JugadorV2> ().equipoRival = equiRiv.GetComponent<MngEquiV2> ();
		jugador1.GetComponent<JugadorV2> ().equipoRival = equiRiv.GetComponent<MngEquiV2> ();
		jugador2.GetComponent<JugadorV2> ().equipoRival = equiRiv.GetComponent<MngEquiV2> ();
		jugador3.GetComponent<JugadorV2> ().equipoRival = equiRiv.GetComponent<MngEquiV2> ();
		jugador4.GetComponent<JugadorV2> ().equipoRival = equiRiv.GetComponent<MngEquiV2> ();
		jugador5.GetComponent<JugadorV2> ().equipoRival = equiRiv.GetComponent<MngEquiV2> ();
		jugador6.GetComponent<JugadorV2> ().equipoRival = equiRiv.GetComponent<MngEquiV2> ();
		jugador7.GetComponent<JugadorV2> ().equipoRival = equiRiv.GetComponent<MngEquiV2> ();
		jugador8.GetComponent<JugadorV2> ().equipoRival = equiRiv.GetComponent<MngEquiV2> ();
		jugador9.GetComponent<JugadorV2> ().equipoRival = equiRiv.GetComponent<MngEquiV2> ();

		mngJugadores.GetComponent<MngEquiV2> ().balon = balon.GetComponent<Balon> ();
		mngJugadores.GetComponent<MngEquiV2> ().jugadores [0] = jugador0.GetComponent<JugadorV2> ();
		mngJugadores.GetComponent<MngEquiV2> ().jugadores [1] = jugador1.GetComponent<JugadorV2> ();
		mngJugadores.GetComponent<MngEquiV2> ().jugadores [2] = jugador2.GetComponent<JugadorV2> ();
		mngJugadores.GetComponent<MngEquiV2> ().jugadores [3] = jugador3.GetComponent<JugadorV2> ();
		mngJugadores.GetComponent<MngEquiV2> ().jugadores [4] = jugador4.GetComponent<JugadorV2> ();
		mngJugadores.GetComponent<MngEquiV2> ().jugadores [5] = jugador5.GetComponent<JugadorV2> ();
		mngJugadores.GetComponent<MngEquiV2> ().jugadores [6] = jugador6.GetComponent<JugadorV2> ();
		mngJugadores.GetComponent<MngEquiV2> ().jugadores [7] = jugador7.GetComponent<JugadorV2> ();
		mngJugadores.GetComponent<MngEquiV2> ().jugadores [8] = jugador8.GetComponent<JugadorV2> ();
		mngJugadores.GetComponent<MngEquiV2> ().jugadores [9] = jugador9.GetComponent<JugadorV2> ();
		mngJugadores.GetComponent<MngEquiV2> ().benji = portero.GetComponent<PorteroV2> ();

		equiRiv.GetComponent<MngEquiV2> ().jugadores[0] = rival0.GetComponent <JugadorV2> ();
		equiRiv.GetComponent<MngEquiV2> ().jugadores[1] = rival1.GetComponent <JugadorV2> ();
		equiRiv.GetComponent<MngEquiV2> ().jugadores[2] = rival2.GetComponent <JugadorV2> ();
		equiRiv.GetComponent<MngEquiV2> ().jugadores[3] = rival3.GetComponent <JugadorV2> ();
		equiRiv.GetComponent<MngEquiV2> ().jugadores[4] = rival4.GetComponent <JugadorV2> ();
		equiRiv.GetComponent<MngEquiV2> ().jugadores[5] = rival5.GetComponent <JugadorV2> ();
		equiRiv.GetComponent<MngEquiV2> ().jugadores[6] = rival6.GetComponent <JugadorV2> ();
		equiRiv.GetComponent<MngEquiV2> ().jugadores[7] = rival7.GetComponent <JugadorV2> ();
		equiRiv.GetComponent<MngEquiV2> ().jugadores[8] = rival8.GetComponent <JugadorV2> ();
		equiRiv.GetComponent<MngEquiV2> ().jugadores[9] = rival9.GetComponent <JugadorV2> ();
		equiRiv.GetComponent<MngEquiV2> ().benji = porteroR.GetComponent <PorteroV2> ();

		rival0.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		rival1.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		rival2.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		rival3.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		rival4.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		rival5.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		rival6.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		rival7.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		rival8.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();
		rival9.GetComponent<JugadorV2> ().balon = balon.GetComponent<Balon> ();

		rival0.GetComponent<JugadorV2> ().equipoRival = mngJugadores.GetComponent<MngEquiV2> ();
		rival1.GetComponent<JugadorV2> ().equipoRival = mngJugadores.GetComponent<MngEquiV2> ();
		rival2.GetComponent<JugadorV2> ().equipoRival = mngJugadores.GetComponent<MngEquiV2> ();
		rival3.GetComponent<JugadorV2> ().equipoRival = mngJugadores.GetComponent<MngEquiV2> ();
		rival4.GetComponent<JugadorV2> ().equipoRival = mngJugadores.GetComponent<MngEquiV2> ();
		rival5.GetComponent<JugadorV2> ().equipoRival = mngJugadores.GetComponent<MngEquiV2> ();
		rival6.GetComponent<JugadorV2> ().equipoRival = mngJugadores.GetComponent<MngEquiV2> ();
		rival7.GetComponent<JugadorV2> ().equipoRival = mngJugadores.GetComponent<MngEquiV2> ();
		rival8.GetComponent<JugadorV2> ().equipoRival = mngJugadores.GetComponent<MngEquiV2> ();
		rival9.GetComponent<JugadorV2> ().equipoRival = mngJugadores.GetComponent<MngEquiV2> ();

		rival0.GetComponent<JugadorV2> ().porteriaRival = GameObject.Find ("porteria"); 
		rival1.GetComponent<JugadorV2> ().porteriaRival = GameObject.Find ("porteria"); 
		rival2.GetComponent<JugadorV2> ().porteriaRival = GameObject.Find ("porteria"); 
		rival3.GetComponent<JugadorV2> ().porteriaRival = GameObject.Find ("porteria"); 
		rival4.GetComponent<JugadorV2> ().porteriaRival = GameObject.Find ("porteria"); 
		rival5.GetComponent<JugadorV2> ().porteriaRival = GameObject.Find ("porteria"); 
		rival6.GetComponent<JugadorV2> ().porteriaRival = GameObject.Find ("porteria"); 
		rival7.GetComponent<JugadorV2> ().porteriaRival = GameObject.Find ("porteria"); 
		rival8.GetComponent<JugadorV2> ().porteriaRival = GameObject.Find ("porteria"); 
		rival9.GetComponent<JugadorV2> ().porteriaRival = GameObject.Find ("porteria");

        rival0.GetComponent<JugadorV2>().equipo = false;
        rival1.GetComponent<JugadorV2>().equipo = false;
        rival2.GetComponent<JugadorV2>().equipo = false;
        rival3.GetComponent<JugadorV2>().equipo = false;
        rival4.GetComponent<JugadorV2>().equipo = false;
        rival5.GetComponent<JugadorV2>().equipo = false;
        rival6.GetComponent<JugadorV2>().equipo = false;
        rival7.GetComponent<JugadorV2>().equipo = false;
        rival8.GetComponent<JugadorV2>().equipo = false;
        rival9.GetComponent<JugadorV2>().equipo = false;

        jugador0.GetComponent<JugadorV2>().equipo = true;
        jugador1.GetComponent<JugadorV2>().equipo = true;
        jugador2.GetComponent<JugadorV2>().equipo = true;
        jugador3.GetComponent<JugadorV2>().equipo = true;
        jugador4.GetComponent<JugadorV2>().equipo = true;
        jugador5.GetComponent<JugadorV2>().equipo = true;
        jugador6.GetComponent<JugadorV2>().equipo = true;
        jugador7.GetComponent<JugadorV2>().equipo = true;
        jugador8.GetComponent<JugadorV2>().equipo = true;
        jugador9.GetComponent<JugadorV2>().equipo = true;


		rival1.GetComponent<Jugador> ().seguidor = guia2.GetComponent<Selector> ();
		rival2.GetComponent<Jugador> ().seguidor = guia2.GetComponent<Selector> ();
		rival3.GetComponent<Jugador> ().seguidor = guia2.GetComponent<Selector> ();
		rival4.GetComponent<Jugador> ().seguidor = guia2.GetComponent<Selector> ();
		rival5.GetComponent<Jugador> ().seguidor = guia2.GetComponent<Selector> ();
		rival6.GetComponent<Jugador> ().seguidor = guia2.GetComponent<Selector> ();
		rival7.GetComponent<Jugador> ().seguidor = guia2.GetComponent<Selector> ();
		rival8.GetComponent<Jugador> ().seguidor = guia2.GetComponent<Selector> ();
		rival9.GetComponent<Jugador> ().seguidor = guia2.GetComponent<Selector> ();
		rival0.GetComponent<Jugador> ().seguidor = guia2.GetComponent<Selector> ();

        portero.GetComponent<PorteroV2>().balon = balon.GetComponent<Balon> ();
		portero.GetComponent<PorteroV2> ().posicion = GameObject.Find ("porteria");
		porteroR.GetComponent<PorteroV2>().balon = balon.GetComponent<Balon> ();
		porteroR.GetComponent<PorteroV2>().posicion = GameObject.Find ("porteria2");

		GameObject PosicionesDeLosCojones = Instantiate (AliB, transform.position, Quaternion.identity);
		
        GameObject PosicionRival = Instantiate(AlRiv, transform.position, Quaternion.identity);


    }

}
