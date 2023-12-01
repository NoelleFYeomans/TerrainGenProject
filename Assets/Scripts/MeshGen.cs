using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MeshGen 
{
    public static MeshData GenerateTerrainMesh(float[,] heightMap)
    {
        int width = heightMap.GetLength(0);
        int height = heightMap.GetLength(1);
        
        //for centering the mesh
        float halfWidth = (width - 1) / 2f;
        float halfHeight = (height - 1) / 2f;

        MeshData meshData = new MeshData(width, height);
        int vertexIndex = 0;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                meshData.vertices[vertexIndex] = new Vector3(x - halfWidth, heightMap[x, y], y - halfHeight);
                //meshData.uvs[vertexIndex] = new Vector2(((width - 1) - x) / (float)width, y / (float)height);
                meshData.uvs[vertexIndex] = new Vector2(1f - (float)x / width, 1f - (float)y / height);

                if ((x < width - 1) && (y < height - 1))
                {
                    meshData.AddTriangle((vertexIndex), (vertexIndex + width + 1), (vertexIndex + width));
                    meshData.AddTriangle((vertexIndex + width + 1), (vertexIndex), (vertexIndex + 1));
                }

                vertexIndex++; //keeps track of where we are in 1D array
            }
        }

        return meshData;
    }
}

public class MeshData
{
    public Vector3[] vertices; //array storing vertex
    public int[] triangles; // array storing triangles

    public Vector2[] uvs;

    int triangleIndex;

    public MeshData(int meshWidth, int meshHeight)
    {
        vertices = new Vector3[meshWidth * meshHeight]; //gets number of vertices
        uvs = new Vector2[meshWidth * meshHeight]; //need one for each vertex
        triangles = new int[((meshWidth - 1) * (meshHeight - 1)) * 6]; //gets number of triangles
    }

    public void AddTriangle(int a, int b, int c)
    {
        triangles[triangleIndex] = a;
        triangles[triangleIndex + 1] = b;
        triangles[triangleIndex + 2] = c;
        triangleIndex += 3;
    }

    public Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.RecalculateNormals();
        return mesh;
    }
}
