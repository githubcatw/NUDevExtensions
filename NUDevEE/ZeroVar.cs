using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ZeroVar : EditorWindow
{
    GameObject zobj;
    bool rotToggle = false;
    [MenuItem("NUDev EE/Zero-out %&z")]
    // Use this for initialization
    static void Init()
    {
        ZeroVar window = (ZeroVar)EditorWindow.GetWindow(typeof(ZeroVar), true, "Zero-out");
        window.Show();
    }

    void OnGUI()
    {
        EditorGUILayout.LabelField("Please select an object in the hierarchy.");
        zobj = Selection.activeGameObject;
        if (zobj != null)
        {
            EditorGUILayout.LabelField("Press Clear to zero-out " + zobj.name + ".");
            rotToggle = EditorGUILayout.Toggle("Zero-out rotation", rotToggle);
            if (GUILayout.Button("Clear"))
            {
                zobj.transform.position = Vector3.zero;
                if (rotToggle == true)
                {
                    zobj.transform.rotation = new Quaternion(0, 0, 0, zobj.transform.rotation.w);
                }
            }
        }
        this.Repaint();
    }
}
