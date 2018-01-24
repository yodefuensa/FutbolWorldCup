using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palo : MonoBehaviour {

    public Balon balon;
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

    public void rebote()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, .2f);
        Debug.DrawLine(new Vector2(transform.position.x-.2f, transform.position.y), new Vector2(transform.position.x+.2f, transform.position.y), Color.blue);
        foreach (Collider2D hit in hits)
        {
            if (hit.name == "balon")
            {
                balon.direccion = new Vector3(balon.direccion.x, balon.direccion.y * -1);
            }
        }
    }
    
    public int Marcar()
    {
        if (!pausa)
        {
            if (name == "palo1")
            {
                RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y - 0.2f), Vector3.right, 7.5f);
                Debug.DrawLine(new Vector2(transform.position.x, transform.position.y + 0.2f), new Vector2(transform.position.x + 7.5f, transform.position.y + 0.2f), Color.red);
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
    public void FixedUpdate()
    {
        rebote();
    }

}
