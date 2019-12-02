using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
    public float size;
    [Range(1, 5)] public int tiersLimit;
    public Material material;

    private Vector3 lb, rb, lt, rt;
    private List<Vector3> tiers;

    void Start()
    {
        // Création d'un composant MeshFilter qui peut ensuite être visualisé

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        Vector3[] vertices = new Vector3[8];
        int[] triangles = new int[12];

        lb = new Vector3(0f, 0f, 0f);
        rb = new Vector3(size, 0f, 0f);
        rt = new Vector3(size, 0f, size);
        lt = new Vector3(0f, 0f, size);

        tiers = new List<Vector3>(tiersLimit * 4);

        vertices[0] = new Vector3(0.1f, 0f, 0.1f);
        vertices[1] = new Vector3(size - 0.1f, 0f, 0.1f);
        vertices[2] = new Vector3(size - 0.1f, 0f, size - 0.1f);
        vertices[3] = new Vector3(0.1f, 0f, size - 0.1f);

        // Création et remplissage du Mesh

        Mesh msh = new Mesh();

        msh.vertices = vertices;
        msh.triangles = triangles;

        // Remplissage du Mesh et ajout du material

        gameObject.GetComponent<MeshFilter>().mesh = msh;
        gameObject.GetComponent<MeshRenderer>().material = material;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawLine(lb, rb);
        Gizmos.DrawLine(rb, rt);
        Gizmos.DrawLine(lt, rt);
        Gizmos.DrawLine(lb, lt);

        Gizmos.color = Color.blue;

        for (int i = 0; i < 4; i++)
        {
            if (i != 0 && (i % 3) == 0)
                Gizmos.DrawLine(tiers[i], tiers[i - 3]);
            else
                Gizmos.DrawLine(tiers[i], tiers[i + 1]);
        }
    }

    void Update()
    {

    }
}
