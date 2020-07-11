using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuesoBehaviour : MonoBehaviour
{
    [HideInInspector]
    public bool estaComiendose;
    // Start is called before the first frame update
    void Start()
    {
        estaComiendose = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null)
        {
            if (other.collider.CompareTag("Player") || other.collider.CompareTag("Decoy"))
                estaComiendose = true;
        }
    }
}
