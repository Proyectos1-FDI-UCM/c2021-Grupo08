using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRestore : MonoBehaviour
{
    public float restore;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerHealth>())
        {
            GameObject player = col.gameObject;
            PlayerHealth PlayerHealth = player.GetComponent<PlayerHealth>();
            if (PlayerHealth.health < PlayerHealth.maxHealth)
            {
                if (PlayerHealth.health + restore <= PlayerHealth.maxHealth)
                {
                    PlayerHealth.health += restore;
                }

                else
                {
                    PlayerHealth.health = PlayerHealth.maxHealth;
                }

                Destroy(this.gameObject);
            }
        }
    }
}
