using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // ignorar toda colision con el puzle
        Physics2D.IgnoreLayerCollision(8, 10, true);
        Physics2D.IgnoreLayerCollision(11, 10, true);
        Physics2D.IgnoreLayerCollision(15, 10, true);
    }

}
