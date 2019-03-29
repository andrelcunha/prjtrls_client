using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Linq;

public class ChangeScene : MonoBehaviour
{
	//[Header("Tweener callbacks")]
	//[Tooltip("Function called on normal play")]
	public UnityEvent onSceneExit;
	int nextScene;
    /*
	readonly Dictionary<int, string> SceneName = new Dictionary<int, string>()
		{
		{0, "_00_TELA_INICIAL"},
		{1, "_01_NOVO_JOGO"},
		{2, "_02_CONTINUAR_JOGO"},
		{3,"_03_ESQUECI_SENHA"},
		{4,"_04_GAME_OPTIONS"},
		{5,"_05_TXT_APRESENTACAO_GAME"},
		{6,"_06_CONFIG_AVATAR"},
		{7,"_07_MAPA_MENU"},
		{8,"_08_TELA_MISSAO"},
		{9,"_09_MISSAO_TUTORIAL"},
		{10,"_10_MISSAO_CONCLUIDA"},
		{11,"_11_LOJA"},      
		{99,"Not_defined"},      
		};*/

	void Awake()
	{
	//	Scene m_Scene = SceneManager.GetActiveScene();
	//	int currentSceneInt = SceneName.FirstOrDefault(x => x.Value == m_Scene.name).Key;
	//	nextScene = SceneName
	//		.DefaultIfEmpty(SceneName.Last())
	//		.FirstOrDefault(x => x.Key == currentSceneInt + 1).Key;
	}

	//public void LoadScene()
	//{
	//	SceneManager.LoadScene(SceneName[nextScene]);
	//}

	public void LoadSelectedScene(int scene)
	{
		//SceneManager.LoadScene(SceneName[scene]);
		SceneManager.LoadScene(scene);
	}
}
