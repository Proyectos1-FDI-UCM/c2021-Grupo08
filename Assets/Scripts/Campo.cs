using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campo : MonoBehaviour
{
    Mesh mesh;
    [SerializeField] LayerMask layerMask;
    Vector3 origin;
    float startingAngle = 0f;
    float fov;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
        fov = 360f;
    }

    private Vector3 Vec3FromAngle(float angle)
    {
        float newAngle = angle * (Mathf.PI / 180);
        return new Vector3(Mathf.Cos(newAngle), Mathf.Sin(newAngle));
    }

    private float AngleFromVec3(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        if (n < 0) n += 360;
        return n;
    }

    // Update is called once per frame
    void Update()
    {
        int rayCount = 500;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 5f;

        Vector3[] vertices = new Vector3[rayCount + 2];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int verIndex = 1;
        int triaIndex = 0;

        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 ver;
            RaycastHit2D hit = Physics2D.Raycast(origin, Vec3FromAngle(angle), viewDistance, layerMask);

            if (hit.collider == null)
            {
                ver = origin + Vec3FromAngle(angle) * viewDistance;
            }
            else
            {
                ver = hit.point;
            }
            vertices[verIndex] = ver;

            if (i > 0)
            {
                triangles[triaIndex] = 0;
                triangles[triaIndex + 1] = verIndex - 1;
                triangles[triaIndex + 2] = verIndex;
                triaIndex += 3;
            }
            verIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }
    public void SetAimDirection(Vector3 aimDir)
    {
        startingAngle = AngleFromVec3(aimDir) - fov / 2f;
    }
}
