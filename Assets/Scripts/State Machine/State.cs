using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class State : MonoBehaviour
{
	public Balon balon;
	public bool balonGolpeado = false;
	public bool balonPies = false;
	public bool selector = false;
	public int vel = 12;
	protected int fuerzaGolpeo = 15;
    //robo es para saber si podremos robar la pelota
    public bool robo;
    //cuando se pulse C bloqueamos el movimiento y le damos la direccion de la falta
    public bool tRobo;
    //zasca te han hecho falta te caes al suelo no te puedes mover durante X tiempo
    public bool falta;
    //magnitud se usa en el manager partido, para saber que jugadores estaran mas cerca al salir la pelota
    public Vector3 dirFalta;
	public float magnitud = 0;
    public Vector3 posicionInicial;
	public GameObject posicion;
	protected Animator ar;
	public bool flipY = false;
	public Selector seguidor;
   // public GameObject equipoRivalGO;
    public MngEquiV2 equipoRival;
	protected float lastPosition = 0;
    public bool equipo;
    public GameObject porteriaRival;

    protected StateMachine stateMachine;

    void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
    }

	protected void marcar() {
		if (selector){
			Vector3 posicionNuestra = new Vector3(transform.position.x, transform.position.y);
			seguidor.setPosicion(posicionNuestra);
		}
	}

}
