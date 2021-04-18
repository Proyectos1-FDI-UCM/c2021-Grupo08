using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hacerdaño : MonoBehaviour
{
    public Rigidbody2D rbody;    
    public int vida = 200;
    public bool tiempoespera = false;
    public bool tiempogas = false;
    public float speed = 2;
    public Collider2D a;
    public Collider2D b;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnTriggerEnter2D(a);
        OnTriggerStay2D(b);
    }
    
        private void OnTriggerEnter2D(Collider2D sierra)
        {


            if (sierra.tag == "Sierra" && !tiempoespera)
            {
            vida -= 50;
            tiempoespera = true;
            StartCoroutine("EsperarSierra");
                             
            }
        }
        /*private void BasicMov()
        {

            Vector2 movementInput = Vector2.zero;
       
            if (Input.GetKey(KeyCode.A))
            {

            movementInput.z = 1;
        }

            else if (Input.GetKey(KeyCode.W))
            {
            movementInput.x = 1;
            

            }

            else if (Input.GetKey(KeyCode.S))
            {

            movementInput.x = -1;

        }

            else if (Input.GetKey(KeyCode.D))
            {
            
            movementInput.z = -1;

        }
        Move(movementInput);
        }
    public void Move(Vector2 direction)
    {
        transform.position += direction.normalized * Time.deltaTime * speed;
    }*/
        public IEnumerator EsperarSierra()
        {
            yield return new WaitForSeconds(5);
            tiempoespera = false;
        }
    public IEnumerator EsperarGas()
    {
        yield return new WaitForSeconds(1);
        tiempogas = false;
    }
    private void OnTriggerStay2D(Collider2D gas)
    {
        if(gas.tag == "Gas" && !tiempogas)
        {
            vida -= 10;
            tiempogas = true;
            StartCoroutine("EsperarGas");
        }
    }
}
