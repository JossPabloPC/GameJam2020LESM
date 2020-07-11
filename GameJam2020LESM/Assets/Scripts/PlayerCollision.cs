using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController movement;
    private bool up;
    private int power = 0;
    public float timeCheese = 2;
    public float timeDoors = 1;

    private void OnTriggerStay2D(Collider2D collision)
    {
        print("Enter");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collision.gameObject.CompareTag("Queso"))
            {
                StartCoroutine(cheeseController(collision, timeCheese));
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        print("Enter collision");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (collision.gameObject.CompareTag("door"))
            {
                if (power >= 1)
                {
                    StartCoroutine(doorController(collision, timeDoors));
                }
            }
            if (collision.gameObject.CompareTag("exit"))
            {
                if (power >= 3)
                {
                    StartCoroutine(doorController(collision, timeDoors));
                    power = 0;
                }
            }
        }
    }

    IEnumerator cheeseController(Collider2D collision, float delay)
    {
        Debug.Log("Entré a la corrutina collider");
        movement.enabled = false;
        yield return new WaitForSeconds(delay);
        Destroy(collision.gameObject);
        up = true;
        powerController(up);
        movement.enabled = true;
        up = false;
    }

    IEnumerator doorController(Collision2D collision, float delay)
    {
        Debug.Log("Entré a la corrutina collision");
        yield return new WaitForSeconds(delay);
        Destroy(collision.gameObject);
        up = false;
        powerController(up);
    }

    void powerController(bool up)
    {
        if (up)
        {
            if (power < 5)
            {
                power++;
            }
        }
        else
        {
            power--;
        }
        Debug.Log("Poder final: " + power);
    }
}

//Checar si se quiere que se coman más quesos de los que puede almacenar. 
//If power = -1 --> GAME OVER

