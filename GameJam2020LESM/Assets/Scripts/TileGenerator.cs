using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 18; i++)
        {
            for (int j= 0; j < 10; j++)
            {
                Instantiate(tile, gameObject.transform.position + new Vector3(i,-j,0),gameObject.transform.rotation);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
