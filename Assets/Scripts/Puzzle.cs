using UnityEngine;
public class Puzzle : MonoBehaviour
{
    // gameobject del espacio vacío del puzle
    public Transform emptySpace;
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
            if(hit)
            {
                if(Vector2.Distance(emptySpace.position, hit.transform.position) < 4)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    emptySpace.position = hit.transform.position;
                    hit.transform.position = lastEmptySpacePosition;
                }
            }
        }
    }
}