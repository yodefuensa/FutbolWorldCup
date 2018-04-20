using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class State : MonoBehaviour
{
	
	public int vel = 12;
	protected int fuerzaGolpeo = 25;
    public bool selector = false;
    public bool flipY = false;
    public int reinicio;
    //cuando se pulse C bloqueamos el movimiento y le damos la direccion de la falt
	protected Animator ar;
	public Selector seguidor;
    public bool equipo;
    


    public StateMachine st;

    void Awake()
    {
        st = GetComponent<StateMachine>();
    }

    protected void marcar() {
		if (selector){
			Vector3 posicionNuestra = new Vector3(transform.position.x, transform.position.y);
			seguidor.setPosicion(posicionNuestra);
		}
	}

}
