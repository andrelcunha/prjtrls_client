using UnityEngine;
using UnityEditor;

using Trilhas.JsonFormat;


public class UserDataEditor : EditorWindow
{
    public User _user;
    Vector2 scrollPos;

    [MenuItem("Tools/User Data Editor")]
    static void Init()
    {
		UserDataEditor window = (UserDataEditor)GetWindow(typeof(UserDataEditor));
        window.Show();
    }

    void OnGUI()
    {
        if (_user != null)
        {
            SerializedObject serializedObject = new SerializedObject(this);
            SerializedProperty serializedProperty = serializedObject.FindProperty("_user");
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
            EditorGUILayout.PropertyField(serializedProperty, true);
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.EndScrollView();
            if (GUILayout.Button("Save User Data"))
            {
				DataController. SaveUser(_user);
            }
        }
        if (GUILayout.Button("Load Content Data"))
        {
			DataController. LoadUser(out _user);
        }
    }

    private void SaveUser()
    {
		string userAsJson = JsonUtility.ToJson(_user);
        PlayerPrefs.SetString("User", userAsJson);
        PlayerPrefs.Save();
    }

    private void LoadUser()
    {
		string userAsJson;
        if (PlayerPrefs.HasKey("User"))
        {
            userAsJson = PlayerPrefs.GetString("User");
        }
        else
        {
            userAsJson = Uteis.LoadJson("usuario");
        }
        _user = JsonUtility.FromJson<User>(userAsJson);
    }
}
