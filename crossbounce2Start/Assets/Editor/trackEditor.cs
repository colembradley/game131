using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(track))]
public class trackEditor : Editor {

    SerializedProperty useTrack;
    SerializedProperty moveSpeed;

    public float moveObstacleSpeed = 0.15f;
    public float rotateDegrees = 5.625f;
    public float scaleSpeed = 0.1f;

    private void OnEnable()
    {
        ArrayList sceneViews = SceneView.sceneViews;
        if (sceneViews.Count > 0) (sceneViews[0] as SceneView).Focus();
        useTrack = serializedObject.FindProperty("useTrack");
        moveSpeed = serializedObject.FindProperty("moveSpeed");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(useTrack);
        EditorGUILayout.PropertyField(moveSpeed);
        serializedObject.ApplyModifiedProperties();
    }

    private void OnSceneGUI()
    {
        Event currentEvent = Event.current;

        track objectScript = target as track;

        if (serializedObject.FindProperty("useTrack").boolValue == true)
        {
            Handles.DrawLine(objectScript.startPoint.position, objectScript.endPoint.position);

            switch (currentEvent.type)
            {
                case EventType.KeyDown:
                    if (currentEvent.keyCode != KeyCode.None)
                    {
					
                        if (currentEvent.keyCode == KeyCode.W)
                        {
                            objectScript.Move(new Vector3(0f, moveObstacleSpeed, 0f));
                            currentEvent.Use();
                        }
                        if (currentEvent.keyCode == KeyCode.A)
                        {
                            objectScript.Move(new Vector3(-moveObstacleSpeed, 0f, 0f));
                            currentEvent.Use();
                        }
                        if (currentEvent.keyCode == KeyCode.S)
                        {
                            objectScript.Move(new Vector3(0f, -moveObstacleSpeed, 0f));
                            currentEvent.Use();
                        }
                        if (currentEvent.keyCode == KeyCode.D)
                        {
                            objectScript.Move(new Vector3(moveObstacleSpeed, 0f, 0f));
                            currentEvent.Use();
                        }
                        if (currentEvent.keyCode == KeyCode.Q)
                        {
                            objectScript.Rotate(rotateDegrees);
                            currentEvent.Use();
                        }
                        if (currentEvent.keyCode == KeyCode.E)
                        {
                            objectScript.Rotate(-rotateDegrees);
                            currentEvent.Use();
                        }
                        if (currentEvent.keyCode == KeyCode.LeftArrow)
                        {
                            objectScript.Scale(new Vector3(-scaleSpeed, 0f, 0f));
                            currentEvent.Use();
                        }
                        if (currentEvent.keyCode == KeyCode.RightArrow)
                        {
                            objectScript.Scale(new Vector3(scaleSpeed, 0f, 0f));
                            currentEvent.Use();
                        }
                        if (currentEvent.keyCode == KeyCode.UpArrow)
                        {
                            objectScript.Scale(new Vector3(0f, scaleSpeed, 0f));
                            currentEvent.Use();
                        }
                        if (currentEvent.keyCode == KeyCode.DownArrow)
                        {
                            objectScript.Scale(new Vector3(0f, -scaleSpeed, 0f));
                            currentEvent.Use();
                        }
                    }
                    break;
                case EventType.KeyUp:
                    //MonoBehaviour.print("Key up: " + currentEvent.keyCode);
                    break;
                default:
                    break;
            }
        }
    }
}
