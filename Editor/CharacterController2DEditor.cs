using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(CharacterController2D))]
    public class CharacterController2DEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            CharacterController2D t = target as CharacterController2D;
            base.OnInspectorGUI();
            
         
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField("TIME FOR BUSINESS");
            EditorGUILayout.Separator();
            
            EditorGUILayout.LabelField("Speed, ");
        }
    }
