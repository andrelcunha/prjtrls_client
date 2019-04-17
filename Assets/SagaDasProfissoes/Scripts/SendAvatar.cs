using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Trilhas.Utilities;
using Trilhas.JsonFormat;

public class SendAvatar : MonoBehaviour {
    private Connection _conn;
	public UserAvatar avatarData;
    //[SerializeField] InputField emaiInput;
    void Start(){
        _conn = Connection.Instance;
    }

	public void SaveAvatar(){
		//string jsonStr = JsonUtility.ToJson(CreateAvatarData(gender, hairColor, skinColor));
		string jsonStr = JsonUtility.ToJson(avatarData);
		Debug.Log(jsonStr);
		StartCoroutine(_conn.SaveAvatar(jsonStr));
        StartCoroutine(WaitResponse());
    }

    IEnumerator WaitResponse(){
        yield return new WaitWhile(() => !_conn.IsDone);
        string jsonStr = _conn.JsonResponse; 
        Debug.Log(jsonStr);
        JsonResponse jsonRx;
        if (jsonStr.Contains("erros")){
            jsonRx = JsonUtility.FromJson<JsonResponse>(jsonStr);
            foreach (var erro in jsonRx.erros)
            //    Debug.Log(erro.mensagem);
            EventManager.TriggerEvent("ERROR");

        }
    }
}
