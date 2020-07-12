﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public PlayerController movement;
    public Animator anim;
    public TextMeshProUGUI contadorDeQueso;
    private bool up;
    public int power = 0;
    public float timeCheese = 2;
    public float timeDoors = 1;
    private Rigidbody2D rb;
    public static  PlayerCollision instance;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        contadorDeQueso.text = "x 0";
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
        //print("Enter collision");
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
        PlayerController.instance.anim.SetInteger("movement", 0);
        movement.enabled = false;
        SoundController.instance.sfx_rat.clip = SoundController.instance.eating;
        SoundController.instance.sfx_rat.Play();
        yield return new WaitForSeconds(delay);
        up = true;
        QuesoBehaviour currentQueso = collision.gameObject.GetComponent<QuesoBehaviour>();
        powerController(up, currentQueso);
        up = false;
        Destroy(collision.gameObject);
        movement.enabled = true;
    }

    IEnumerator doorController(Collision2D collision, float delay)
    {
        
        Debug.Log("Entré a la corrutina collision");

        SoundController.instance.sfx_rat.clip = SoundController.instance.lockpick;
        SoundController.instance.sfx_rat.Play();
        PlayerController.instance.anim.SetInteger("movement", 2);
        movement.enabled = false;
        yield return new WaitForSeconds(delay);
        PlayerController.instance.anim.SetInteger("movement", 1);
        movement.enabled = true;
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
                contadorDeQueso.text = "x " + power;
            }
        }
        else
        {
            power--;
            contadorDeQueso.text = "x " + power;
        }
        Debug.Log("Poder final: " + power);
    }

    void powerController(bool up, QuesoBehaviour currentQueso)
    {
        if (up)
        {
            if (power < 5 && !currentQueso.isEnvenenado)
            {
                power++;
                contadorDeQueso.text = "x " + power;
            }
            else if (power > 0 && currentQueso.isEnvenenado)
            {
                power--;
                contadorDeQueso.text = "x " + power;
            }
        }
        else
        {
            power--;
            contadorDeQueso.text = "x " + power;
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

