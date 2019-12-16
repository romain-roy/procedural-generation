using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block
{
	private Vector3[] vertices = new Vector3[24];
	private int[] triangles = new int[36];
	private Vector2[] uv = new Vector2[24];

	public Block(Vector3 lb, Vector3 rt, bool withUV)
	{
		/* VERTICES */

		vertices[0] = lb;
		vertices[1] = new Vector3(rt.x, lb.y, lb.z);
		vertices[2] = new Vector3(lb.x, rt.y, lb.z);
		vertices[3] = new Vector3(rt.x, rt.y, lb.z);

		vertices[4] = vertices[1];
		vertices[5] = new Vector3(rt.x, lb.y, rt.z);
		vertices[6] = vertices[3];
		vertices[7] = rt;

		vertices[8] = vertices[5];
		vertices[9] = new Vector3(lb.x, lb.y, rt.z);
		vertices[10] = vertices[7];
		vertices[11] = new Vector3(lb.x, rt.y, rt.z);

		vertices[12] = vertices[9];
		vertices[13] = vertices[0];
		vertices[14] = vertices[11];
		vertices[15] = vertices[2];

		vertices[16] = vertices[2];
		vertices[17] = vertices[3];
		vertices[18] = vertices[11];
		vertices[19] = vertices[7];

		vertices[20] = vertices[9];
		vertices[21] = vertices[5];
		vertices[22] = vertices[0];
		vertices[23] = vertices[1];

		/* UV */
		if (withUV)
		{
			uv[0] = new Vector2(0, 0);
			uv[1] = new Vector2(1, 0);
			uv[2] = new Vector2(0, 1);
			uv[3] = new Vector2(1, 1);

			uv[4] = new Vector2(0, 0);
			uv[5] = new Vector2(1, 0);
			uv[6] = new Vector2(0, 1);
			uv[7] = new Vector2(1, 1);

			uv[8] = new Vector2(0, 0);
			uv[9] = new Vector2(1, 0);
			uv[10] = new Vector2(0, 1);
			uv[11] = new Vector2(1, 1);

			uv[12] = new Vector2(0, 0);
			uv[13] = new Vector2(1, 0);
			uv[14] = new Vector2(0, 1);
			uv[15] = new Vector2(1, 1);

			uv[16] = new Vector2(0, 0);
			uv[17] = new Vector2(0, 0);
			uv[18] = new Vector2(0, 0);
			uv[19] = new Vector2(0, 0);

			uv[20] = new Vector2(1, 1);
			uv[21] = new Vector2(1, 1);
			uv[22] = new Vector2(1, 1);
			uv[23] = new Vector2(1, 1);
		}
		else
		{
			for (int i = 0; i < 24; i++)
				uv[i] = new Vector2(0, 0);
		}

		/* TRIANGLES */

		triangles[0] = 0; triangles[1] = 2; triangles[2] = 1;
		triangles[3] = 1; triangles[4] = 2; triangles[5] = 3;

		triangles[6] = 4; triangles[7] = 6; triangles[8] = 5;
		triangles[9] = 5; triangles[10] = 6; triangles[11] = 7;

		triangles[12] = 8; triangles[13] = 10; triangles[14] = 9;
		triangles[15] = 9; triangles[16] = 10; triangles[17] = 11;

		triangles[18] = 12; triangles[19] = 14; triangles[20] = 13;
		triangles[21] = 13; triangles[22] = 14; triangles[23] = 15;

		triangles[24] = 16; triangles[25] = 18; triangles[26] = 17;
		triangles[27] = 17; triangles[28] = 18; triangles[29] = 19;

		triangles[30] = 20; triangles[31] = 22; triangles[32] = 21;
		triangles[33] = 21; triangles[34] = 22; triangles[35] = 23;
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
