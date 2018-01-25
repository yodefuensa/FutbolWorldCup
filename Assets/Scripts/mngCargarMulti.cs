using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mngCargarMulti : MonoBehaviour {

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



    void Start () {
        jugador0.GetComponent<Jugador>().posicion = GameObject.Find("posicion");
        jugador1.GetComponent<Jugador>().posicion = GameObject.Find("posicion2");
        jugador2.GetComponent<Jugador>().posicion = GameObject.Find("posicion3");
        jugador3.GetComponent<Jugador>().posicion = GameObject.Find("posicion4");
        jugador4.GetComponent<Jugador>().posicion = GameObject.Find("posicion5");
        jugador5.GetComponent<Jugador>().posicion = GameObject.Find("posicion6");
        jugador6.GetComponent<Jugador>().posicion = GameObject.Find("posicion7");
        jugador7.GetComponent<Jugador>().posicion = GameObject.Find("posicion8");
        jugador8.GetComponent<Jugador>().posicion = GameObject.Find("posicion9");
        jugador9.GetComponent<Jugador>().posicion = GameObject.Find("posicion10");

        rival0.GetComponent<Rival>().posicionAl = GameObject.Find("posicionR");
        rival1.GetComponent<Rival>().posicionAl = GameObject.Find("posicion2R");
        rival2.GetComponent<Rival>().posicionAl = GameObject.Find("posicion3R");
        rival3.GetComponent<Rival>().posicionAl = GameObject.Find("posicion4R");
        rival4.GetComponent<Rival>().posicionAl = GameObject.Find("posicion5R");
        rival5.GetComponent<Rival>().posicionAl = GameObject.Find("posicion6R");
        rival6.GetComponent<Rival>().posicionAl = GameObject.Find("posicion7R");
        rival7.GetComponent<Rival>().posicionAl = GameObject.Find("posicion8R");
        rival8.GetComponent<Rival>().posicionAl = GameObject.Find("posicion9R");
        rival9.GetComponent<Rival>().posicionAl = GameObject.Find("posicion10R");

    }

    private void Awake()
    {
        if (MngScenes.p1pais == "spain")
        {
            jugador0 = Instantiate(spain, new Vector2(transform.position.x + 3f, transform.position.y - 3f), Quaternion.identity);
            jugador1 = Instantiate(spain, new Vector2(transform.position.x - 3f, transform.position.y - 3f), Quaternion.identity);
            jugador2 = Instantiate(spain, new Vector2(transform.position.x - 20f, transform.position.y - 15f), Quaternion.identity);
            jugador3 = Instantiate(spain, new Vector2(transform.position.x - 10f, transform.position.y - 15f), Quaternion.identity);
            jugador4 = Instantiate(spain, new Vector2(transform.position.x + 10f, transform.position.y - 15f), Quaternion.identity);
            jugador5 = Instantiate(spain, new Vector2(transform.position.x + 20f, transform.position.y - 15f), Quaternion.identity);
            jugador6 = Instantiate(spain, new Vector2(transform.position.x - 20f, transform.position.y - 35f), Quaternion.identity);
            jugador7 = Instantiate(spain, new Vector2(transform.position.x - 10f, transform.position.y - 35f), Quaternion.identity);
            jugador8 = Instantiate(spain, new Vector2(transform.position.x + 10f, transform.position.y - 35f), Quaternion.identity);
            jugador9 = Instantiate(spain, new Vector2(transform.position.x + 20f, transform.position.y - 35f), Quaternion.identity);
        }
        if (MngScenes.p1pais == "brasil")
        {
            jugador0 = Instantiate(brasil, new Vector2(transform.position.x + 3f, transform.position.y - 3f), Quaternion.identity);
            jugador1 = Instantiate(brasil, new Vector2(transform.position.x - 3f, transform.position.y - 3f), Quaternion.identity);
            jugador2 = Instantiate(brasil, new Vector2(transform.position.x - 20f, transform.position.y - 15f), Quaternion.identity);
            jugador3 = Instantiate(brasil, new Vector2(transform.position.x - 10f, transform.position.y - 15f), Quaternion.identity);
            jugador4 = Instantiate(brasil, new Vector2(transform.position.x + 10f, transform.position.y - 15f), Quaternion.identity);
            jugador5 = Instantiate(brasil, new Vector2(transform.position.x + 20f, transform.position.y - 15f), Quaternion.identity);
            jugador6 = Instantiate(brasil, new Vector2(transform.position.x - 20f, transform.position.y - 35f), Quaternion.identity);
            jugador7 = Instantiate(brasil, new Vector2(transform.position.x - 10f, transform.position.y - 35f), Quaternion.identity);
            jugador8 = Instantiate(brasil, new Vector2(transform.position.x + 10f, transform.position.y - 35f), Quaternion.identity);
            jugador9 = Instantiate(brasil, new Vector2(transform.position.x + 20f, transform.position.y - 35f), Quaternion.identity);
        }
        if (MngScenes.p1pais == "usa")
        {
            jugador0 = Instantiate(usa, new Vector2(transform.position.x + 3f, transform.position.y - 3f), Quaternion.identity);
            jugador1 = Instantiate(usa, new Vector2(transform.position.x - 3f, transform.position.y - 3f), Quaternion.identity);
            jugador2 = Instantiate(usa, new Vector2(transform.position.x - 20f, transform.position.y - 15f), Quaternion.identity);
            jugador3 = Instantiate(usa, new Vector2(transform.position.x - 10f, transform.position.y - 15f), Quaternion.identity);
            jugador4 = Instantiate(usa, new Vector2(transform.position.x + 10f, transform.position.y - 15f), Quaternion.identity);
            jugador5 = Instantiate(usa, new Vector2(transform.position.x + 20f, transform.position.y - 15f), Quaternion.identity);
            jugador6 = Instantiate(usa, new Vector2(transform.position.x - 20f, transform.position.y - 35f), Quaternion.identity);
            jugador7 = Instantiate(usa, new Vector2(transform.position.x - 10f, transform.position.y - 35f), Quaternion.identity);
            jugador8 = Instantiate(usa, new Vector2(transform.position.x + 10f, transform.position.y - 35f), Quaternion.identity);
            jugador9 = Instantiate(usa, new Vector2(transform.position.x + 20f, transform.position.y - 35f), Quaternion.identity);
        }
        if (MngScenes.p1pais == "argentina")
        {
            jugador0 = Instantiate(argentina, new Vector2(transform.position.x + 3f, transform.position.y - 3f), Quaternion.identity);
            jugador1 = Instantiate(argentina, new Vector2(transform.position.x - 3f, transform.position.y - 3f), Quaternion.identity);
            jugador2 = Instantiate(argentina, new Vector2(transform.position.x - 20f, transform.position.y - 15f), Quaternion.identity);
            jugador3 = Instantiate(argentina, new Vector2(transform.position.x - 10f, transform.position.y - 15f), Quaternion.identity);
            jugador4 = Instantiate(argentina, new Vector2(transform.position.x + 10f, transform.position.y - 15f), Quaternion.identity);
            jugador5 = Instantiate(argentina, new Vector2(transform.position.x + 20f, transform.position.y - 15f), Quaternion.identity);
            jugador6 = Instantiate(argentina, new Vector2(transform.position.x - 20f, transform.position.y - 35f), Quaternion.identity);
            jugador7 = Instantiate(argentina, new Vector2(transform.position.x - 10f, transform.position.y - 35f), Quaternion.identity);
            jugador8 = Instantiate(argentina, new Vector2(transform.position.x + 10f, transform.position.y - 35f), Quaternion.identity);
            jugador9 = Instantiate(argentina, new Vector2(transform.position.x + 20f, transform.position.y - 35f), Quaternion.identity);
        }
        if (MngScenes.p1pais == "alemania")
        {
            jugador0 = Instantiate(alemania, new Vector2(transform.position.x + 3f, transform.position.y - 3f), Quaternion.identity);
            jugador1 = Instantiate(alemania, new Vector2(transform.position.x - 3f, transform.position.y - 3f), Quaternion.identity);
            jugador2 = Instantiate(alemania, new Vector2(transform.position.x - 20f, transform.position.y - 15f), Quaternion.identity);
            jugador3 = Instantiate(alemania, new Vector2(transform.position.x - 10f, transform.position.y - 15f), Quaternion.identity);
            jugador4 = Instantiate(alemania, new Vector2(transform.position.x + 10f, transform.position.y - 15f), Quaternion.identity);
            jugador5 = Instantiate(alemania, new Vector2(transform.position.x + 20f, transform.position.y - 15f), Quaternion.identity);
            jugador6 = Instantiate(alemania, new Vector2(transform.position.x - 20f, transform.position.y - 35f), Quaternion.identity);
            jugador7 = Instantiate(alemania, new Vector2(transform.position.x - 10f, transform.position.y - 35f), Quaternion.identity);
            jugador8 = Instantiate(alemania, new Vector2(transform.position.x + 10f, transform.position.y - 35f), Quaternion.identity);
            jugador9 = Instantiate(alemania, new Vector2(transform.position.x + 20f, transform.position.y - 35f), Quaternion.identity);
        }
        if (MngScenes.p1pais == "japon")
        {
            jugador0 = Instantiate(japon, new Vector2(transform.position.x + 3f, transform.position.y - 3f), Quaternion.identity);
            jugador1 = Instantiate(japon, new Vector2(transform.position.x - 3f, transform.position.y - 3f), Quaternion.identity);
            jugador2 = Instantiate(japon, new Vector2(transform.position.x - 20f, transform.position.y - 15f), Quaternion.identity);
            jugador3 = Instantiate(japon, new Vector2(transform.position.x - 10f, transform.position.y - 15f), Quaternion.identity);
            jugador4 = Instantiate(japon, new Vector2(transform.position.x + 10f, transform.position.y - 15f), Quaternion.identity);
            jugador5 = Instantiate(japon, new Vector2(transform.position.x + 20f, transform.position.y - 15f), Quaternion.identity);
            jugador6 = Instantiate(japon, new Vector2(transform.position.x - 20f, transform.position.y - 35f), Quaternion.identity);
            jugador7 = Instantiate(japon, new Vector2(transform.position.x - 10f, transform.position.y - 35f), Quaternion.identity);
            jugador8 = Instantiate(japon, new Vector2(transform.position.x + 10f, transform.position.y - 35f), Quaternion.identity);
            jugador9 = Instantiate(japon, new Vector2(transform.position.x + 20f, transform.position.y - 35f), Quaternion.identity);
        }
        if (MngScenes.p1pais == "rusia")
        {
            jugador0 = Instantiate(rusia, new Vector2(transform.position.x + 3f, transform.position.y - 3f), Quaternion.identity);
            jugador1 = Instantiate(rusia, new Vector2(transform.position.x - 3f, transform.position.y - 3f), Quaternion.identity);
            jugador2 = Instantiate(rusia, new Vector2(transform.position.x - 20f, transform.position.y - 15f), Quaternion.identity);
            jugador3 = Instantiate(rusia, new Vector2(transform.position.x - 10f, transform.position.y - 15f), Quaternion.identity);
            jugador4 = Instantiate(rusia, new Vector2(transform.position.x + 10f, transform.position.y - 15f), Quaternion.identity);
            jugador5 = Instantiate(rusia, new Vector2(transform.position.x + 20f, transform.position.y - 15f), Quaternion.identity);
            jugador6 = Instantiate(rusia, new Vector2(transform.position.x - 20f, transform.position.y - 35f), Quaternion.identity);
            jugador7 = Instantiate(rusia, new Vector2(transform.position.x - 10f, transform.position.y - 35f), Quaternion.identity);
            jugador8 = Instantiate(rusia, new Vector2(transform.position.x + 10f, transform.position.y - 35f), Quaternion.identity);
            jugador9 = Instantiate(rusia, new Vector2(transform.position.x + 20f, transform.position.y - 35f), Quaternion.identity);
        }
        if (MngScenes.p1pais == "china")
        {
            jugador0 = Instantiate(china, new Vector2(transform.position.x + 3f, transform.position.y - 3f), Quaternion.identity);
            jugador1 = Instantiate(china, new Vector2(transform.position.x - 3f, transform.position.y - 3f), Quaternion.identity);
            jugador2 = Instantiate(china, new Vector2(transform.position.x - 20f, transform.position.y - 15f), Quaternion.identity);
            jugador3 = Instantiate(china, new Vector2(transform.position.x - 10f, transform.position.y - 15f), Quaternion.identity);
            jugador4 = Instantiate(china, new Vector2(transform.position.x + 10f, transform.position.y - 15f), Quaternion.identity);
            jugador5 = Instantiate(china, new Vector2(transform.position.x + 20f, transform.position.y - 15f), Quaternion.identity);
            jugador6 = Instantiate(china, new Vector2(transform.position.x - 20f, transform.position.y - 35f), Quaternion.identity);
            jugador7 = Instantiate(china, new Vector2(transform.position.x - 10f, transform.position.y - 35f), Quaternion.identity);
            jugador8 = Instantiate(china, new Vector2(transform.position.x + 10f, transform.position.y - 35f), Quaternion.identity);
            jugador9 = Instantiate(china, new Vector2(transform.position.x + 20f, transform.position.y - 35f), Quaternion.identity);
        }

        if (MngScenes.p2pais == "spain")
        {
            rival0 = Instantiate(spainR, new Vector2(transform.position.x + 3f, transform.position.y - 3f), Quaternion.identity);
            rival1 = Instantiate(spainR, new Vector2(transform.position.x - 3f, transform.position.y - 3f), Quaternion.identity);
            rival2 = Instantiate(spainR, new Vector2(transform.position.x - 20f, transform.position.y - 15f), Quaternion.identity);
            rival3 = Instantiate(spainR, new Vector2(transform.position.x - 10f, transform.position.y - 15f), Quaternion.identity);
            rival4 = Instantiate(spainR, new Vector2(transform.position.x + 10f, transform.position.y - 15f), Quaternion.identity);
            rival5 = Instantiate(spainR, new Vector2(transform.position.x + 20f, transform.position.y - 15f), Quaternion.identity);
            rival6 = Instantiate(spainR, new Vector2(transform.position.x - 20f, transform.position.y - 35f), Quaternion.identity);
            rival7 = Instantiate(spainR, new Vector2(transform.position.x - 10f, transform.position.y - 35f), Quaternion.identity);
            rival8 = Instantiate(spainR, new Vector2(transform.position.x + 10f, transform.position.y - 35f), Quaternion.identity);
            rival9 = Instantiate(spainR, new Vector2(transform.position.x + 20f, transform.position.y - 35f), Quaternion.identity);
        }
    }




    // Update is called once per frame
    void Update () {
		
	}
}
