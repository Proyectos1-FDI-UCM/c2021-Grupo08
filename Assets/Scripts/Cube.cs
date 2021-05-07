using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject tile;
    void OnTriggerEnter2D(Collider2D col)
    {
        // si el player está en la casilla
        if(col.gameObject.GetComponent<PlayerController>() != null)
        {
            GetComponent<Collider2D>().enabled = false;
            tile.GetComponent<Collider2D>().enabled = false;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        // si el player está en la casilla
        if(col.gameObject.GetComponent<PlayerController>() != null)
        {
            GetComponent<Collider2D>().enabled = true;
            tile.GetComponent<Collider2D>().enabled = true;
        }
    }
}
