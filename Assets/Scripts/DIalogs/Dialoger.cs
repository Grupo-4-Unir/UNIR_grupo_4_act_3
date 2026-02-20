using System;
using UnityEngine;
using UnityEngine.Events;

public class Dialoger : MonoBehaviour
{
  
    public string[] dialogs;

    public string npcName, dialogerName;

    [SerializeField]
    int  activeNode;

    public  UnityEvent OnDialogEnd;  
    
    public int ActiveNode { get => activeNode; set => activeNode = value; }
}


