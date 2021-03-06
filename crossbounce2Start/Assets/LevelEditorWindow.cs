﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;

public class LevelEditorWindow : EditorWindow {

    private static LevelEditorWindow instance;

    private float trackMovementSpeed = 1f;
    
    public static void ShowWindow()
    {
        instance = GetWindow<LevelEditorWindow>();
        instance.titleContent =  new GUIContent("Level Editor");
    }

    private void OnGUI()
    {

        EditorGUILayout.LabelField("Default track movement speed:");
        trackMovementSpeed = EditorGUILayout.FloatField(trackMovementSpeed);

        if (GUILayout.Button("Spawn Obstacle"))
        {

            // get the asset's GUID
            string[] obstacleGUIDs = AssetDatabase.FindAssets("wallBase");

            StringBuilder guidBuilder = new StringBuilder();
            foreach(string obstacleGuid in obstacleGUIDs)
            {
                guidBuilder.AppendLine(obstacleGuid);
            }
            //MonoBehaviour.print(guidBuilder.ToString());

            if(obstacleGUIDs.Length > 0)
            {
                string trueObstacleGuid = obstacleGUIDs[0];

                // Get the asset's path from the GUID
                string assetPath = AssetDatabase.GUIDToAssetPath(trueObstacleGuid);
                //MonoBehaviour.print(assetPath);

                //Fetch the object
                GameObject obstacleTemplate = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;

                //Spawn the object
                GameObject newObstacle = Instantiate(obstacleTemplate);
                newObstacle.name = obstacleTemplate.name;
                newObstacle.transform.position = new Vector3(0, 0, 0);
                newObstacle.transform.GetChild(0).GetComponent<track>().moveSpeed = trackMovementSpeed;
            }
        }

        if (GUILayout.Button("Spawn Target"))
        {

            // get the asset's GUID
            string[] targetGUIDs = AssetDatabase.FindAssets("target");

            StringBuilder guidBuilder = new StringBuilder();
            foreach (string targetGuid in targetGUIDs)
            {
                guidBuilder.AppendLine(targetGuid);
            }
            //MonoBehaviour.print(guidBuilder.ToString());

            if (targetGUIDs.Length > 0)
            {
                string trueTargetGuid = targetGUIDs[0];

                // Get the asset's path from the GUID
                string assetPath = AssetDatabase.GUIDToAssetPath(trueTargetGuid);
                //MonoBehaviour.print(assetPath);

                //Fetch the object
                GameObject targetTemplate = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;

                //Spawn the object
                GameObject newTarget = Instantiate(targetTemplate);
                newTarget.name = targetTemplate.name;
                newTarget.transform.position = new Vector3(0, 0, 0);
            }
        }
        if (GUILayout.Button("Spawn Crossbow"))
        {

            // get the asset's GUID
            string[] targetGUIDs = AssetDatabase.FindAssets("crossbowRoot");

            StringBuilder guidBuilder = new StringBuilder();
            foreach (string targetGuid in targetGUIDs)
            {
                guidBuilder.AppendLine(targetGuid);
            }
            //MonoBehaviour.print(guidBuilder.ToString());

            if (targetGUIDs.Length > 0)
            {
                string trueTargetGuid = targetGUIDs[0];

                // Get the asset's path from the GUID
                string assetPath = AssetDatabase.GUIDToAssetPath(trueTargetGuid);
                //MonoBehaviour.print(assetPath);

                //Fetch the object
                GameObject targetTemplate = AssetDatabase.LoadAssetAtPath(assetPath, typeof(GameObject)) as GameObject;

                //Spawn the object
                GameObject newTarget = Instantiate(targetTemplate);
                newTarget.name = targetTemplate.name;
                newTarget.transform.position = new Vector3(0,0,0);
            }
        }
		EditorGUILayout.LabelField("Use 'W''A''S''D', 'Q' and 'E', and the arrow keys to move, rotate, and scale selected objects, respectively.  Bounciness can be edited via the script attached to the object.");
		EditorGUILayout.LabelField("Track layout can be edited via the 'track' object inside of obstacles");
    }

}
