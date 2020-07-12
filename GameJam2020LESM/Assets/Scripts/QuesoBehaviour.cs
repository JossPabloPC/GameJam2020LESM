using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuesoBehaviour : MonoBehaviour
{
    [HideInInspector]
    public bool estaComiendose;
    public bool isEnvenenado;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void envenenar()
    {
        isEnvenenado = true;
    }
}
