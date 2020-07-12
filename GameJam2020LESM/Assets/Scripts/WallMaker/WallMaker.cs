using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMaker : MonoBehaviour
{
    public GameObject wall;
    public int nOfWalls;
    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < nOfWalls; i++)
        {
            Instantiate(wall, gameObject.transform.position + gameObject.transform.up* i, gameObject.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
