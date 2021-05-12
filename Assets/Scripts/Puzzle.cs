using UnityEngine;
public class Puzzle : MonoBehaviour
{
    // gameobject del espacio vacío del puzle
    public Transform emptySpace;
    public Transform emptyCube;
    public int distance, numOfTiles;
    public GameObject[] tile, cube;
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
                if(Vector2.Distance(emptySpace.position, hit.transform.position) < distance)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    Vector2 lastEmpty = emptyCube.position;
                    emptySpace.position = hit.transform.position;
                    
                    for (int i = 0; i < numOfTiles; i++)
                    {
                        if(hit.collider.gameObject == tile[i])
                        {
                            emptyCube.position = cube[i].transform.position;
                            cube[i].transform.position = lastEmpty;
                        }
                    }
                    hit.transform.position = lastEmptySpacePosition;
                }
            }
        }
    }
}