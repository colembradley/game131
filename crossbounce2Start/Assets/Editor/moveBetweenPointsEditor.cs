using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MoveBetweenTwoPoints))]
[CanEditMultipleObjects]
public class moveBetweenPointsEditor : Editor {
	public override void OnInspectorGUI(){
		EditorGUILayout.LabelField ("Select the child of this object, 'track', to edit track layout.");
	}
}
