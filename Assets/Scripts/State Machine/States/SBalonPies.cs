using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBalonPies : State {

    public Balon balon;
    private float lastPosition = 0;
    public GameObject porteriaRival;
    public bool cazado;

    [Header("Estados a los que puede ir")]
    public State stParado;
    public State stSuelo;
    public State stScorrer;

    void Start()
    {
        Debug.Log("balon pies");
        balon = GameObject.FindObjectOfType<Balon>();
        ar = GetComponent<Animator>();
        cazado = false;
        if (equipo)
            porteriaRival = GameObject.Find("porteria2");
        if (!equipo)
            porteriaRival = GameObject.Find("porteria");
    }

    void Update(){
        if (reinicio==0)
        {
            cazado = false;
        } 
        this.tag = "balonPies";
        movimiento();
        animatorObserver();
        stupidAI();
        conducirBalon();
        marcar();
        if (cazado){
            st.ChangeState(stSuelo,equipo,selector,flipY,0);
        }
        reinicio++;
    }
    

    private void movimiento()
    {
        if ((selector) && equipo)
        {
            // Vector3 noMove = balon.
            if (!balon.balonFuera)
            {
                if (Input.GetAxisRaw("Vertical") > 0)
                    transform.position += Vector3.up * Time.deltaTime * vel;
                if (Input.GetAxisRaw("Vertical") < 0)
                    transform.position += Vector3.down * Time.deltaTime * vel;
                if (Input.GetAxisRaw("Horizontal") > 0)
                    transform.position += new Vector3(1, 0) * Time.deltaTime * vel;
                if (Input.GetAxisRaw("Horizontal") < 0)
                    transform.position -= new Vector3(1, 0) * Time.deltaTime * vel;
                if (Input.GetButtonDown("Golpeo")){
                    if (equipo)
                        balon.ultimoTocado = true;
                    if (!equipo)
                        balon.ultimoTocado = false;
                    balon.interceptado = false;
                    balon.fuerzaL = fuerzaGolpeo;
                    balon.direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                    balon.golpeoV2b();
                    st.ChangeState(stScorrer,equipo,selector,flipY,0);
 
                }
            }
        }

    }

    private void movimientoP2()
    {
        if ((selector) && !equipo && MngScenes.multijugador)
        {
            if (Input.GetAxisRaw("VerticalP2") > 0)
                transform.position += Vector3.up * Time.deltaTime * vel;
            if (Input.GetAxisRaw("VerticalP2") < 0)
                transform.position += Vector3.down * Time.deltaTime * vel;
            if (Input.GetAxisRaw("HorizontalP2") > 0)
                transform.position += new Vector3(1, 0) * Time.deltaTime * vel;
            if (Input.GetAxisRaw("HorizontalP2") < 0)
                transform.position -= new Vector3(1, 0) * Time.deltaTime * vel;
            if (Input.GetButtonDown("GolpeoP2")){
                if (equipo)
                    balon.ultimoTocado = true;
                if (!equipo)
                    balon.ultimoTocado = false;
                balon.interceptado = false;
                balon.fuerzaL = fuerzaGolpeo;
                balon.direccion = new Vector2(Input.GetAxisRaw("HorizontalP2"), Input.GetAxisRaw("VerticalP2"));
                balon.golpeoV2b();
                st.ChangeState(stScorrer,equipo,selector,flipY,0);
            }

        }

    }
    public void conducirBalon()
    {

        if (flipY)
        {
            Vector3 posbal = new Vector3(transform.position.x, transform.position.y - 0.5f);
            balon.setPosicion(posbal);
        }
        if (!flipY)
        {
            Vector3 posbal = new Vector3(transform.position.x, transform.position.y + 0.5f);
            balon.setPosicion(posbal);
        }

    }

    private void stupidAI()
    {
        if (!MngScenes.multijugador && !equipo)
        {//no es multi, tenemos el balon en los pies y somos la ia corremos a porteria
            Vector3 distancia = porteriaRival.transform.position - transform.position;
            transform.position += distancia.normalized * Time.deltaTime * vel;
            if (distancia.magnitude < 12)
            {
                Debug.Log(distancia.normalized);
                balon.direccion = distancia.normalized;
                balon.golpeoV2b();
                st.ChangeState(stScorrer, equipo, selector, flipY, 0);
            }
        }
    }

    private void animatorObserver()
    {
        if (lastPosition < transform.position.y)
        {
            ar.SetBool("corriendo", true);
            if (flipY)
            {
                transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y);
                flipY = false;
            }
            lastPosition = transform.position.y;
        }
        if (lastPosition > transform.position.y)
        {
            ar.SetBool("corriendo", true);
            if (!flipY)
            {
                transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y);
                flipY = true;
            }
            lastPosition = transform.position.y;
        }

    }

}
