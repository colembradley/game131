using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(track))]
public class trackEditor : Editor
{
    
    void OnSceneGUI()
    {
        track targetScript = target as track;
        Handles.DrawLine(targetScript.startPoint.position, targetScript.endPoint.position);
    }
}
