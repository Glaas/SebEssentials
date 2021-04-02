using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Todo list", menuName = "Todo list")]
public class TodosAndNotes : ScriptableObject
{
    public string title;
    public string content;
    public List<String> todos;

    public void Init(string title, string content, List<string> todos)
    {
        this.title = title;
        this.content = content;
        this.todos = todos;
    }
    
}