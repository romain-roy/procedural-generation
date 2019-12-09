using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMesh : MonoBehaviour
{
    public Material material;

    private Vector3[] vertices;
    private int[] triangles;
    private Vector2[] uv;
    private int indiceVertices = 0, indiceTriangles = 0, indiceUV = 0;

    void Start()
    {
        int nbCoupures = 4;
        int nbMeridians = 36;

        vertices = new Vector3[(nbMeridians + 1 - nbCoupures * 2) * 4 + 2];
        triangles = new int[(nbMeridians - nbCoupures * 2) * 12];
        uv = new Vector2[(nbMeridians + 1 - nbCoupures * 2) * 4 + 2];

        Cylinder cylinder = new Cylinder(new Vector2(1, 1), 2, nbMeridians, nbCoupures, 2);

        addShape(cylinder.getTriangles(), cylinder.getVertices(), cylinder.getUV());
        CreateMesh(vertices, triangles, uv);
    }

    void addShape(int[] triangles, Vector3[] vertices, Vector2[] uv)
    {
        foreach (int i in triangles)
        {
            this.triangles[indiceTriangles++] = i + indiceVertices;
        }
        foreach (Vector3 v in vertices)
        {
            this.vertices[indiceVertices++] = v;
        }
        foreach (Vector2 u in uv)
        {
            this.uv[indiceUV++] = u;
        }
    }

    void CreateMesh(Vector3[] vertices, int[] triangles, Vector2[] uv)
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Mesh mesh = new Mesh();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uv;

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = material;

        gameObject.GetComponent<MeshFilter>().mesh.RecalculateNormals();
    }
}
