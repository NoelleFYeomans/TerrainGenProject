using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

//this exists just to have a way to generate outside of runtime

[CustomEditor (typeof (MapGenerator))]
public class MapGenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        MapGenerator mGen = (MapGenerator)target;

        if (DrawDefaultInspector())
        {
            if (mGen.automaticUpdate)
            {
                mGen.GenerateMap();
            }
        }

        if (GUILayout.Button ("Generate"))
        {
            mGen.GenerateMap();
        }
    }
}
