using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpriteRenderer mySpriteRenderer;
    Rigidbody2D rb;
    public float velocity = 5f;
    public Animator animator;
    float horizontal, vertical;
    public bool tiempoespera = false;
    public bool tiempogas = false;
    public int vida = 200;

    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        Control();
    }
    void Control()
    {
        rb.velocity = new Vector2(horizontal, vertical).normalized * velocity;
        if(horizontal < -0.1f)
        {
            if(mySpriteRenderer != null)
            {
                // flip the sprite
                mySpriteRenderer.flipX = true;
            }
        }
        else
        {
            mySpriteRenderer.flipX = false;
        }
    }
    /*private void OnTriggerEnter2D(Collider2D sierra)
    {
        if (sierra.tag == "Sierra" && !tiempoespera)
        {
            vida -= 50;
            tiempoespera = true;
            StartCoroutine("EsperarSierra");
        }
    }
    public IEnumerator EsperarSierra()
    {
        yield return new WaitForSeconds(2);
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
    }*/
}
