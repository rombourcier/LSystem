using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class LSystemeEditor : Editor
{
    MapGenerator map;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        map = (MapGenerator)target;
        if (GUILayout.Button("Interpolate l System"))
            map.ReadResult();
    }



}
