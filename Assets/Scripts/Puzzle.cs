using UnityEngine;
public class Puzzle : MonoBehaviour
{
    // gameobject del espacio vacío del puzle
    public Transform emptySpace;
    public int distance;
    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            //aseguramos que sea solo el tile
            if(hit && hit.collider.gameObject.layer == 13)
            {
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.name);
                }
                if(Vector2.Distance(emptySpace.position, hit.transform.position) < distance)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    emptySpace.position = hit.transform.position;
                    hit.transform.position = lastEmptySpacePosition;
                }
            }
        }
    }
}