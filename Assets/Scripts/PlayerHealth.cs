﻿using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 0f, damage = 0f, speed= 0f, maxHealth = 200f;
    /*private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Enemy1>()) // No tenemos script del enemigo 1 todavía -> Hito 2
        {
            health -= 75;
        }
    }
    */
    public LifeBar healthBar;

    void Awake()
    {
        health = maxHealth;
    }

    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);

    }
    void Update()
    {
        if (Input.GetKeyDown("l"))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int danyo)
    {
        health -= danyo;

        healthBar.SetHealth(health);
    }


}
