using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palo : MonoBehaviour {

    public bool pausa;
	// Use this for initialization
	void Start () {
        pausa = false;	
	}


    public IEnumerator setPausaFalse()
    {
        yield return new WaitForSeconds(3f);
        pausa = false;
    }
    
    public int Marcar()
    {
        if (!pausa)
        {
            if (name == "palo1")
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y - 0.2f), Vector3.right, 7.5f);
                Debug.DrawLine(new Vector2(transform.position.x, transform.position.y + 0.2f), new Vector2(transform.position.x + 7.5f, transform.position.y + 0.2f), Color.red);
                if (hits.Length > 1)
                {
                    foreach (RaycastHit2D hit in hits)
                    {
                        if (hit.collider.name == "balon")
                        {
                            Debug.Log("gol");
                            pausa = true;
                            StartCoroutine(setPausaFalse());
                            return 1;

                        }
                    }
                }
            }
            if (name == "palo3")
            {
                RaycastHit2D[] hits2 = Physics2D.RaycastAll(transform.position, Vector3.right, 7.5f);
                Debug.DrawLine(new Vector2(transform.position.x, transform.position.y - 0.2f), new Vector2(transform.position.x + 7.5f, transform.position.y - 0.2f), Color.red);
                if (hits2.Length > 1)
                {
                    foreach (RaycastHit2D hit in hits2)
                    {
                        if (hit.collider.name == "balon")
                        {
                            Debug.Log("gol");
                            pausa = true;
                            StartCoroutine(setPausaFalse());
                            return 1;
                        }
                    }

                }

            }
        }

        return 0;
    }


}
