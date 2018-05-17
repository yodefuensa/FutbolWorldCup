using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SSuelo : State {

	bool falta;
	public State stScorrer;
	// Use this for initialization
	void Start () {
		Debug.Log("suelo");
		ar = GetComponent<Animator>();
        ar.SetBool ("suelo", true);
		falta = true;
		StartCoroutine(setFaltaFalse());	
	}
	
	// Update is called once per frame
	void Update () {
		if (!falta){
			st.ChangeState(stScorrer,equipo,selector,flipY,0,magnitud);
		}
		marcar();
	}
	public IEnumerator setFaltaFalse()
    {//si te hacen falta poner bloqueo
        yield return new WaitForSeconds(2f);
        falta = false;
        ar.SetBool("suelo",false);
    }
}
