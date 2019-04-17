using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Trilhas.JsonFormat;


public class LojaContentEditor : EditorWindow 
{
	public LojaContent  _content;
    Vector2 scrollPos;

    private string shopFilename = "loja";

    [MenuItem("Tools/LojaContent Editor")]
    static void Init()
    {
		LojaContentEditor window = (LojaContentEditor)GetWindow(typeof(LojaContentEditor));
        window.Show();
    }

    void OnGUI()
    {
		if (_content != null)
        {
            SerializedObject serializedObject = new SerializedObject(this);
			SerializedProperty serializedProperty = serializedObject.FindProperty("_content");
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
            EditorGUILayout.PropertyField(serializedProperty,true);
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.EndScrollView();
            if (GUILayout.Button("Save Content"))
            {
				SaveLojaContent();
            }
        }
		if (GUILayout.Button("Load Content"))
        {
			LoadLojaContent();
        }
    }

	private void SaveLojaContent()
    {
		string dataAsJson = JsonUtility.ToJson(_content);
		string filePath = Path.Combine(Application.dataPath,"Resources");
		filePath = Path.Combine(filePath, shopFilename + ".json");
		Debug.Log(filePath);
        File.WriteAllText(filePath, dataAsJson);
    }

	private void LoadLojaContent()
    {
        try
		{
			TextAsset file = Resources.Load<TextAsset>(shopFilename);
			string dataAsJon = file.ToString();
			_content = JsonUtility.FromJson<LojaContent>(dataAsJon);
		} catch (System.Exception ex) {
			Debug.LogError("Cannot load file");
			Debug.LogError(ex.ToString());
        }
    }
}
