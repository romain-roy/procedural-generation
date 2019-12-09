using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid
{
    private Vector3[] vertices = new Vector3[12];
    private int[] triangles = new int[12];
    private Vector2[] uv = new Vector2[12];

    public Pyramid(Vector3 lb, Vector3 rt, float height)
    {
        /* VERTICES */

        vertices[0] = lb;
        vertices[1] = new Vector3(rt.x, lb.y, lb.z);
        vertices[2] = new Vector3(lb.x + (rt.x - lb.x) / 2, rt.y + height, lb.z + (rt.z - lb.z) / 2);

        vertices[3] = vertices[1];
        vertices[4] = new Vector3(rt.x, lb.y, rt.z);
        vertices[5] = vertices[2];

        vertices[6] = vertices[4];
        vertices[7] = new Vector3(lb.x, lb.y, rt.z);
        vertices[8] = vertices[2];

        vertices[9] = vertices[7];
        vertices[10] = lb;
        vertices[11] = vertices[2];

        /* UV */

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 0);
        uv[2] = new Vector2(0, 0);
        uv[3] = new Vector2(0, 0);
        uv[4] = new Vector2(0, 0);
        uv[5] = new Vector2(0, 0);
        uv[6] = new Vector2(0, 0);
        uv[7] = new Vector2(0, 0);
        uv[8] = new Vector2(0, 0);
        uv[9] = new Vector2(0, 0);
        uv[10] = new Vector2(0, 0);
        uv[11] = new Vector2(0, 0);

        /* TRIANGLES */

        triangles[0] = 0; triangles[1] = 2; triangles[2] = 1;
        triangles[3] = 3; triangles[4] = 5; triangles[5] = 4;
        triangles[6] = 6; triangles[7] = 8; triangles[8] = 7;
        triangles[9] = 9; triangles[10] = 11; triangles[11] = 10;
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
