using System.Collections;
using UnityEngine;

public class EnemyAtkREMIX : MonoBehaviour
{
    //Dist. de detección, Dist. a la que se para
    public float rangeOfDetection = 2f, rangeOfAttack = 1f, attackRate = 1f, attackDuration = 1f;
    public int damage;
    //Velocidad
    public int speed = 1;
    //Objeto al que debe perseguir
    public GameObject imAngryWith;

    Collider2D daCollider;
    

    bool isItAtkTime = true;


    private void Start()
    {
        daCollider = GetComponent<CapsuleCollider2D>();

        //Desactivo collider al hacer el raycast para que no se detecte a sí mismo
        daCollider.enabled = false;
    }
    private void Update()
    {
        

        RaycastHit2D hit = Physics2D.Raycast(transform.position, imAngryWith.transform.position - transform.position);
        //Para saber qué está "viendo"
        Debug.Log("Raycast detected the following: " + hit.collider.name);
        

        //Convierto en vector 2 la pos. de lo que tiene que perseguir
        Vector2 imAngryPos = new Vector2(imAngryWith.transform.position[0], imAngryWith.transform.position[1]);
        //Distancia a la que está de su objetivo
        float distSense = Vector2.Distance(transform.position, imAngryPos);

        //Se activa si es el objetivo
        if (hit.collider.name == imAngryWith.name && rangeOfDetection > distSense)
        {
            Debug.Log("Detected the target!");
            //Mira si lo tiene que perseguir o atacar
            if (rangeOfAttack < distSense)
            {
                //Movimiento!
                transform.position = Vector2.MoveTowards(transform.position, imAngryPos, speed * Time.deltaTime);
                
                Debug.DrawRay(transform.position, imAngryWith.transform.position - transform.position, Color.yellow);
            }
            //Ataca!
            else
            {
                Debug.DrawRay(transform.position, imAngryWith.transform.position - transform.position, Color.red);
                daCollider.enabled = true;
                Attack();
            }
        }
        //Si no es el objetivo...
        else
        {
            Debug.DrawRay(transform.position, imAngryWith.transform.position - transform.position, Color.gray);
            daCollider.enabled = false;
        }
        
    }

    //Pendiente de implementar
    private void Attack()
    {
        if (isItAtkTime)
        {
            StartCoroutine("AttackDurator");
            isItAtkTime = false;
            StartCoroutine("AttackWaiter");
        }
    }
    public IEnumerator AttackDurator()
    {
        daCollider.enabled = true;
        yield return new WaitForSeconds(attackDuration * 0.1f);
        imAngryWith.GetComponent<PlayerHealth>().TakeDamage(damage);
    }

    public IEnumerator AttackWaiter()
    {
        daCollider.enabled = false;
        yield return new WaitForSeconds(attackRate);
        isItAtkTime = true;
    }

    
}
