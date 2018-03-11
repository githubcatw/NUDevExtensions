using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AboutNEE : EditorWindow
{
    string[] funfacts;
    string fflabel;
    [MenuItem("NUDev EE/About...")]
    // Use this for initialization
    static void Init()
    {
        /*
        AboutNEE aboutnee = new AboutNEE();
        aboutnee.funfacts = new string[3];
        aboutnee.funfacts[0] = "Unity started as an iPhone only game engine";
        aboutnee.funfacts[1] = "Never trust the iOS simulator.";
        aboutnee.funfacts[2] = "Placeholder for fact #3";
        aboutnee.fflabel = "Fact: " + aboutnee.funfacts[Random.Range(0, 3)]; */
        AboutNEE window = (AboutNEE)EditorWindow.GetWindow(typeof(AboutNEE), true, "About...");
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("NUDev Editor Extensions 1.0 beta");
        EditorGUILayout.LabelField(" ");
        EditorGUILayout.LabelField("This software is open-source.");
        EditorGUILayout.LabelField(" ");
        EditorGUILayout.LabelField("Fork me on GitHub!");
        EditorGUILayout.LabelField("github.com/githubcatw/NUDevExtensions");
        //EditorGUILayout.LabelField(" ");
        //EditorGUILayout.LabelField(fflabel);
        this.Repaint();
    }
}

