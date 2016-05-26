using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Dodgeball))]
public class DodgeballEditor : Editor
{
    private bool AToggle = false;
    private Dodgeball _evCtrl = null;
    void OnEnable()
    {
        _evCtrl = (Dodgeball)target;
    }
    public override void OnInspectorGUI()
    {
        //blablabla
        base.OnInspectorGUI();
        _evCtrl.useGravity = EditorGUILayout.Toggle("Use Gravity", _evCtrl.useGravity);
        if (_evCtrl.useGravity)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(15);
            GUILayout.Label("In Air Time", GUILayout.Width(70));
            _evCtrl.inAirTime = EditorGUILayout.FloatField(_evCtrl.inAirTime);
            GUILayout.EndHorizontal();
        }
    }
}