using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoyMode : MonoBehaviour
{
    private float[] direction = new float[2];
    public float speed;
    public float currectSpeed;
    private bool estoyEnvenenado;
    public Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    { 
        estoyEnvenenado = false;
        currectSpeed = speed;
        direction[0] = 1;
        direction[1] = -1;
        anim.SetInteger("movement", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        drawLines();
        
        //Movimiento
        gameObject.transform.Translate(gameObject.transform.right * currectSpeed * Time.deltaTime, Space.World);
        int layerMask = 1 << 8;
        layerMask = ~layerMask;

        //dirección
        RaycastHit2D hitFront = Physics2D.Raycast(transform.position, gameObject.transform.right,0.75f,layerMask);//Ray del frente
        RaycastHit2D hitUp = Physics2D.Raycast(transform.position - gameObject.transform.right * 0.1f, gameObject.transform.up,0.75f,layerMask);//Ray Arriba
        RaycastHit2D hitDown = Physics2D.Raycast(transform.position - gameObject.transform.right * 0.1f, -gameObject.transform.up,0.75f,layerMask);//Ray Abajo


        if (hitFront.collider != null)
        {//Choques al frente
            Debug.Log(hitFront.collider.tag);
            if(hitFront.collider.CompareTag("Wall")) {
                gameObject.transform.eulerAngles += new Vector3(0, 0, 90 * direction[Random.Range(0,2)]);
            }
        }
        if (hitUp.collider != null)
        {//Choques a la Arriba
            if (hitUp.collider.CompareTag("door") || hitUp.collider.CompareTag("Queso"))
            {
                gameObject.transform.eulerAngles += new Vector3(0, 0, 90);
            }
        }
        if (hitDown.collider != null)
        {//Choques a la Abajo
            if (hitDown.collider.CompareTag("door") || hitDown.collider.CompareTag("Queso"))
            {
                gameObject.transform.eulerAngles += new Vector3(0, 0, -90);
            }
        }
        if (estoyEnvenenado)
            Destroy(gameObject);
    }

    private void drawLines()
    {
        Vector3 front = transform.TransformDirection(Vector3.right) * 0.75f;
        Vector3 arriba = transform.TransformDirection(Vector3.up) * 0.75f;
        Vector3 abajo = transform.TransformDirection(Vector3.down) * 0.75f;

        Debug.DrawRay(gameObject.transform.position, front, Color.green);
        Debug.DrawRay(gameObject.transform.position - gameObject.transform.right*0.1f, arriba, Color.red);
        Debug.DrawRay(gameObject.transform.position - gameObject.transform.right*0.1f, abajo, Color.yellow);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other != null)
        {

            if (other.CompareTag("Queso"))
            {
                Debug.Log("Colisione con Queso");
                StartCoroutine(WaitQueso(other));
            }

        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            if (collision.collider.CompareTag("door"))
            {
                Debug.Log("Colisione con puerta");
                currectSpeed = 0;
                StartCoroutine(WaitDoor());
            }
        }
    }
    IEnumerator WaitDoor()
    {
        anim.SetInteger("movement", 0);
        yield return new WaitForSeconds(2);
        anim.SetInteger("movement", 1);
        gameObject.transform.eulerAngles += new Vector3(0, 0, 180);
        currectSpeed = speed;
    }
    IEnumerator WaitQueso(Collider2D other)
    {
        yield return new WaitForSeconds(0.25f);
        currectSpeed = 0;
        Debug.Log("Inicie corrutina");
        anim.SetInteger("movement", 0);
        yield return new WaitForSeconds(2);
        anim.SetInteger("movement", 1);
        currectSpeed = speed;
        try
        {
            QuesoBehaviour currentQueso = other.gameObject.GetComponent<QuesoBehaviour>();
            if (currentQueso.isEnvenenado == true)
            {
                Debug.Log("Estoy envenenado");
                estoyEnvenenado = true;
            }

            Destroy(other.gameObject);
        }
        catch { }
    }
}
