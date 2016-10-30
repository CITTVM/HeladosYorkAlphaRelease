using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(OpcionParalaje))]
public class EditorOpcionParalaje : Editor {

    private OpcionParalaje options;

    void Awake()
    {
        options = (OpcionParalaje)target;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Save Position"))
        {
            options.SavePosition();
            EditorUtility.SetDirty(options);
        }

        if (GUILayout.Button("Restore Position"))
            options.RestorePosition();
    }
}
