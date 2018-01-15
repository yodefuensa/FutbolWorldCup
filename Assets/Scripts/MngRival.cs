using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngRival : MonoBehaviour {

    public Rival[] Rival;
    public PorteroV2Rival benji;
    public Balon balon;
	public GameObject porteria;
	public GameObject porteriaRival;
	public bool inputFalsoEspacio;

    void Start () {		
	}

	void Update () {
	}

    private int rivalCercano()
    {//devuelve la posicion del array del jugador mas cercano
        int posicion = 0;
        Vector3 distancia = new Vector3(3, 3);
        Vector3 MaxDistancia = new Vector3(3, 3);
        for (int n = 0; n < this.Rival.Length; n++)
        {
            if (n == 0)
            {
                distancia = Rival[n].transform.position - balon.transform.position;
                MaxDistancia = distancia;
                posicion = n;
            }
            if (n > 0)
            {
                distancia = Rival[n].transform.position - balon.transform.position;
                if (MaxDistancia.magnitude > distancia.magnitude)
                {
                    MaxDistancia = distancia;
                    posicion = n;
                }
            }
        }
        return posicion;
    }
	public IEnumerator inputFalsoEspacioTrue (){
		yield return new WaitForSeconds(.5f);
		inputFalsoEspacio = true;
	}
		

    private void FixedUpdate()
    {
        int cercano = rivalCercano();
        Rival[cercano].perseguir(); 



    }
}
