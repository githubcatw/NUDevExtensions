using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TestNE : EditorWindow
{
    [MenuItem ("NUDev EE/Test %&t")]
    // Use this for initialization
    static void Init()
    {
        TestNE window = (TestNE)EditorWindow.GetWindow(typeof(TestNE), true, "Test");
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Welcome to NUDev Editor Extensions v1!");
        this.Repaint();
    }
}
