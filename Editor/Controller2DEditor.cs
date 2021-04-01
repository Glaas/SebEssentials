using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Controller2D))]
public class Controller2DEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Controller2D t = target as Controller2D;
        EditorGUILayout.BeginHorizontal();
        float temp = EditorGUIUtility.labelWidth;
        EditorGUIUtility.labelWidth = 60;
        t.collisionMask = EditorGUILayout.MaskField("Layer mask", t.collisionMask, UnityEditorInternal.InternalEditorUtility.layers);
        t.maxSlopeAngle = EditorGUILayout.FloatField("Max slope angle",t.maxSlopeAngle);
        EditorGUIUtility.labelWidth = temp;
        EditorGUILayout.EndHorizontal();
    }
}