using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(objectControls))]
public class objectControlsEditor : Editor
{

    public float moveSpeed = 0.2f;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    private void OnEnable()
    {
        ArrayList sceneViews = SceneView.sceneViews;
        if (sceneViews.Count > 0) (sceneViews[0] as SceneView).Focus();
    }

    private void OnSceneGUI()
    {
        Event currentEvent = Event.current;

        objectControls objectScript = (objectControls)target;

        switch (currentEvent.type)
        {
            case EventType.KeyDown:
                if (currentEvent.keyCode != KeyCode.None)
                {
                    if(currentEvent.keyCode == KeyCode.W)
                    {
                        objectScript.Move(new Vector3(0f,moveSpeed,0f));
                    }
                    if (currentEvent.keyCode == KeyCode.A)
                    {
                        objectScript.Move(new Vector3(-moveSpeed, 0f, 0f));
                    }
                    if (currentEvent.keyCode == KeyCode.S)
                    {
                        objectScript.Move(new Vector3(0f, -moveSpeed, 0f));
                    }
                    if (currentEvent.keyCode == KeyCode.D)
                    {
                        objectScript.Move(new Vector3(moveSpeed, 0f, 0f));
                    }
                }
                currentEvent.Use();
                break;
            case EventType.KeyUp:
                //MonoBehaviour.print("Key up: " + currentEvent.keyCode);
                currentEvent.Use();
                break;
            default:
                break;
        }
    }

}
