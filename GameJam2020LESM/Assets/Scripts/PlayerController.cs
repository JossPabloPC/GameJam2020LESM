using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rBody;
    public float speed;
    public bool isIdle;
    private int power;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        power = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rBody.transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
            rBody.transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            rBody.transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
            rBody.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rBody.transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
            transform.eulerAngles = new Vector3(0, 0, -90);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rBody.transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
            rBody.transform.eulerAngles = new Vector3(0, 0, 90);
        }

    }
}
