using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DialogueGraph : EditorWindow
{
    [MenuItem("Garph/Dialogue Graph")]
    public static void OpenDialogueGraphWindow()
    {
        var window = GetWindow<DialogueGraph>();
        window.titleContent = new GUIContent(text: "Dialogue Graph");
    }

}
