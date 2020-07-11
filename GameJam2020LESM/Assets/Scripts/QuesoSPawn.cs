using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuesoSPawn : MonoBehaviour
{
    public GameObject Queso;
    public double delay;
    private double timer;
    private Vector3 spawnPoint;
    private List<GameObject> quesosEnEscena = new List<GameObject>();
    private List<GameObject> quesosLimpios = new List<GameObject>();
    private int quesoEnvenenadoIndx;
    // Start is called before the first frame update
    void Start()
    {
        timer = delay;   
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 0.01;
        if(timer <= 0)
        {
            spawnPoint.x =  (float)(Random.Range(-8, 9)-0.5);
            spawnPoint.y = (float)(Random.Range(-4, 5) - 0.5);
            GameObject instance = Instantiate(Queso, spawnPoint, Quaternion.identity);
            instance.name = "Queso" + quesosEnEscena.Count;
            quesosEnEscena.Add(instance);
            quesosLimpios.Add(instance);
            timer = delay;
        }
        envenenarQueso();
    }
    private void envenenarQueso()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           quesoEnvenenadoIndx = Random.Range(0, quesosLimpios.Count);
           quesosLimpios[quesoEnvenenadoIndx].SetActive(false);
           quesosLimpios.RemoveAt(quesoEnvenenadoIndx);
        }
    }
}
