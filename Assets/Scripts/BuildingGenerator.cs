using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    public Vector3 baseSize;
    public float maxHeight;
    [Range(0, 4)] public int tiersLimit;
    public Material material;

    private Vector3 lb, rt;
    private float height;
    private Vector3[] vertices;
    private int[] triangles;
    private int indiceVertices = 0, indiceTriangles = 0;

    void Start()
    {
        vertices = new Vector3[8 * (tiersLimit + 2)];
        triangles = new int[36 * (tiersLimit + 2)];

        // Base

        lb = new Vector3(0f, 0f, 0f);
        rt = baseSize;

        addBlock(new Block(lb, rt));

        // Main tower

        height = Random.Range(maxHeight * 0.67f, maxHeight);

        lb = new Vector3(Random.Range(0f, baseSize.x * 0.33f), 0f, Random.Range(0f, baseSize.z * 0.33f));
        rt = new Vector3(baseSize.x * 0.67f + Random.Range(0f, baseSize.x * 0.33f), height, baseSize.z * 0.67f + Random.Range(0f, baseSize.z * 0.33f));

        addBlock(new Block(lb, rt));

        maxHeight = height;

        // Tiers towers

        for (int i = 0; i < tiersLimit; i++)
        {
            height = Random.Range(maxHeight * 0.67f, maxHeight);

            int direction = Random.Range(0, 4);

            switch (direction)
            {
                case 0:
                    lb = new Vector3(0.5f - Random.Range(0f, baseSize.x * 0.5f), 0f, 0.5f - Random.Range(0f, baseSize.z * 0.5f));
                    rt = new Vector3(0.5f + Random.Range(0f, baseSize.x * 0.5f), height, baseSize.z);
                    break;
                case 1:

                    lb = new Vector3(0.5f - Random.Range(0f, baseSize.x * 0.5f), 0f, 0.5f - Random.Range(0f, baseSize.z * 0.5f));
                    rt = new Vector3(baseSize.x, height, 0.5f + Random.Range(0f, baseSize.z * 0.5f));
                    break;
                case 2:
                    lb = new Vector3(0f, 0f, 0.5f - Random.Range(0f, baseSize.z * 0.5f));
                    rt = new Vector3(0.5f + Random.Range(0f, baseSize.x * 0.5f), height, 0.5f + Random.Range(0f, baseSize.z * 0.5f));
                    break;
                case 3:
                    lb = new Vector3(0.5f - Random.Range(0f, baseSize.x * 0.5f), 0f, 0f);
                    rt = new Vector3(0.5f + Random.Range(0f, baseSize.x * 0.5f), height, 0.5f + Random.Range(0f, baseSize.z * 0.5f));
                    break;
            }

            addBlock(new Block(lb, rt));

            maxHeight = height;
        }

        CreateMesh(vertices, triangles);
    }

    void OnDrawGizmos()
    {

    }

    void Update()
    {

    }

    void addBlock(Block block)
    {
        foreach (int i in block.getTriangles())
        {
            triangles[indiceTriangles++] = i + indiceVertices;
        }
        foreach (Vector3 v in block.getVertices())
        {
            vertices[indiceVertices++] = v;
        }
    }

    void CreateMesh(Vector3[] vertices, int[] triangles)
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Mesh msh = new Mesh();

        msh.vertices = vertices;
        msh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = msh;
        gameObject.GetComponent<MeshRenderer>().material = material;

        gameObject.GetComponent<MeshFilter>().mesh.RecalculateNormals();
    }
}
