using UnityEngine;


public class QuitGame : MonoBehaviour
{
    void Start()
	{
		
	}

	public static void Quit()
	{
		#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
        
	}
}
