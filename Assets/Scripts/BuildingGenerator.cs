using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingGenerator : MonoBehaviour
{
	public Vector2 baseSize;
	public float maxHeight;
	public List<Material> materials;

	private Vector3[] vertices;
	private int[] triangles;
	private Vector2[] uv;
	private int indiceVertices = 0, indiceTriangles = 0, indiceUV = 0;

	void Start()
	{
		baseSize = new Vector2(Random.Range(1f, 3f), Random.Range(1f, 3f));
		maxHeight = Random.Range(maxHeight * 0.5f, maxHeight);

		int buildingType = Random.Range(0, 3);

		switch (buildingType)
		{
			case 0:
				MakeBlockBuilding();
				break;
			case 1:
				MakeRoundBuilding();
				break;
			case 2:
				MakeTowerBuilding();
				break;
		}
	}

	void MakeTowerBuilding()
	{
		int tiersLimit = Random.Range(2, 5);

		vertices = new Vector3[24 * tiersLimit + 12];
		triangles = new int[36 * tiersLimit + 12];
		uv = new Vector2[24 * tiersLimit + 12];

		float height = Random.Range(0.6f * maxHeight, maxHeight);
		float peakHeight = Random.Range(0.25f, 0.25f * height);
		height -= peakHeight;
		height /= 2;

		Vector3 lb = new Vector3(0, 0, 0);
		Vector3 rt = new Vector3(baseSize.x + 0.1f, 0, baseSize.y + 0.1f);

		Block block;

		for (int i = 0; i < tiersLimit; i++)
		{
			lb = new Vector3(lb.x + 0.1f, rt.y, lb.z + 0.1f);
			rt = new Vector3(rt.x - 0.1f, rt.y + height, rt.z - 0.1f);
			block = new Block(lb, rt);
			addShape(block.getTriangles(), block.getVertices(), block.getUV());
			height /= 2;
		}

		lb = new Vector3(lb.x + 0.1f, rt.y, lb.z + 0.1f);
		rt = new Vector3(rt.x - 0.1f, rt.y + height, rt.z - 0.1f);

		Pyramid pyramid = new Pyramid(lb, rt, peakHeight);
		addShape(pyramid.getTriangles(), pyramid.getVertices(), pyramid.getUV());

		CreateMesh(vertices, triangles, uv);
	}

	void MakeRoundBuilding()
	{
		int nbMeridians = 36;

		int nbCoupures = Random.Range(0, 11);
		int indiceCoupure = Random.Range(3, nbMeridians / 2 - nbCoupures - 3);

		vertices = new Vector3[(nbMeridians + 1 - nbCoupures * 2) * 4 + 50];
		triangles = new int[(nbMeridians - nbCoupures * 2) * 12 + 72];
		uv = new Vector2[(nbMeridians + 1 - nbCoupures * 2) * 4 + 50];

		float height = Random.Range(0.5f * maxHeight, maxHeight);

		Cylinder cylinder = new Cylinder(baseSize, height, nbMeridians, nbCoupures, indiceCoupure);
		addShape(cylinder.getTriangles(), cylinder.getVertices(), cylinder.getUV());

		Vector3 lb = new Vector3(baseSize.x / 2 - Random.Range(0.05f * baseSize.x, 0.25f * baseSize.x), height, baseSize.y / 2 - Random.Range(0.05f * baseSize.y, 0.25f * baseSize.y));
		Vector3 rt = new Vector3(lb.x - Random.Range(0.05f * baseSize.x, 0.25f * baseSize.x), height + Random.Range(0.05f, 0.1f), lb.z - Random.Range(0.05f * baseSize.y, 0.15f * baseSize.y));

		Block block = new Block(lb, rt);
		addShape(block.getTriangles(), block.getVertices(), block.getUV());

		lb = new Vector3(baseSize.x / 2 + Random.Range(0.05f * baseSize.x, 0.25f * baseSize.x), height, baseSize.y / 2 + Random.Range(0.05f * baseSize.y, 0.25f * baseSize.y));
		rt = new Vector3(lb.x + Random.Range(0.05f * baseSize.x, 0.25f * baseSize.x), height + Random.Range(0.05f, 0.1f), lb.z + Random.Range(0.05f * baseSize.y, 0.15f * baseSize.y));

		block = new Block(lb, rt);
		addShape(block.getTriangles(), block.getVertices(), block.getUV());

		CreateMesh(vertices, triangles, uv);
	}

	void MakeBlockBuilding()
	{
		// Initialisation

		float minHeight, height;
		Vector3 lbMain, rtMain;
		Vector3 lb, rt;

		List<int> directions = new List<int>();
		directions.Add(0); directions.Add(1); directions.Add(2); directions.Add(3);

		int tiersLimit = Random.Range(1, 5);

		vertices = new Vector3[24 * (tiersLimit + 2)];
		triangles = new int[36 * (tiersLimit + 2)];
		uv = new Vector2[24 * (tiersLimit + 2)];

		// Base

		minHeight = Random.Range(0.1f, 0.5f);

		lb = new Vector3(0f, 0f, 0f);
		rt = new Vector3(baseSize.x, minHeight, baseSize.y);

		Block block = new Block(lb, rt);
		addShape(block.getTriangles(), block.getVertices(), block.getUV());

		// Main tower

		height = Random.Range(maxHeight * 0.7f, maxHeight);

		lbMain = new Vector3(Random.Range(0f, baseSize.x * 0.4f), minHeight, Random.Range(0f, baseSize.y * 0.4f));
		rtMain = new Vector3(baseSize.x * 0.6f + Random.Range(0f, baseSize.x * 0.4f), height, baseSize.y * 0.6f + Random.Range(0f, baseSize.y * 0.4f));

		block = new Block(lbMain, rtMain);
		addShape(block.getTriangles(), block.getVertices(), block.getUV());

		maxHeight = height;

		// Tiers towers

		for (int i = 0; i < tiersLimit; i++)
		{
			height = Random.Range(maxHeight * 0.75f, maxHeight);

			int direction = directions[Random.Range(0, directions.Count)];
			directions.Remove(direction);

			switch (direction)
			{
				case 0:
					lb = new Vector3(Random.Range(lbMain.x, 0.5f * baseSize.x), minHeight, Random.Range(0.5f * baseSize.y, lbMain.z));
					rt = new Vector3(Random.Range(0.5f * baseSize.x, rtMain.x), height, baseSize.y);
					break;
				case 1:
					lb = new Vector3(Random.Range(lbMain.x, 0.5f * baseSize.x), minHeight, Random.Range(0.5f * baseSize.y, lbMain.z));
					rt = new Vector3(baseSize.x, height, Random.Range(rtMain.z, baseSize.y * 0.5f));
					break;
				case 2:
					lb = new Vector3(0f, minHeight, Random.Range(0.5f * baseSize.y, lbMain.z));
					rt = new Vector3(Random.Range(0.5f * baseSize.x, rtMain.x), height, Random.Range(rtMain.z, baseSize.y * 0.5f));
					break;
				case 3:
					lb = new Vector3(Random.Range(lbMain.x, 0.5f * baseSize.x), minHeight, 0f);
					rt = new Vector3(Random.Range(0.5f * baseSize.x, rtMain.x), height, Random.Range(rtMain.z, baseSize.y * 0.5f));
					break;
			}

			block = new Block(lb, rt);
			addShape(block.getTriangles(), block.getVertices(), block.getUV());

			maxHeight = height;
		}

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
		gameObject.GetComponent<MeshRenderer>().material = materials[(int)Random.Range(0, materials.Count)];

		gameObject.GetComponent<MeshFilter>().mesh.RecalculateNormals();
	}
}
