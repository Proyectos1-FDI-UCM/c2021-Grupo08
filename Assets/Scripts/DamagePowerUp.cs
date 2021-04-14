﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePowerUp : MonoBehaviour
{
    public int multiplier, duration;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<PlayerController>())
        {
            GameObject player = col.gameObject;
            StartCoroutine(Damage(player));
                
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
        }
    }
    IEnumerator Damage(GameObject player)
    {
        player.GetComponent<Attack>().attackDamage *= multiplier;

        yield return new WaitForSeconds(duration);
        player.GetComponent<Attack>().attackDamage /= multiplier;

        Destroy(this.gameObject);
    }
}
