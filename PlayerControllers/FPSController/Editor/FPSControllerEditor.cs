using UnityEditor;
using UnityEngine;
using SebEssentials;

[CustomEditor(typeof(FPSController))]
public class FPSControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        FPSController fps = (FPSController) target;
        
        
        EditorGUILayout.LabelField("Speed", GuiStylesBank.boldStyle);
        fps.walkingSpeed = EditorGUILayout.Slider("Walking speed", fps.walkingSpeed, .1f, 20);
        fps.runningSpeed = EditorGUILayout.Slider("Running speed", fps.runningSpeed, .1f, 20);
        EditorGUILayout.Separator();


        EditorGUILayout.LabelField("Jump", GuiStylesBank.boldStyle);
        fps.jumpSpeed = EditorGUILayout.Slider("Jump speed", fps.jumpSpeed, .1f, 30);
        fps.gravity = EditorGUILayout.Slider("Gravity", fps.gravity, .1f, 30);
        fps.allowAirControl = EditorGUILayout.Toggle("AllowAirControl", fps.allowAirControl);
        EditorGUILayout.Separator();

        EditorGUILayout.LabelField("Camera", GuiStylesBank.boldStyle);
        fps.lookSpeed = EditorGUILayout.Slider("Look sensitivity", fps.lookSpeed, .1f, 30);
        fps.lookXLimit = EditorGUILayout.Slider("X clamping", fps.lookXLimit, .1f, 360);
    

        EditorGUILayout.Separator();


        EditorGUILayout.LabelField("Control keys", GuiStylesBank.boldStyle);
        fps.runKey = (KeyCode) EditorGUILayout.EnumPopup("Shift", fps.runKey);
        fps.jumpKey = (KeyCode) EditorGUILayout.EnumPopup("Jump", fps.jumpKey);
    }
}