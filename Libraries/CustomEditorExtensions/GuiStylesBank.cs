using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SebEssentials
{
    public static class GuiStylesBank
    {
        public static readonly GUIStyle boldStyle;
        public static readonly GUIStyle italicStyle;
        public static readonly GUIStyle normalStyle;
        public static readonly GUIStyle boldStyleBIG;

        static GuiStylesBank()
        {
            boldStyleBIG = new GUIStyle()
            {
                fontStyle = FontStyle.Bold, fontSize = 15,
                normal = new GUIStyleState() {textColor = new Color(0.87f, 0.87f, 0.87f)}
            };
            normalStyle = new GUIStyle()
            {
                fontStyle = FontStyle.Italic, fontSize = 12,
                normal = new GUIStyleState() {textColor = new Color(0.87f, 0.87f, 0.87f)}
            };
            italicStyle = new GUIStyle()
            {
                fontStyle = FontStyle.Italic, fontSize = 12,
                normal = new GUIStyleState() {textColor = new Color(0.87f, 0.87f, 0.87f)}
            };
            boldStyle = new GUIStyle()
            {
                fontStyle = FontStyle.Bold, fontSize = 12,
                normal = new GUIStyleState() {textColor = new Color(0.87f, 0.87f, 0.87f)}
            };
        }

        public static GUIStyle CustomGuiStyle(FontStyle fontstyle, int size, Color color)
        {
            return new GUIStyle()
                {fontStyle = fontstyle, fontSize = size, normal = new GUIStyleState() {textColor = color}};
        }
    }
}