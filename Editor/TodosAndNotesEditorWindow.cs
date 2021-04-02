using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using SebEssentials;

public class TodosAndNotesEditorWindow : EditorWindow
{
    public string noteTitle;
    public string notes;
    private string[] todos;
    private int todoCap;
    private string path = "Assets/nameless.asset";


    private void Awake()
    {
        todos = new string[todoCap];
    }

    private void OnGUI()
    {
        GUILayout.Label("Todos and notes", EditorStyles.whiteLargeLabel);

        FirstBlock();

        List();


        Export();
    }

    private void List()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button(new GUIContent("-", "Remove a line"), EditorStyles.miniButton, GUILayout.Width(30),
            GUILayout.Height(30)))
        {
            todoCap--;
            Array.Resize(ref todos, todoCap);
        }

        EditorGUILayout.LabelField(todoCap.ToString(), EditorStyles.whiteLargeLabel, GUILayout.MaxWidth(40));
        
        if (GUILayout.Button(new GUIContent("+", "Add a line"), EditorStyles.miniButton, GUILayout.Width(30),
            GUILayout.Height(30)))
        {
            todoCap++;
            Array.Resize(ref todos, todoCap);
        }
        
        GUILayout.EndHorizontal();

        for (int i = 0; i < todoCap; i++)
        {
            EditorGUILayout.BeginHorizontal();
            todos[i] = EditorGUILayout.TextField(todos[i]);
            if (GUILayout.Button("X"))
            {
                var temp = todos.ToList();
                temp.RemoveAt(i);
                todos = new List<string>(temp).ToArray();
                todoCap--;
            }

            EditorGUILayout.EndHorizontal();
        }
    }

    private void Export()
    {
        GUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Path : ");
        path = EditorGUILayout.TextField(path);

        if (GUILayout.Button("Export as Scriptable Object"))
        {
            TodosAndNotes asset = CreateInstance<TodosAndNotes>();
            asset.title = noteTitle;
            asset.content = notes;
            asset.todos = todos.ToList();
            var temp = path;
            path = AssetDatabase.GenerateUniqueAssetPath($"{path}/{noteTitle}.asset");
            AssetDatabase.CreateAsset(asset, path);
            AssetDatabase.SaveAssets();
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
            path = String.Empty;
        }

        GUILayout.EndHorizontal();
    }

    private void FirstBlock()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Title");
        noteTitle = EditorGUILayout.TextField(noteTitle);
        EditorGUILayout.EndVertical();
        EditorGUILayout.BeginVertical();
        EditorGUILayout.LabelField("Content");
        notes = EditorGUILayout.TextArea(notes, GUILayout.Height(50));
        EditorGUILayout.EndVertical();
    }


    [MenuItem("Tools/SebEssentials/Todos")]
    public static void ShowWindow()
    {
        GetWindow<TodosAndNotesEditorWindow>("Todos and notes");
    }
}