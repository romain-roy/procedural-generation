using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid
{
    private Vector3[] vertices = new Vector3[5];
    private int[] triangles = new int[12];
    private Vector2[] uv = new Vector2[5];

    public Pyramid(Vector3 lb, Vector3 rt, float height)
    {
        /* VERTICES */

        vertices[0] = lb;
        vertices[1] = new Vector3(rt.x, lb.y, lb.z);
        vertices[2] = new Vector3(rt.x, lb.y, rt.z);
        vertices[3] = new Vector3(lb.x, lb.y, rt.z);
        vertices[4] = new Vector3(lb.x + (rt.x - lb.x) / 2, rt.y + height, lb.z + (rt.z - lb.z) / 2);

        /* UV */

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 0);
        uv[2] = new Vector2(0, 0);
        uv[3] = new Vector2(0, 0);
        uv[4] = new Vector2(0, 0);

        /* TRIANGLES */

        triangles[0] = 0; triangles[1] = 4; triangles[2] = 1;
        triangles[3] = 1; triangles[4] = 4; triangles[5] = 2;
        triangles[6] = 2; triangles[7] = 4; triangles[8] = 3;
        triangles[9] = 3; triangles[10] = 4; triangles[11] = 0;
    }

    public Vector3[] getVertices()
    {
        return this.vertices;
    }

    public int[] getTriangles()
    {
        return this.triangles;
    }

    public Vector2[] getUV()
    {
        return this.uv;
    }
}
