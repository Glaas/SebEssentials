using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEngine;


namespace SebEssentials
{
    [CustomEditor(typeof(ItemAnimator))]
    public class ItemAnimatorEditor : Editor
    {
        private ItemAnimator.RotationDirection rot;

        public override void OnInspectorGUI()
        {
            ItemAnimator t = target as ItemAnimator;


            t.isFloating = EditorGUILayout.ToggleLeft(
                new GUIContent("Floating",
                    "Set to true if you want your object to bob up and down, and to make the parameters available."),
                t.isFloating, GuiStylesBank.boldStyle);

            if (t.isFloating)
            {
                EditorGUILayout.BeginVertical();
                t.intensity =
                    EditorGUILayout.Slider(
                        new GUIContent("Amplitude",
                            "Amplitude of the vertical movement. The higher the value, the higher the range. The middle will always be the starting position."),
                        t.intensity, 0, 30);
                t.speed = EditorGUILayout.Slider(
                    new GUIContent("Speed",
                        "The speed of the variation. The higher the value, the shorter the time will be to execute a complete cycle."),
                    t.speed, 0, 30);
                EditorGUILayout.EndVertical();
            }


            t.isRotating =
                EditorGUILayout.ToggleLeft(
                    new GUIContent("Rotating",
                        "Set it to true if you want your object to rotate, and have the rest of the parameters available."),
                    t.isRotating, GuiStylesBank.boldStyle);

            if (t.isRotating)
            {
                EditorGUILayout.BeginVertical();

                t.rotationDirection =
                    (ItemAnimator.RotationDirection) EditorGUILayout.EnumPopup(
                        new GUIContent("Rotation direction",
                            "Technically, you could just put a negative value to rotate in the opposite direction, but I wanted to have a fancy inspector."),
                        t.rotationDirection);
                t.rotateSpeed =
                    EditorGUILayout.Slider(
                        new GUIContent("Rotating speed", "I think that you get what this one is for :)"),
                        t.rotateSpeed, .1f, 30f);

                EditorGUILayout.EndVertical();
            }
        }
    }
}