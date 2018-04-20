using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFalta : State {

    public Balon balon;
    private bool tRobo;
    public State stParado;
    public State stScorrer;
    public State stBalonPies;
    //private jugadorCazado;
    Vector3 vectorDireccion;

	void start (){                
        balon = GameObject.FindObjectOfType<Balon>();
        ar = GetComponent<Animator>();
        ar.SetBool ("falta", true);
    }

    void Update () {
        if (reinicio==0){
            Vector3 distanciaBalon = balon.transform.position - transform.position;
            vectorDireccion = distanciaBalon.normalized;
            StartCoroutine (setTRoboFalse());
            tRobo = true;
        }
        hacerFalta();
        hit();
        if (!tRobo){
            st.ChangeState(stScorrer,equipo,selector,flipY,0);
        }
        reinicio++;
           
    } 
    
    public IEnumerator setTRoboFalse()
    {//tiempo de robo, momento que haces falta y se te bloquea la direcion
        yield return new WaitForSeconds(0.7f);
        tRobo = false;
    }
    
    public void hacerFalta(){     
        transform.position += vectorDireccion * Time.deltaTime * vel;
    }
    
    private void hit(){
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (Collider2D hit in hits)
        {
            if ((hit.name == "balon") && (!balon.interceptado))
            {
                selector = true;
                balon.interceptado = true;
                StopCoroutine("balon.setBalonTiempoFalse");
                st.ChangeState(stBalonPies,equipo,selector,flipY,0);
            }
            else if (hit.tag=="balonPies")
            {
                Debug.Log("toca");
                selector = true;
                balon.interceptado = true;
                GameObject.FindGameObjectWithTag ("balonPies").GetComponent<SBalonPies>().cazado=true;
                st.ChangeState(stBalonPies,equipo,selector,flipY,0);
            }
        }
        
    }

}
