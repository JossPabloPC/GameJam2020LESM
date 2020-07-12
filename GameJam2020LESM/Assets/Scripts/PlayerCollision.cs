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
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
        print("Enter");
            if (collision.gameObject.CompareTag("Queso"))
            {
                StartCoroutine(cheeseController(collision, timeCheese));
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        print("Enter collision");
        if (Input.GetKeyDown(KeyCode.E))
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
        AudioMixer.instance.sfx_rat.clip = AudioMixer.instance.eating;
        AudioMixer.instance.sfx_rat.Play();
        yield return new WaitForSeconds(delay);
        up = true;
        powerController(up);
        up = false;
        Destroy(collision.gameObject);
        movement.enabled = true;
    }

    IEnumerator doorController(Collision2D collision, float delay)
    {
        
        Debug.Log("Entré a la corrutina collision");
        AudioMixer.instance.sfx_rat.clip = AudioMixer.instance.lockpick;
        AudioMixer.instance.sfx_rat.Play();
        yield return new WaitForSeconds(delay);
        try
        {
            Destroy(collision.gameObject);
            up = false;
            powerController(up);
        }
        catch { }
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

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("door"))
        {
            rb.velocity = Vector2.zero;
        }
    }
}


//Checar si se quiere que se coman más quesos de los que puede almacenar. 
//If power = -1 --> GAME OVER

