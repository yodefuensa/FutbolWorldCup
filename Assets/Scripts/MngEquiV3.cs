using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngEquiV3 : MonoBehaviour {


    public State [] jugadores;
    public PorteroV2 benji;
    public Balon balon;

    private void LateUpdate(){
        cambiarJugador();
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
        if (Input.GetButton("CambiarPlayer"))
        {
            limpiarSelector();
            int pos = jugadorCercano();
            jugadores[pos].selector = true;
        }
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


}

