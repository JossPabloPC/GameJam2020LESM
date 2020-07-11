using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyMode : MonoBehaviour
{
    private float[] direction = new float[2];
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        direction[0] = 1;
        direction[1] = -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 up = transform.TransformDirection(Vector3.up) * 0.75f;
        Vector3 left = transform.TransformDirection(Vector3.left) * 0.75f;
        Vector3 right = transform.TransformDirection(Vector3.right) * 0.75f;

        Debug.DrawRay(gameObject.transform.position, up, Color.green);
        Debug.DrawRay(gameObject.transform.position, left, Color.red);
        Debug.DrawRay(gameObject.transform.position, right, Color.yellow);
        //Movimeinto
        gameObject.transform.Translate(gameObject.transform.up * speed * Time.deltaTime, Space.World);

        //dirección
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, gameObject.transform.up,0.75f);
        if (hitUp.collider != null)
        {
            if(hitUp.collider.CompareTag("Wall")) {
                gameObject.transform.eulerAngles += new Vector3(0, 0, 90 * direction[Random.Range(0,2)]);
            }
            Debug.Log(hitUp.collider.tag);
        }


    }
}
