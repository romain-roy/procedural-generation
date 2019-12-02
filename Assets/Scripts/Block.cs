using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{
    private Vector3[] vertices = new Vector3[8];
    private int[] triangles = new int[36];

    public Block(Vector3 lb, Vector3 rt)
    {
        vertices[0] = lb;
        vertices[1] = new Vector3(rt.x, lb.y, lb.z);
        vertices[2] = new Vector3(rt.x, lb.y, rt.z);
        vertices[3] = new Vector3(lb.x, lb.y, rt.z);
        
        vertices[4] = new Vector3(rt.x, rt.y, lb.z);
        vertices[5] = rt;
        vertices[6] = new Vector3(lb.x, rt.y, rt.z);
        vertices[7] = new Vector3(lb.x, rt.y, lb.z);

        triangles[0] = 0; triangles[1] = 4; triangles[2] = 1;
        triangles[3] = 1; triangles[4] = 4; triangles[5] = 5;

        triangles[6] = 1; triangles[7] = 5; triangles[8] = 2;
        triangles[9] = 2; triangles[10] = 5; triangles[11] = 6;

        triangles[12] = 2; triangles[13] = 6; triangles[14] = 3;
        triangles[15] = 3; triangles[16] = 6; triangles[17] = 7;

        triangles[18] = 3; triangles[19] = 7; triangles[20] = 0;
        triangles[21] = 0; triangles[22] = 7; triangles[23] = 4;

        triangles[24] = 7; triangles[25] = 6; triangles[26] = 4;
        triangles[27] = 4; triangles[28] = 6; triangles[29] = 5;

        triangles[30] = 0; triangles[31] = 1; triangles[32] = 2;
        triangles[33] = 0; triangles[34] = 2; triangles[35] = 3;
    }

    public Vector3[] getVertices()
    {
        return this.vertices;
    }

    public int[] getTriangles()
    {
        return this.triangles;
    }
}
