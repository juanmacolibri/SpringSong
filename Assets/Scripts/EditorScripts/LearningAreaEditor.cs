using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using EnumLib;

[CustomEditor(typeof(AreaScript))]
public class LearningAreaEditor : Editor
{

    GUIStyle title, mid;
    AreaScript myTarget;
    private void OnEnable()
    {
        myTarget = (AreaScript)target;
    }

    public override void OnInspectorGUI()
    {
        DrawContainer();
    }

    private void DrawContainer()
    {
        SetStyles();
        EditorGUILayout.LabelField("Area Type", title);
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Select area type:", mid);
        GUILayout.BeginVertical();
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        EditorGUILayout.Space();
        myTarget.AT = (AreaScript.AreaType)EditorGUILayout.EnumPopup(myTarget.AT, GUILayout.Width(200));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();
        GUILayout.BeginArea(new Rect((Screen.width / 2) - 50, (Screen.height / 2), 100, 100));
        GUILayout.EndArea();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        switch (myTarget.AT)
        {
            case AreaScript.AreaType.Learning:
                myTarget.MT = (MoveType)EditorGUILayout.EnumPopup("Move to learn:", myTarget.MT);
                myTarget.inps = (InputContainer)EditorGUILayout.ObjectField("Input Container:", myTarget.inps, typeof(InputContainer), true);
                break;
            case AreaScript.AreaType.Hiding:
                break;
            case AreaScript.AreaType.Bathing:
                break;
        }
    }

    private void SetStyles()
    {
        title = new GUIStyle(GUI.skin.label);
        title.alignment = TextAnchor.MiddleCenter;
        title.fontStyle = FontStyle.Bold;
        title.normal.textColor = Color.red;
        title.fontSize = 20;
        title.fixedHeight = 30;

        mid = new GUIStyle(GUI.skin.label);
        mid.alignment = TextAnchor.MiddleCenter;
    }
}
