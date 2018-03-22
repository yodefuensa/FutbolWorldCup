using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SBalonPies : State {

    public Balon balon;
    public bool flipY = false;
    private float lastPosition = 0;
    public GameObject porteriaRival;

    [Header("Estados a los que puede ir")]
    public State stParado;
    public State stFalta;
    public State stBalonPies;

    void Start()
    {
        balon = GameObject.FindObjectOfType<Balon>();
        ar = GetComponent<Animator>();
        if (equipo)
            porteriaRival = GameObject.Find("porteria2");
        if (!equipo)
            porteriaRival = GameObject.Find("porteria");
    }

    void Update()
    {
        movimiento();
        animatorObserver();
        stupidAI();
        conducirBalon();
        marcar();
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
