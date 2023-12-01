using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TexGen
{
    public static Texture2D TextureFromColourMap(Color[] colourMap, int width, int height)
    {
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colourMap);
        texture.Apply();
        return texture;
    }

    public static Texture2D TextureFromHeightMap(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);

        Color[] mapColour = new Color[width * height]; //array for the mapColour

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                mapColour[y * width + x] = Color.Lerp(Color.black, Color.white, heightMap[x, y]); //this choses a colour based on the value of noiseMap
            }
        }

        return TextureFromColourMap(mapColour, width, height);
    }
}
