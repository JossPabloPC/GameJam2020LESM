using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyMode : MonoBehaviour
{
    private float[] direction = new float[2];
    public float speed;
    public float currectSpeed;
    private bool estoyEnvenenado;
    // Start is called before the first frame update
    void Start()
    {
        estoyEnvenenado = false;
        currectSpeed = speed;
        direction[0] = 1;
        direction[1] = -1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        drawLines();
        
        //Movimiento
        gameObject.transform.Translate(gameObject.transform.up * currectSpeed * Time.deltaTime, Space.World);

        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        //dirección
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position, gameObject.transform.up,0.75f,layerMask);//Ray del frente
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position - gameObject.transform.up * 0.5f, gameObject.transform.right,0.75f,layerMask);//Ray derecha
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position - gameObject.transform.up * 0.5f, -gameObject.transform.right,0.75f,layerMask);//Ray izquweirda


        if (hitUp.collider != null)
        {//Choques al frente
            if(hitUp.collider.CompareTag("Wall")) {
                gameObject.transform.eulerAngles += new Vector3(0, 0, 90 * direction[Random.Range(0,2)]);
            }
        }
        if (hitRight.collider != null)
        {//Choques a la derecha
            if (hitRight.collider.CompareTag("door") || hitRight.collider.CompareTag("Queso"))
            {
                gameObject.transform.eulerAngles += new Vector3(0, 0, -90);
            }
        }
        if (hitLeft.collider != null)
        {//Choques a la izq
            if (hitLeft.collider.CompareTag("door") || hitLeft.collider.CompareTag("Queso"))
            {
                gameObject.transform.eulerAngles += new Vector3(0, 0, 90);
            }
        }
        if (estoyEnvenenado)
            Destroy(gameObject);
    }

    private void drawLines()
    {
        Vector3 up = transform.TransformDirection(Vector3.up) * 0.75f;
        Vector3 left = transform.TransformDirection(Vector3.left) * 0.75f;
        Vector3 right = transform.TransformDirection(Vector3.right) * 0.75f;

        Debug.DrawRay(gameObject.transform.position, up, Color.green);
        Debug.DrawRay(gameObject.transform.position - gameObject.transform.up*0.5f, left, Color.red);
        Debug.DrawRay(gameObject.transform.position - gameObject.transform.up*0.5f, right, Color.yellow);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other != null)
        {
            if (other.collider.CompareTag("door"))
            {
                Debug.Log("Colisione con puerta");
                currectSpeed = 0;
                StartCoroutine(WaitDoor());
            }
            else if (other.collider.CompareTag("Queso"))
            {
                currectSpeed = 0;
                Debug.Log("Comiendo con Queso");
                StartCoroutine(WaitQueso(other));
            }

        }
        
    }
    IEnumerator WaitDoor()
    {
        yield return new WaitForSeconds(2);
        gameObject.transform.eulerAngles += new Vector3(0, 0, 180);
        currectSpeed = speed;
    }
    IEnumerator WaitQueso(Collision2D other)
    {
        Debug.Log("Inicie corrutina");
        yield return new WaitForSeconds(2);
        currectSpeed = speed;
        try
        {
            QuesoBehaviour currentQueso = other.gameObject.GetComponent<QuesoBehaviour>();
            if (currentQueso.isEnvenenado == true) {
                Debug.Log("Estoy envenenado");
                estoyEnvenenado = true;
            }
            Destroy(other.gameObject);
        }
        catch { }
    }
}
