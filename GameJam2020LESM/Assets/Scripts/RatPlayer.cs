using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RatPlayer : MonoBehaviour
{

    private Rigidbody2D rBody;
    public float speed;
    public bool isIdle;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Abajo");
            rBody.transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
            rBody.transform.eulerAngles = new Vector3(0,0,180); 

        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Arriba");

            rBody.transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
            //rBody.transform.localScale = new Vector3(1f, 1f, 1f);
            rBody.transform.eulerAngles = new Vector3(0,0,0); 

        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("Der");

            rBody.transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
            //rBody.transform.localScale = new Vector3(1f, 1f, 1f);
            transform.eulerAngles = new Vector3(0, 0, -90);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("Izq");

            rBody.transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
            //rBody.transform.localScale = new Vector3(-1f, 1f, 1f);
            rBody.transform.eulerAngles = new Vector3(0,0,90);

        }
    }
}
