using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder
{
	private int nbVertices, nbTriangles;
	private Vector3[] vertices;
	private int[] triangles;
	private Vector2[] uv;

	public Cylinder(Vector2 size, float height, int nbMeridians, int nbCoupures, int indiceCoupure)
	{
		nbVertices = (nbMeridians + 1 - nbCoupures * 2) * 2 + 2;
		nbTriangles = (nbMeridians - nbCoupures * 2) * 12;

		vertices = new Vector3[nbVertices];
		triangles = new int[nbTriangles];
		uv = new Vector2[nbVertices];

		float x, y, radiusX = size.x / 2, radiusY = size.y / 2;

		for (int i = 0, j = 0; i <= nbMeridians; i++, j++)
		{
			x = radiusX * Mathf.Cos(2 * Mathf.PI * i / nbMeridians);
			y = radiusY * Mathf.Sin(2 * Mathf.PI * i / nbMeridians);
			uv[j] = new Vector2(1f / nbMeridians * i, 0);
			uv[j + (nbMeridians + 1 - nbCoupures * 2)] = new Vector2(uv[j].x, 1);
			if (i == indiceCoupure || i == nbMeridians - indiceCoupure - nbCoupures) i += nbCoupures;
			vertices[j] = new Vector3(x + size.x / 2, 0, y + size.y / 2);
			vertices[j + (nbMeridians + 1 - nbCoupures * 2)] = new Vector3(x + size.x / 2, height, y + size.y / 2);
		}

		vertices[nbVertices - 2] = new Vector3(size.x / 2, 0, size.y / 2);
		vertices[nbVertices - 1] = new Vector3(size.x / 2, height, size.y / 2);
		uv[nbVertices - 2] = new Vector2(0, 0);
		uv[nbVertices - 1] = new Vector2(1, 1);

		int nbTrianglesCorps = nbTriangles - ((nbMeridians - nbCoupures * 2) * 6);

		for (int i = 0, k = 0, p = 0; i <= nbTrianglesCorps; i += 6, k++, p++)
		{
			if (p == (nbMeridians - nbCoupures * 2)) { p = 0; k++; }
			triangles[i] = triangles[i + 3] = k;
			triangles[i + 1] = k + (nbMeridians + 1 - nbCoupures * 2);
			triangles[i + 2] = triangles[i + 4] = k + (nbMeridians - nbCoupures * 2) + 2;
			triangles[i + 5] = k + 1;
		}

		for (int i = 0, k = 0; k < nbMeridians - nbCoupures * 2; i += 6, k++)
		{
			triangles[i + nbTrianglesCorps] = k;
			triangles[i + nbTrianglesCorps + 1] = k + 1;
			triangles[i + nbTrianglesCorps + 2] = nbVertices - 2;
			triangles[i + nbTrianglesCorps + 3] = k + (nbMeridians + 1 - nbCoupures * 2) + 1;
			triangles[i + nbTrianglesCorps + 4] = k + (nbMeridians + 1 - nbCoupures * 2);
			triangles[i + nbTrianglesCorps + 5] = nbVertices - 1;
		}
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
