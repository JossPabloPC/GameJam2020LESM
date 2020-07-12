using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float speed;
    [HideInInspector]
    public bool timeIsUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.localScale.x >= 0)
            gameObject.transform.localScale -= new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
