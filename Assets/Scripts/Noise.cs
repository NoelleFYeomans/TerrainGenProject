using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    public static float[,] GenerateNoise(int width, int height, float scale)
    {
        float[,] noiseMap = new float[width, height];

        if (scale <= 0) //catches situations where scale is negative or zero
        {
            scale = 0.0001f; //clamp
        }

        for (int y= 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float sampleX = x / scale;
                float sampleY = y / scale;

                float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);
                noiseMap[x, y] = perlinValue;
            }
        }

        return noiseMap;
    }
}
