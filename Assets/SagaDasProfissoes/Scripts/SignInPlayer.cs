using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Trilhas.Utilities;
using Trilhas.Controller;
using Trilhas.JsonFormat;

public class SignInPlayer : MonoBehaviour {
    private Connection _conn;
    [SerializeField] InputField userInput;
    [SerializeField] InputField pwdInput;
    void Start(){
        _conn = Connection.Instance;
    }

    public void SignInUser(){
        //StartCoroutine(_conn.Autenticate(userInput.text,pwdInput.text));
        StartCoroutine(WaitResponse());
    }

    IEnumerator WaitResponse(){
        //yield return new WaitWhile(() => !_conn.IsDone);
        yield return StartCoroutine(_conn.Autenticate(userInput.text, pwdInput.text));
        string jsonStr = _conn.JsonResponse; 
        if (jsonStr.Contains("erros"))
        {
            
			//Debug.Log("JSON: " + jsonStr);   
			try
			{
                JsonResponse jsonRx = JsonUtility.FromJson<JsonResponse>(jsonStr);
				foreach (var erro in jsonRx.erros)
					Debug.Log(erro.mensagem);
			}
			catch
			{
				JsonResponse jsonRx = new JsonResponse();
				jsonRx.erros = new List<Erro>();
                Erro erro = new Erro
                {
                    mensagem = "JSON: " + jsonStr
                };
                jsonRx.erros.Add(erro);
                Debug.LogWarning(jsonRx.erros[0].mensagem);
			}
            EventManager.TriggerEvent("ERROR");
        }
        else{
            //Debug.Log("JSON: " + jsonStr);   
			try
			{
				UserController userController = UserController.Instance;
                if (userController.ProcessUser(jsonStr))
                {
                    EventManager.TriggerEvent("OK");
                }
				//_conn.Token = userController.User.token;

			}
			catch
			{
				JsonResponse jsonRx = new JsonResponse();
                jsonRx.erros = new List<Erro>();
				Erro erro = new Erro
				{
					mensagem = "JSON: " + jsonStr
				};
				jsonRx.erros.Add(erro);
                EventManager.TriggerEvent("ERROR");
				Debug.LogWarning(jsonRx.erros[0].mensagem);
			}            
        }
    }
}
