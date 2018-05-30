using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class JugadorV2b : MonoBehaviour {

	public Balon balon;
	public bool balonGolpeado = false;
	public bool balonPies = false;
	public bool selector = false;
	public int vel = 12;
	private int fuerzaGolpeo = 30;
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
	private Animator ar;
	public bool flipY = false;
	public Selector seguidor;
   // public GameObject equipoRivalGO;
    public MngEquiV2 equipoRival;
	private float lastPosition = 0;
    public bool equipo;
    public GameObject porteriaRival;
    private SCorrer stCorrer;
    private SSuelo stSuelo;
    private SFalta stFalta;
    private SBalonPies stBalonPies;

    private void Awake(){
		posicionInicial = new Vector2 (transform.position.x, transform.position.y);
		falta = false;
    }

    void Start () {
        falta = false;
        tRobo = false;
        ar = GetComponent<Animator>();
	}

	void Update () {
        marcar();
        hit();
        controlador();
    }

    void FixedUpdate(){
        animatorObserver();
        if ((!balonPies) && (equipo))
            this.tag = "Jugador";
        else if ((!balonPies) && (!equipo))
            this.tag = "Rival";
        else
        {
            this.tag = "balonPies";
            selector = true;
            if (equipo)
                balon.ultimoTocado = true;
            else
                balon.ultimoTocado = false;
        }
    }

    public IEnumerator setBalonGolpeadoFalse()
    {//para no tocar el balon al golpearlo
        yield return new WaitForSeconds(.5f);
        balonGolpeado = false;
        balonPies = false;
    }
    public IEnumerator setFaltaFalse()
    {//si te hacen falta poner bloqueo
        yield return new WaitForSeconds(2f);
        falta = false;
        ar.SetBool("suelo",false);
    }

    public IEnumerator setTRoboFalse()
    {//tiempo de robo, momento que haces falta y se te bloquea la direcion
        yield return new WaitForSeconds(0.7f);
        tRobo = false;
		ar.SetBool ("falta", false);
    }

    private void hit(){
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
        robo = false;
        if (!falta)
        {
            foreach (Collider2D hit in hits){
                if ((hit.name == "balon") && (!balon.interceptado) &&  (!balonGolpeado))
                {
                    balonPies = true;
                    selector = true;
                    balon.interceptado = true;
                    StopCoroutine("balon.setBalonTiempoFalse");
                }
                if (hit.tag == "balonPies")
                {
                    robo = true;
                }
            }
        }
    }

    private void controlador(){
        if (balonPies){
            stBalonPies.enabled = true;
            stCorrer.enabled =false;
            stFalta.enabled = false;
            stSuelo.enabled = false;
        }
        else if (falta){
            stBalonPies.enabled = false;
            stCorrer.enabled =false;
            stFalta.enabled = false;
            stSuelo.enabled = true;
        }
        else if (tRobo){
            stBalonPies.enabled = false;
            stCorrer.enabled =false;
            stFalta.enabled = false;
            stSuelo.enabled = true;
        }
        else {
            stBalonPies.enabled = false;
            stCorrer.enabled =true;
            stFalta.enabled = false;
            stSuelo.enabled = false;
        }
    }


    private void animatorObserver (){
		if (lastPosition == transform.position.y)
			ar.SetBool ("corriendo", false);
		if (lastPosition < transform.position.y) {
			ar.SetBool ("corriendo", true);
			if (flipY) {
				transform.localScale = new Vector3 (transform.localScale.x, -transform.localScale.y);
				flipY = false;
			}
			lastPosition = transform.position.y;
		}
		if (lastPosition > transform.position.y){
			ar.SetBool ("corriendo", true);
			if (!flipY) {
				transform.localScale = new Vector3 (transform.localScale.x, -transform.localScale.y);
				flipY = true;
			}
			lastPosition = transform.position.y;
		}
        if (falta){
            ar.SetBool("suelo",true);
        }
	}
    
	private void marcar() {
		if (selector){
			Vector3 posicionNuestra = new Vector3(transform.position.x, transform.position.y);
			seguidor.setPosicion(posicionNuestra);
		}
	}

}