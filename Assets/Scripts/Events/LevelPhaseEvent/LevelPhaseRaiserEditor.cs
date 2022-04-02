    using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(LevelPhaseEvent))]
public class LevelPhaseRaiserEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        LevelPhaseEvent levelEvent = (LevelPhaseEvent)target;
        if (GUILayout.Button("Raise"))
        {
            levelEvent.Raise();
        }
    }
}
