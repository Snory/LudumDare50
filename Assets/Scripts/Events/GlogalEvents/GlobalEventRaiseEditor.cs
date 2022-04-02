using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GlobalEvent))]
public class GlobalEventRaiseEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GlobalEvent globalEvent = (GlobalEvent) target;
        if (GUILayout.Button("Raise"))
        {
            globalEvent.Raise();
        }
    }

}
