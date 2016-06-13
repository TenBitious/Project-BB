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
        if (!_evCtrl.useGravity)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(15);
            _evCtrl.inAirTime = EditorGUILayout.FloatField(new GUIContent("In Air Time", "Between 0 and 100."), _evCtrl.inAirTime);
            GUILayout.EndHorizontal();
        }
        _evCtrl.useVerticalVelocity = EditorGUILayout.Toggle("Use Vertical Velocity", _evCtrl.useVerticalVelocity);
        if (_evCtrl.useVerticalVelocity)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(15);
            _evCtrl.AngleForYAxis = EditorGUILayout.FloatField(new GUIContent("Angle For Y Axis", "Between 0 and 90 degree"), _evCtrl.AngleForYAxis);
            GUILayout.EndHorizontal();
        }
    }
}