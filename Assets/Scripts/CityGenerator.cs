using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CityGenerator : MonoBehaviour
{
	public Vector2 size;
	public BuildingGenerator building;

	void Start()
	{
        TextureGenerator window_textures = GetComponent<TextureGenerator>();

        Material material1 = new Material(Shader.Find("Unlit/Texture"));
        Material material2 = new Material(Shader.Find("Unlit/Texture"));

        window_textures.Generate();
        material1.mainTexture = window_textures.getTexture(1);
       
        material2.mainTexture = window_textures.getTexture(2);

        building.materials = new List<Material>();
        building.materials.Add(material1);
        building.materials.Add(material2);

        int i = 0;
		for (float x = -size.x / 2f; x < size.x / 2f; x++)
		{
			for (float y = -size.y / 2f; y < size.y / 2f; y++)
			{
				Instantiate(building, new Vector3(4f * x, 0f, 4f * y), Quaternion.identity);
				i++;
			}
		}
		Debug.Log(i + " buildings generated");


	}

	void Update()
	{
		if (Input.GetKey(KeyCode.R))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
}
