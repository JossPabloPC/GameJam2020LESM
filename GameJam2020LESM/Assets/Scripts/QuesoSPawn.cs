using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuesoSPawn : MonoBehaviour
{
    public GameObject Queso;
    public float venomRecover;
    public GameObject barraVenom;
    public double delay;
    private double timer;
    private Vector3 spawnPoint;
    private List<GameObject> quesosEnEscena = new List<GameObject>();
    private List<GameObject> quesosLimpios = new List<GameObject>();
    private int quesoEnvenenadoIndx;

    public static QuesoSPawn Instance;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start(){
        barraVenom.transform.localScale = new Vector3(0, 1, 1);
        timer = delay;   
    }

    // Update is called once per frame
    void Update()
    {
        if (barraVenom.transform.localScale.x <= 1)
            barraVenom.transform.localScale += new Vector3(venomRecover * Time.deltaTime, 0, 0);
        timer -= 0.01;
        if(timer <= 0)
        {
            spawnPoint.x =  (float)(Random.Range(-8, 9)- 0.5);
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
        if (Input.GetKeyDown(KeyCode.Space) && barraVenom.transform.localScale.x >= 1)
        {
            try
            {
                SoundController.instance.sfx_blocker.clip = SoundController.instance.poisonCheese;
                SoundController.instance.sfx_blocker.Play();
                barraVenom.transform.localScale = new Vector3(0, 1, 1);
                quesoEnvenenadoIndx = Random.Range(0, quesosLimpios.Count);
                QuesoBehaviour currentQueso = quesosLimpios[quesoEnvenenadoIndx].GetComponent<QuesoBehaviour>();
                currentQueso.envenenar();
                quesosLimpios.RemoveAt(quesoEnvenenadoIndx);
            }
            catch { }
        }
    }
}
