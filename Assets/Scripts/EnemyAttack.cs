using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float speed = 2f;
    public bool grr = false;
    public GameObject estoyEnfadadoCon;
    public float atkDist = 5f, seeDist = 30f, atkRate = 2f, atkDuration = 1f;
    
    bool letsHit = false;
    private Rigidbody2D me;
    GameObject hb;
    SpriteRenderer sprite, hitbox;

    void Awake()
    {
        hb = GameObject.Find("Hitbox");
        me = gameObject.GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        hitbox = hb.GetComponent<SpriteRenderer>();
        hitbox.enabled = false;
        hitting();
    }

    private void Update()
    {
        if (grr)
        {
            
            float distance = Vector3.Distance(transform.position, estoyEnfadadoCon.transform.position);
            
            if (distance > atkDist && distance < seeDist)
            {
                follow(estoyEnfadadoCon.transform); 
            }
            if (distance < seeDist)
            {
                sprite.color = Color.red;
            }
            else sprite.color = Color.white;

            if (atkDist > distance)
            {
                letsHit = true;
            }
            else letsHit = false;
        }
        
    }
    private void hitting()
    {
        Debug.Log("The 'hitting' method has been called");
        float a = 0;

        if (letsHit)
        {
            Debug.Log("Should be hitting...");
            if (atkDuration >= a)
            {
                Debug.Log("The hitbox should be enabled...");
                hitbox.enabled = true;
                a += Time.deltaTime;
            }
            else
            {
                float b = 0;
                if (b < atkRate) b += Time.deltaTime;
                else
                {
                    a = 0;
                    b = 0;
                }
                
                
            }
        }
        Debug.Log("Values: a= " + a);
    }

    private void follow(Transform target)
    {
        
        me.AddForce((target.transform.position - transform.position).normalized * speed);
    }
}
