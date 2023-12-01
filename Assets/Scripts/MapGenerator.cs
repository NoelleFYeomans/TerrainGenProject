using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    //variables
    public int mapWidth;
    public int mapHeight;

    public float noiseScale;

    public bool automaticUpdate;

    public void GenerateMap()
    {
        float[,] noiseMap = Noise.GenerateNoise(mapWidth, mapHeight, noiseScale);

        MapDisplay display = FindObjectOfType<MapDisplay>();
        display.DrawNoiseMap(noiseMap);
    }


}
