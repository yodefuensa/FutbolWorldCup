using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteroV2Rival : MonoBehaviour {


	public Balon balon;
	public bool balonGolpeado = false;
	public bool balonPies = false;
	public bool selector = false;
	private int vel = 3;
	public int fuerzaGolpeo = 20;
	public bool inputFalsoEspacio;
	public GameObject posicion;

	void Start () {
	}


	void Update () {
		Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
		if (hits.Length > 1) {
			foreach (Collider2D hit in hits) {
				if (hit.name == "balon") {
					balonPies = true;
					selector = true;
					if (!balonGolpeado) {
						balon.interceptado = true;
					}

				}
			}
		}
		mngPortero ();
	}

	public IEnumerator inputFalsoEspacioTrue ()
	{
		yield return new WaitForSeconds(.5f);
		inputFalsoEspacio = true;
	}

	private void movimiento()
	{
		if (balon.transform.position.x < transform.position.x)
		{
			transform.position -= new Vector3(1, 0) * Time.deltaTime * vel;
		}

		if (balon.transform.position.x > transform.position.x)
		{
			transform.position += new Vector3(1, 0) * Time.deltaTime * vel;
		}
		if (transform.position.y> posicion.transform.position.y-3f)
			transform.position -= new Vector3(0,1)* Time.deltaTime * vel;
	}

	private void mngPortero(){
		if (balonPies) {
			StartCoroutine (inputFalsoEspacioTrue ());
		}
		if (inputFalsoEspacio && balonPies /*&& (!benji.balonGolpeado)*/)
		{
            balon.ultimoTocado = false;
            balonPies = false;
            balonGolpeado = true;
            balon.interceptado = false;
            balon.tiempo = true;
            balon.fuerzaL = fuerzaGolpeo;
            balon.direccion = Vector3.down;
            balon.golpeoV2();
            //StartCoroutine(balon.Golpeo(fuerzaGolpeo));
            StartCoroutine(setBalonGolpeadoFalse());
            StartCoroutine(balon.setBalonTiempoFalse());
        }
		inputFalsoEspacio = false;
	}

	public IEnumerator setBalonGolpeadoFalse()
	{//para no tocar el balon al golpearlo
		for (int n = 0; n < 10; n++)
		{            
			yield return new WaitForSeconds(.1f);
		}
		balonGolpeado = false;
		balonPies = false;
	}

	public void conducirBalon()
	{
		if (balonPies && !balonGolpeado)
		{
			Vector3 posbal = new Vector3(transform.position.x, transform.position.y + 0.5f);
			balon.setPosicion(posbal);
		}
	}

	void FixedUpdate()
	{
		movimiento();
		conducirBalon();        
	}

}
