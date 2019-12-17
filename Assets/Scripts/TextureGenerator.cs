using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class TextureGenerator : MonoBehaviour
{
    private RenderTexture texture1;
    private RenderTexture texture2;
    [SerializeField] private ComputeShader computeShader1 = null;
    [SerializeField] private ComputeShader computeShader2 = null;
    [SerializeField] private Color wallColor = Color.black;
    [SerializeField] private Color mainColor = Color.white;
    [SerializeField] private int width = 1024;
    [SerializeField] private int height = 1024;
    [SerializeField] private float noiseFrequency = 1f;

    public const int ThreadX = 8;
    public const int ThreadY = 8;

    private int randSeed;

    public void Generate()
    {
        width = Mathf.IsPowerOfTwo(width) == false ? Mathf.NextPowerOfTwo(width) : width;
        height = Mathf.IsPowerOfTwo(height) == false ? Mathf.NextPowerOfTwo(height) : height;

        texture1 = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32)
        {
            enableRandomWrite = true,
            useMipMap = false,
            filterMode = FilterMode.Trilinear,
            anisoLevel = 0,
            wrapMode = TextureWrapMode.Repeat,
            autoGenerateMips = false
        };
        texture1.Create();

        computeShader1.SetInt("randSeed", Mathf.Abs(UnityEngine.Random.Range(0, int.MaxValue)));
        computeShader1.SetFloat("noiseFrequency", noiseFrequency);
        computeShader1.SetVector("wallColor", wallColor);
        computeShader1.SetVector("mainColor", mainColor);
        computeShader1.SetTexture(0, "windowTex", texture1);

        computeShader1.Dispatch(0, this.width / ThreadX, this.height / ThreadY, 1);

        texture2 = new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32)
        {
            enableRandomWrite = true,
            useMipMap = false,
            filterMode = FilterMode.Trilinear,
            anisoLevel = 0,
            wrapMode = TextureWrapMode.Repeat,
            autoGenerateMips = false
        };
        texture2.Create();

        computeShader2.SetInt("randSeed", Mathf.Abs(UnityEngine.Random.Range(0, int.MaxValue)));
        computeShader2.SetFloat("noiseFrequency", noiseFrequency);
        computeShader2.SetVector("wallColor", wallColor);
        computeShader2.SetVector("mainColor", mainColor);
        computeShader2.SetTexture(0, "windowTex", texture2);

        computeShader2.Dispatch(0, this.width / ThreadX, this.height / ThreadY, 1);
    }

    public Texture getTexture(int i)
    {
        return i == 1 ? texture1 : texture2;
    }
}
