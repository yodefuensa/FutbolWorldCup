using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPersonajes : MonoBehaviour {

    public Jugador[] jugadores;
    public PorteroV2 benji;
    public Balon balon;


    void Start(){
    }

	void Update () {		
	}

    private void setPosInicial()
    {
        //FUCK ESTABLECE LA ZONA DE ACCION Y POSICION INICAL
    }

    public int jugadorCercano()
    {//devuelve la posicion del array del jugador mas cercano
        int posicion = 0;
        Vector3 distancia = new Vector3(3, 3);
        Vector3 MaxDistancia = new Vector3(3, 3);
        for (int n = 0; n < this.jugadores.Length; n++)
        {
            if (n == 0)
            {
				distancia = balon.transform.position - jugadores[n].transform.position;
                MaxDistancia = distancia;
                posicion = n;
            }
            if (n > 0)
            {
				distancia = balon.transform.position - jugadores[n].transform.position;
                if (MaxDistancia.magnitude > distancia.magnitude)
                {
                    MaxDistancia = distancia;
                    posicion = n;
                }
            }
        }
        return posicion;
    }
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
    
    public void limpiarBalonPies()
    {
        for (int n = 0; n < jugadores.Length; n++)
            jugadores[n].balonPies = false;
    }

	private void limpiarSelector()
    {
        for (int n = 0; n < jugadores.Length; n++)
        {	
            jugadores[n].selector = false;
        }
    }
    
	public void cambiarJugador()
    {//si pulsas la tecla "control" selecciona el jugador mas cercano
        if (Input.GetKey(KeyCode.LeftControl))
        {
            limpiarSelector();
            int pos = jugadorCercano();
            jugadores[pos].selector = true;
        }
    }



    private void LateUpdate()
    {
        cambiarJugador();        
		escanerSelector ();
    }

}
