using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityGenerator : MonoBehaviour
{
	public Vector2 size;
	public BuildingGenerator building;

	void Start()
	{
		for (int x = 0; x < size.x; x++)
			for (int y = 0; y < size.y; y++)
				Instantiate(building, new Vector3(3 * x, 0f, 3 * y), Quaternion.identity);
	}
}
