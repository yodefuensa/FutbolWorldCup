using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngCamera : MonoBehaviour {

    public GameObject balon;

    void Start () {
	}
	void Update (){
	}

    void LateUpdate()
    {
        transform.position = new Vector3(balon.transform.position.x, balon.transform.position.y, -10);
    }
}

