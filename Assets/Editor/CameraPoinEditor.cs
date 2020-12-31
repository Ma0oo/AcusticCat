using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraPoint))]
public class CameraPoinEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        CameraPoint cameraPoint = (CameraPoint)target;

        if (GUILayout.Button("Затестить камреу"))
            cameraPoint.SpawnTestCamera();

        if (GUILayout.Button("Поменять фов"))
            cameraPoint.ChangeFov();
    }
}
