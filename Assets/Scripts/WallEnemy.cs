using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallEnemy : MonoBehaviour
{
    public float speed;
    public float distance;
    public Transform detection;

    public LayerMask pared;

    bool moveRight = false;
    bool moveUp = true;

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        RaycastHit2D hit = Physics2D.Raycast(detection.position, Vector2.down, distance, pared);
        if(hit.collider == false)
        {
            
        }
    }
}
