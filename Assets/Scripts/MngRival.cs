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
	public IEnumerator inputFalsoEspacioTrue ()
	{//mientras se ejecuta falso espacio esta a false, lo pone a true al final
// no tengo claro que coño hace aqui, sirve para implementar un golpeo igual que en portero
		yield return new WaitForSeconds(.5f);
		inputFalsoEspacio = true;
	}

    /*
     	private void escanerSelector(){
	//impide que haya mas de un jugador seleccionado
	//implementado limpiador balonPies 
		int count = 0;
		for (int n = 0; n<jugadores.Length; n++){
			if (jugadores[n].selector ==true)
				count++;
			if (count > 1) {
				Debug.Log ("count mayor de uno");
				limpiarSelector ();
				int pos = jugadorCercano();
				jugadores[pos].selector = true;
			}
		}
		int count2 = 0;
		for (int n = 0; n<jugadores.Length; n++){
			if (jugadores[n].balonPies ==true)
				count2++;
			if (count2 > 1) {
				Debug.Log ("count2 mayor de uno");
				for (int m = 0; m < jugadores.Length; m++)
				{	
					jugadores[m].balonPies = false;
				}
				int pos = jugadorCercano();
				jugadores[pos].selector = true;
				jugadores [pos].balonPies = true;
			}
		}
	}
    
	private void limpiarSelector()
    {
        for (int n = 0; n < jugadores.Length; n++)
        {	
            jugadores[n].selector = false;
        }
    } 
     */


    private void FixedUpdate()
    {
        int cercano = rivalCercano();
        Rival[cercano].perseguir(); 



    }
}
