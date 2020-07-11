using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaMovimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public float dimension;
    public float speed;
    public bool direccion;
    private Vector3 pivot;
    public bool horizontal;
    private Rigidbody2D rb;
    void Start()
    {
        pivot = gameObject.transform.position;
        rb = GetComponent<Rigidbody2D>();
        //rb.isKinematic = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moverPuerta();
    }

    public void moverPuerta()
    {
        if (direccion)
        {
            if (horizontal)
            {
                if (gameObject.transform.position.x <= pivot.x + dimension)
                {
                    rb.AddForce(new Vector2(speed * Time.deltaTime, 0));
                }
                else
                {
                    rb.velocity = Vector3.zero;
                }
            }
            else
            {
                if (gameObject.transform.position.y <= pivot.y + dimension)
                    rb.AddForce(new Vector2(0, speed * Time.deltaTime));
                else
                {
                    rb.velocity = Vector3.zero;
                }
            }
        }
        else
        {
            if (horizontal)
            {
                if (gameObject.transform.position.x >= pivot.x)
                {
                    rb.AddForce(new Vector2(speed * Time.deltaTime * -1, 0));
                }
                else
                {
                    rb.velocity = Vector3.zero;
                }
            }
            else
            {
                if (gameObject.transform.position.y >= pivot.y)
                    rb.AddForce(new Vector2(0, speed * Time.deltaTime * -1));
                else
                {
                    rb.velocity = Vector3.zero;
                }
            }
        }
    }    
}
