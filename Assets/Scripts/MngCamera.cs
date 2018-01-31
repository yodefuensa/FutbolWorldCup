using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MngCamera : MonoBehaviour {

    public GameObject balon;
    public Vector3 velocity = Vector3.zero;

    void Update()
    {
        float positionX = Mathf.Clamp(balon.transform.position.x, -21f, 21f);
        float positionY = Mathf.Clamp(balon.transform.position.y, -49f, 49f);  
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(positionX, positionY, -10), ref velocity, 0.2f);

    }
}

