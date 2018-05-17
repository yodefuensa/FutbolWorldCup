using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngCargarV3 : MonoBehaviour {

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
		jugador0.GetComponent<State> ().posicion = GameObject.Find ("posicion");
		jugador1.GetComponent<State> ().posicion = GameObject.Find ("posicion2");
		jugador2.GetComponent<State> ().posicion = GameObject.Find ("posicion3");
		jugador3.GetComponent<State> ().posicion = GameObject.Find ("posicion4");
		jugador4.GetComponent<State> ().posicion = GameObject.Find ("posicion5");
		jugador5.GetComponent<State> ().posicion = GameObject.Find ("posicion6");
		jugador6.GetComponent<State> ().posicion = GameObject.Find ("posicion7");
		jugador7.GetComponent<State> ().posicion = GameObject.Find ("posicion8");
		jugador8.GetComponent<State> ().posicion = GameObject.Find ("posicion9");
		jugador9.GetComponent<State> ().posicion = GameObject.Find ("posicion10");

		rival0.GetComponent<State> ().posicion = GameObject.Find ("posicionR");
		rival1.GetComponent<State> ().posicion = GameObject.Find ("posicion2R");
		rival2.GetComponent<State> ().posicion = GameObject.Find ("posicion3R");
		rival3.GetComponent<State> ().posicion = GameObject.Find ("posicion4R");
		rival4.GetComponent<State> ().posicion = GameObject.Find ("posicion5R");
		rival5.GetComponent<State> ().posicion = GameObject.Find ("posicion6R");
		rival6.GetComponent<State> ().posicion = GameObject.Find ("posicion7R");
		rival7.GetComponent<State> ().posicion = GameObject.Find ("posicion8R");
		rival8.GetComponent<State> ().posicion = GameObject.Find ("posicion9R");
		rival9.GetComponent<State> ().posicion = GameObject.Find ("posicion10R");

        /*      
		rival9.GetComponent<State>().vel = 0;
        rival8.GetComponent<State>().vel = 0;
        rival7.GetComponent<State>().vel = 0;
        rival6.GetComponent<State>().vel = 0;
        rival5.GetComponent<State>().vel = 0;
        rival4.GetComponent<State>().vel = 0;
        rival3.GetComponent<State>().vel = 0;
        rival2.GetComponent<State>().vel = 0;
        rival1.GetComponent<State>().vel = 0;
        rival0.GetComponent<State>().vel = 0;*/
   
        
        
    }

    private void Awake()
    {//antes de cargar la escena

        MngScenes.multijugador = true;
        if (MngScenes.alineacion == "A") {
			GameObject PosicionesDeLosCojones = Instantiate (AliA, transform.position, Quaternion.identity);
		}
		if (MngScenes.alineacion == "B") {
			GameObject PosicionesDeLosCojones = Instantiate (AliB, transform.position, Quaternion.identity);
		}
        GameObject PosicionRival = Instantiate(AlRiv, transform.position, Quaternion.identity);



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

		


		jugador0.GetComponent<SCorrer> ().selector = true;
		jugador0.GetComponent<SCorrer> ().seguidor = guia.GetComponent<Selector> ();
		jugador1.GetComponent<SCorrer> ().seguidor = guia.GetComponent<Selector> ();
		jugador2.GetComponent<SCorrer> ().seguidor = guia.GetComponent<Selector> ();
		jugador3.GetComponent<SCorrer> ().seguidor = guia.GetComponent<Selector> ();
		jugador4.GetComponent<SCorrer> ().seguidor = guia.GetComponent<Selector> ();
		jugador5.GetComponent<SCorrer> ().seguidor = guia.GetComponent<Selector> ();
		jugador6.GetComponent<SCorrer> ().seguidor = guia.GetComponent<Selector> ();
		jugador7.GetComponent<SCorrer> ().seguidor = guia.GetComponent<Selector> ();
		jugador8.GetComponent<SCorrer> ().seguidor = guia.GetComponent<Selector> ();
		jugador9.GetComponent<SCorrer> ().seguidor = guia.GetComponent<Selector> ();

		mngJugadores.GetComponent<MngEquiV3> ().balon = balon.GetComponent<Balon> ();
		mngJugadores.GetComponent<MngEquiV3> ().jugadores [0] = jugador0.GetComponent<State> ();
		mngJugadores.GetComponent<MngEquiV3> ().jugadores [1] = jugador1.GetComponent<State> ();
		mngJugadores.GetComponent<MngEquiV3> ().jugadores [2] = jugador2.GetComponent<State> ();
		mngJugadores.GetComponent<MngEquiV3> ().jugadores [3] = jugador3.GetComponent<State> ();
		mngJugadores.GetComponent<MngEquiV3> ().jugadores [4] = jugador4.GetComponent<State> ();
		mngJugadores.GetComponent<MngEquiV3> ().jugadores [5] = jugador5.GetComponent<State> ();
		mngJugadores.GetComponent<MngEquiV3> ().jugadores [6] = jugador6.GetComponent<State> ();
		mngJugadores.GetComponent<MngEquiV3> ().jugadores [7] = jugador7.GetComponent<State> ();
		mngJugadores.GetComponent<MngEquiV3> ().jugadores [8] = jugador8.GetComponent<State> ();
		mngJugadores.GetComponent<MngEquiV3> ().jugadores [9] = jugador9.GetComponent<State> ();
		mngJugadores.GetComponent<MngEquiV3> ().benji = portero.GetComponent<PorteroV2> ();

		equiRiv.GetComponent<MngEquiV3> ().jugadores[0] = rival0.GetComponent <State> ();
		equiRiv.GetComponent<MngEquiV3> ().jugadores[1] = rival1.GetComponent <State> ();
		equiRiv.GetComponent<MngEquiV3> ().jugadores[2] = rival2.GetComponent <State> ();
		equiRiv.GetComponent<MngEquiV3> ().jugadores[3] = rival3.GetComponent <State> ();
		equiRiv.GetComponent<MngEquiV3> ().jugadores[4] = rival4.GetComponent <State> ();
		equiRiv.GetComponent<MngEquiV3> ().jugadores[5] = rival5.GetComponent <State> ();
		equiRiv.GetComponent<MngEquiV3> ().jugadores[6] = rival6.GetComponent <State> ();
		equiRiv.GetComponent<MngEquiV3> ().jugadores[7] = rival7.GetComponent <State> ();
		equiRiv.GetComponent<MngEquiV3> ().jugadores[8] = rival8.GetComponent <State> ();
		equiRiv.GetComponent<MngEquiV3> ().jugadores[9] = rival9.GetComponent <State> ();
		equiRiv.GetComponent<MngEquiV3> ().benji = porteroR.GetComponent <PorteroV2> ();
        equiRiv.GetComponent<MngEquiV3>().balon = balon.GetComponent<Balon>();

        rival0.GetComponent<State>().equipo = false;
        rival1.GetComponent<State>().equipo = false;
        rival2.GetComponent<State>().equipo = false;
        rival3.GetComponent<State>().equipo = false;
        rival4.GetComponent<State>().equipo = false;
        rival5.GetComponent<State>().equipo = false;
        rival6.GetComponent<State>().equipo = false;
        rival7.GetComponent<State>().equipo = false;
        rival8.GetComponent<State>().equipo = false;
        rival9.GetComponent<State>().equipo = false;

        jugador0.GetComponent<State>().equipo = true;
        jugador1.GetComponent<State>().equipo = true;
        jugador2.GetComponent<State>().equipo = true;
        jugador3.GetComponent<State>().equipo = true;
        jugador4.GetComponent<State>().equipo = true;
        jugador5.GetComponent<State>().equipo = true;
        jugador6.GetComponent<State>().equipo = true;
        jugador7.GetComponent<State>().equipo = true;
        jugador8.GetComponent<State>().equipo = true;
        jugador9.GetComponent<State>().equipo = true;

		rival1.GetComponent<SCorrer> ().seguidor = guia2.GetComponent<Selector> ();
        rival2.GetComponent<SCorrer> ().seguidor = guia2.GetComponent<Selector> ();
		rival3.GetComponent<SCorrer> ().seguidor = guia2.GetComponent<Selector> ();
		rival4.GetComponent<SCorrer> ().seguidor = guia2.GetComponent<Selector> ();
		rival5.GetComponent<SCorrer> ().seguidor = guia2.GetComponent<Selector> ();
		rival6.GetComponent<SCorrer> ().seguidor = guia2.GetComponent<Selector> ();
		rival7.GetComponent<SCorrer> ().seguidor = guia2.GetComponent<Selector> ();
		rival8.GetComponent<SCorrer> ().seguidor = guia2.GetComponent<Selector> ();
		rival9.GetComponent<SCorrer> ().seguidor = guia2.GetComponent<Selector> ();
		rival0.GetComponent<SCorrer> ().seguidor = guia2.GetComponent<Selector> ();

		jugador0.GetComponent<SParado>().enabled = false;
		jugador1.GetComponent<SParado>().enabled = false;
		jugador2.GetComponent<SParado>().enabled = false;
		jugador3.GetComponent<SParado>().enabled = false;
		jugador4.GetComponent<SParado>().enabled = false;
		jugador5.GetComponent<SParado>().enabled = false;
		jugador6.GetComponent<SParado>().enabled = false;
		jugador7.GetComponent<SParado>().enabled = false;
		jugador8.GetComponent<SParado>().enabled = false;
		jugador9.GetComponent<SParado>().enabled = false;

		jugador0.GetComponent<SFalta>().enabled = false;
		jugador1.GetComponent<SFalta>().enabled = false;
		jugador2.GetComponent<SFalta>().enabled = false;
		jugador3.GetComponent<SFalta>().enabled = false;
		jugador4.GetComponent<SFalta>().enabled = false;
		jugador5.GetComponent<SFalta>().enabled = false;
		jugador6.GetComponent<SFalta>().enabled = false;
		jugador7.GetComponent<SFalta>().enabled = false;
		jugador8.GetComponent<SFalta>().enabled = false;
		jugador9.GetComponent<SFalta>().enabled = false;

		jugador0.GetComponent<SSuelo>().enabled = false;
		jugador1.GetComponent<SSuelo>().enabled = false;
		jugador2.GetComponent<SSuelo>().enabled = false;
		jugador3.GetComponent<SSuelo>().enabled = false;
		jugador4.GetComponent<SSuelo>().enabled = false;
		jugador5.GetComponent<SSuelo>().enabled = false;
		jugador6.GetComponent<SSuelo>().enabled = false;
		jugador7.GetComponent<SSuelo>().enabled = false;
		jugador8.GetComponent<SSuelo>().enabled = false;
		jugador9.GetComponent<SSuelo>().enabled = false;
		
		jugador0.GetComponent<SBalonPies>().enabled = false;
		jugador1.GetComponent<SBalonPies>().enabled = false;
		jugador2.GetComponent<SBalonPies>().enabled = false;
		jugador3.GetComponent<SBalonPies>().enabled = false;
		jugador4.GetComponent<SBalonPies>().enabled = false;
		jugador5.GetComponent<SBalonPies>().enabled = false;
		jugador6.GetComponent<SBalonPies>().enabled = false;
		jugador7.GetComponent<SBalonPies>().enabled = false;
		jugador8.GetComponent<SBalonPies>().enabled = false;
		jugador9.GetComponent<SBalonPies>().enabled = false;

		rival0.GetComponent<SParado>().enabled = false;
		rival1.GetComponent<SParado>().enabled = false;
		rival2.GetComponent<SParado>().enabled = false;
		rival3.GetComponent<SParado>().enabled = false;
		rival4.GetComponent<SParado>().enabled = false;
		rival5.GetComponent<SParado>().enabled = false;
		rival6.GetComponent<SParado>().enabled = false;
		rival7.GetComponent<SParado>().enabled = false;
		rival8.GetComponent<SParado>().enabled = false;
		rival9.GetComponent<SParado>().enabled = false;

		rival0.GetComponent<SFalta>().enabled = false;
		rival1.GetComponent<SFalta>().enabled = false;
		rival2.GetComponent<SFalta>().enabled = false;
		rival3.GetComponent<SFalta>().enabled = false;
		rival4.GetComponent<SFalta>().enabled = false;
		rival5.GetComponent<SFalta>().enabled = false;
		rival6.GetComponent<SFalta>().enabled = false;
		rival7.GetComponent<SFalta>().enabled = false;
		rival8.GetComponent<SFalta>().enabled = false;
		rival9.GetComponent<SFalta>().enabled = false;

		rival0.GetComponent<SSuelo>().enabled = false;
		rival1.GetComponent<SSuelo>().enabled = false;
		rival2.GetComponent<SSuelo>().enabled = false;
		rival3.GetComponent<SSuelo>().enabled = false;
		rival4.GetComponent<SSuelo>().enabled = false;
		rival5.GetComponent<SSuelo>().enabled = false;
		rival6.GetComponent<SSuelo>().enabled = false;
		rival7.GetComponent<SSuelo>().enabled = false;
		rival8.GetComponent<SSuelo>().enabled = false;
		rival9.GetComponent<SSuelo>().enabled = false;
		
		rival0.GetComponent<SBalonPies>().enabled = false;
		rival1.GetComponent<SBalonPies>().enabled = false;
		rival2.GetComponent<SBalonPies>().enabled = false;
		rival3.GetComponent<SBalonPies>().enabled = false;
		rival4.GetComponent<SBalonPies>().enabled = false;
		rival5.GetComponent<SBalonPies>().enabled = false;
		rival6.GetComponent<SBalonPies>().enabled = false;
		rival7.GetComponent<SBalonPies>().enabled = false;
		rival8.GetComponent<SBalonPies>().enabled = false;
		rival9.GetComponent<SBalonPies>().enabled = false;

		jugador0.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion");
		jugador1.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion2");
		jugador2.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion3");
		jugador3.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion4");
		jugador4.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion5");
		jugador5.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion6");
		jugador6.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion7");
		jugador7.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion8");
		jugador8.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion9");
		jugador9.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion10");

		rival0.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicionR");
		rival1.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion2R");
		rival2.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion3R");
		rival3.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion4R");
		rival4.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion5R");
		rival5.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion6R");
		rival6.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion7R");
		rival7.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion8R");
		rival8.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion9R");
		rival9.GetComponent<SCorrer> ().posicion = GameObject.Find ("posicion10R");

        portero.GetComponent<PorteroV2>().balon = balon.GetComponent<Balon> ();
		portero.GetComponent<PorteroV2> ().posicion = GameObject.Find ("porteria");
        portero.GetComponent<PorteroV2>().equipo = true;
 		porteroR.GetComponent<PorteroV2>().balon = balon.GetComponent<Balon> ();
		porteroR.GetComponent<PorteroV2>().posicion = GameObject.Find ("porteria2");
        porteroR.GetComponent<PorteroV2>().equipo = false;


    }

}
