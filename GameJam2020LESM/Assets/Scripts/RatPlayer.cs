using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine;

public class RatPlayer : MonoBehaviour
{

    private Rigidbody2D rBody;
    public float speed;
    public bool isIdle;
    private int power;
    private bool isEating;

    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        power = 0;
        isEating = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEating)
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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(delayController(collision,3));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Entré a la corrutina collision");
        if (collision.gameObject.CompareTag("door"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(delayController(collision, 1));
            }
        }
        if (collision.gameObject.CompareTag("exit") && power>=3)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(delayController(collision, 2));
                Debug.Log("Ganaste");
            }
        }
    }

    IEnumerator delayController(Collider2D collision, int delay)
    {
        Debug.Log("Entré a la corrutina collider");

        isEating = true;

        yield return new WaitForSeconds(delay);

        isEating = false;

        //Límite de quesos en stock = 5
        if (power < 5)
        {
            power++;
        }
        Debug.Log("Quesos comidos: " + power);

        Destroy(collision.gameObject);
    }
    IEnumerator delayController(Collision2D collision, int delay)
    {
        isEating = true;

        yield return new WaitForSeconds(delay);

        isEating = false;

        if (power >= 1)
        {
            power--;
            Debug.Log("Poder restante: " + power);
            Destroy(collision.gameObject);
        }
    }
}
