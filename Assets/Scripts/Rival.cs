using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rival : MonoBehaviour {

    // Use this for initialization
    public Balon ball;
    public bool balonGolpeado = false;
    public bool balonPies = false;
    private int vel = 6;
    public int fuerzaGolpeo = 10;
    public GameObject porteriaRival;
    public Vector2 posInicial;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Vector3 getPosicion()
    {
        return transform.position;
    }
    public void setPosicion(Vector3 pos)
    {
        transform.position = pos;
    }
    public void perseguir()
    {
        if (!balonPies)
        {
            if (transform.position.y > ball.transform.position.y + 1 || transform.position.y < ball.transform.position.y - 1
                   || transform.position.x > ball.transform.position.x + 1 || transform.position.x < ball.transform.position.x - 1)
            {
                if (transform.position.y > ball.transform.position.y)
                {
                    transform.position += Vector3.down * Time.deltaTime * vel;
                }
                if (transform.position.y < ball.transform.position.y)
                {
                    transform.position += Vector3.up * Time.deltaTime * vel;
                }
                if (transform.position.x > ball.transform.position.x)
                {
                    transform.position += Vector3.left * Time.deltaTime * vel;
                }
                if (transform.position.x < ball.transform.position.x)
                {
                    transform.position += Vector3.right * Time.deltaTime * vel;
                }
            }
        }
    }
    public void conducirBalon()
    {
        if (balonPies && !balonGolpeado)
        {
            Vector3 posbal = new Vector3(transform.position.x, transform.position.y + 0.5f);
            ball.setPosicion(posbal);
        }
    }


    public void balonEnPies()
    {
        if (balonPies)
        {
            if (transform.position.y > porteriaRival.transform.position.y)
            {
                transform.position += Vector3.down * Time.deltaTime * vel;
            }
            if (transform.position.y < porteriaRival.transform.position.y)
            {
                transform.position += Vector3.up * Time.deltaTime * vel;
            }
            if (transform.position.x > porteriaRival.transform.position.x)
            {
                transform.position += Vector3.left * Time.deltaTime * vel;
            }
            if (transform.position.x < porteriaRival.transform.position.x)
            {
                transform.position += Vector3.right * Time.deltaTime * vel;
            }
        }
        
    }

    public void FixedUpdate()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 1f);
        if (hits.Length > 1)
        {
            foreach (Collider2D hit in hits)
            {
                if (hit.name == "balon")
                {
                    balonPies = true;
                    if (!balonGolpeado)
                    {
                        ball.interceptado = true;
                    }

                }
            }
        }
        conducirBalon();
        balonEnPies();
    }


}
