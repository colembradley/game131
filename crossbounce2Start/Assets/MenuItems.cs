using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MenuItems : MonoBehaviour {

    [MenuItem("Tools/Level Creator/Show Level Editor")]
    private static void ShowLevelEditor()
    {
        LevelEditorWindow.ShowWindow();
    }

}
