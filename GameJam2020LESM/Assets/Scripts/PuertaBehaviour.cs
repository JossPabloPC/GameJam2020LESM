using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaBehaviour : MonoBehaviour
{
    public KeyCode tecla;
    public bool prueb;
    public PuertaMovimiento[] puertas;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(tecla))){
            foreach (PuertaMovimiento puerta in puertas)
            {
                puerta.direccion = ! puerta.direccion;
                SoundController.instance.sfx_blocker.clip = SoundController.instance.door;
                SoundController.instance.sfx_blocker.Play();
            }
        }
    }
}
