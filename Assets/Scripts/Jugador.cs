﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour {

	public Balon balon;
	public bool balonGolpeado = false;
	public bool balonPies = false;
	public bool selector = false;
	private int vel = 8;
	public int fuerzaGolpeo = 20;
	//magnitud se usa en el manager partido, para saber que jugadores estaran mas cerca al salir la pelota
	public float magnitud = 0;
    public Vector2 posicionInicial;
	public GameObject posicion;

	void Start () {
	}

	void Update () {
		Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
		if (hits.Length > 1) {
			foreach (Collider2D hit in hits) {
				if (hit.name == "balon") {
					balonPies = true;
					//nota balonPies anadido en GolpeoV2 quitar si no es necesario
					//balon.balonPies = true;
					selector = true;
					if (!balonGolpeado) {
						balon.interceptado = true;
					}

				}
			}
		}

	}

	private void movimiento()
	{
		if (selector)
		{
			if (Input.GetAxisRaw("Vertical") > 0)
			{
				transform.position += Vector3.up * Time.deltaTime * vel;
			}
			else if (Input.GetAxisRaw("Vertical") < 0)
			{
				transform.position += Vector3.down * Time.deltaTime * vel;
			}

			if (Input.GetAxisRaw("Horizontal") > 0)
			{
				transform.position += new Vector3(1, 0) * Time.deltaTime * vel;
			}
			else if (Input.GetAxisRaw("Horizontal") < 0)
			{
				transform.position -= new Vector3(1, 0) * Time.deltaTime * vel;
			}
			if (Input.GetKey(KeyCode.Space) && balonPies && !balonGolpeado)
			{
				balon.ultimoTocado=true;
				balonPies = false;
				balonGolpeado = true;
				balon.interceptado = false;
				balon.tiempo = true;
				balon.fuerzaL = fuerzaGolpeo;
                balon.fuerzaL = fuerzaGolpeo;
				balon.direccion = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
				balon.golpeoV2 ();
				//StartCoroutine(balon.Golpeo(fuerzaGolpeo));
				StartCoroutine(setBalonGolpeadoFalse());
				StartCoroutine(balon.setBalonTiempoFalse());

			}
		}
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

    public void Entrada()
    {
       if (Input.GetKey(KeyCode.LeftAlt))
       {
            /*
            //animacion 
            if ((!balon.ultimoTocado) && (balon.interceptado))
            {
                if ()
            }*/
       }

    }




	void FixedUpdate()
	{
		movimiento();
		conducirBalon();
	}

}