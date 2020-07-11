using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rBody;
    public float speed;
    public bool isIdle;
    private int power;
    private int direccion;

    public Animator anim;

    public void Awake()
    {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        direccion = 1;
        power = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Abajo
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetInteger("movement", 1);
            gameObject.transform.Translate(Vector2.down * speed * Time.deltaTime, Space.World);
            gameObject.transform.eulerAngles = new Vector3(0, 0, -90*direccion);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            //Arriba
            anim.SetInteger("movement",1);
            gameObject.transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
            gameObject.transform.eulerAngles = new Vector3(0, 0, 90*direccion);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            //Derecha
            anim.SetInteger("movement",1);
            direccion = 1;
            gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            //Izquierda
            direccion = -1;
            anim.SetInteger("movement", 1);
            gameObject.transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            anim.SetInteger("movement", 0);
        }
    }
}
