using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteroV2 : MonoBehaviour {

	public Balon balon;
	public bool balonGolpeado = false;
	public bool balonPies = false;
	public bool selector = false;
	private int vel = 6;
	public int fuerzaGolpeo = 20;

	public GameObject posicion;

	void Start () {
	}

	void Update () {
		Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
		foreach (Collider2D hit in hits) {
      		if (hit.name == "balon")
	        {
	            balonPies = true;
	            selector = true;
	            balon.ultimoTocado = true;
	            if (!balonGolpeado)
	            {
	                balon.interceptado = true;
	            }
	        }
		}
        movimiento();
    }

	private void movimiento()
	{

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
            balon.ultimoTocado = true;
            balonPies = false;
            balonGolpeado = true;
            balon.interceptado = false;
            balon.tiempo = true;
            balon.fuerzaL = fuerzaGolpeo;
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
			Vector3 posbal = new Vector3(transform.position.x, transform.position.y + .3f);
			balon.setPosicion(posbal);
		}
	}

	void FixedUpdate()
	{

		conducirBalon();

    }

}
