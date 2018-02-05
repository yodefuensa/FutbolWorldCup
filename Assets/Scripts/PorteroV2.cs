using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteroV2 : MonoBehaviour {

	public Balon balon;
	public bool balonGolpeado = false;
	public bool balonPies = false;
	public bool selector = false;
	private int vel = 6;
	public int fuerzaGolpeo = 10;
    public static bool esPortero;
    public bool equipo;

	public GameObject posicion;

    void FixedUpdate(){
        conducirBalon();
        if (balonPies)
            esPortero = true;
     //   else
     //       esPortero = false;
    }


    void Update () {
        hit();
        movimiento();
    }

    public void hit(){
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (Collider2D hit in hits)
        {
            if (hit.name == "balon")
            {
                balonPies = true;
                selector = true;
                if (equipo)
                    balon.ultimoTocado = true;
                else
                    balon.ultimoTocado = false;
                StopCoroutine("balon.setBalonTiempoFalse");
                if (!balonGolpeado)
                {
                    balon.interceptado = true;
                }
            }
        }
    }

	private void movimiento(){
        Vector3 zonaBalon = posicion.transform.position-balon.transform.position;
        Vector3 zona = posicion.transform.position - transform.position;
        Vector3 balonDist = balon.transform.position - transform.position;
        if (zonaBalon.magnitude < 10f)
        {
            transform.position += balonDist.normalized * Time.deltaTime * vel;
        }
        else if ((zona.magnitude > 2f)&& !balonPies)
            transform.position += zona.normalized * Time.deltaTime * vel;

		if ((Input.GetButton("Golpeo") && balonPies && !balonGolpeado))
		{
            if (equipo)
                balon.ultimoTocado = true;
            if (!equipo)
                balon.ultimoTocado = false;
            balonPies = false;
            balonGolpeado = true;
            balon.interceptado = false;
            balon.tiempo = true;
            balon.fuerzaL = fuerzaGolpeo;
            esPortero = false;
            balon.direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            balon.golpeoV2();
            StartCoroutine(setBalonGolpeadoFalse());
            StartCoroutine(balon.setBalonTiempoFalse());
        }

	}

	public IEnumerator setBalonGolpeadoFalse()
	{//para no tocar el balon al golpearlo
		for (int n = 0; n < 10; n++) {            
			yield return new WaitForSeconds(.1f);
		}
		balonGolpeado = false;
		balonPies = false;
	}

	public void conducirBalon()
	{
		if (balonPies && !balonGolpeado)
		{
            if (posicion.transform.position.y > transform.position.y)
            {
                Vector3 posbal = new Vector3(transform.position.x, transform.position.y - .3f);
                balon.setPosicion(posbal);
            }
            else
            {
                Vector3 posbal = new Vector3(transform.position.x, transform.position.y + .3f);
                balon.setPosicion(posbal);
            }
		}
	}

	
}
