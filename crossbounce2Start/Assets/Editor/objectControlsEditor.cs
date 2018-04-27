using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(objectControls))]
public class objectControlsEditor : Editor
{

    public float moveSpeed = 0.15f;
	public float rotateDegrees = 5.625f;
	public float scaleSpeed = 0.1f;

	SerializedProperty bounciness;

    private void OnEnable()
    {
        ArrayList sceneViews = SceneView.sceneViews;
        if (sceneViews.Count > 0) (sceneViews[0] as SceneView).Focus();
		bounciness = serializedObject.FindProperty("bounciness");
    }

	public override void OnInspectorGUI()
	{
		serializedObject.Update();
		EditorGUILayout.PropertyField(bounciness);
		serializedObject.ApplyModifiedProperties();
		objectControls objectScript = (objectControls)target;
		objectScript.UpdateBounciness ();
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
                        currentEvent.Use();
                    }
		            if (currentEvent.keyCode == KeyCode.A)
		            {
		                objectScript.Move(new Vector3(-moveSpeed, 0f, 0f));
                        currentEvent.Use();
                    }
		            if (currentEvent.keyCode == KeyCode.S)
		            {
		                objectScript.Move(new Vector3(0f, -moveSpeed, 0f));
                        currentEvent.Use();
                    }
		            if (currentEvent.keyCode == KeyCode.D)
		            {
		                objectScript.Move(new Vector3(moveSpeed, 0f, 0f));
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
