using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Trilhas.Utilities;
using Trilhas.JsonFormat;

public class SignUpPlayer : MonoBehaviour {
    private Connection _conn;
    [SerializeField] InputField userInput;
    [SerializeField] InputField pwdInput;
    //[SerializeField] InputField emaiInput;
    void Start(){
        _conn = Connection.Instance;
    }

    public void RegisterUser(){
        string jsonStr = JsonUtility.ToJson(CreatePlayerData());
        StartCoroutine(_conn.RegisterPlayer(jsonStr,pwdInput.text));

        //StartCoroutine( _conn.RegisterPlayer(
        //    "NONAME",
        //    userInput.text,
        //    pwdInput.text,
        //    emaiInput.text,
        //    "ef88bb50-cd6a-11e7-91b8-00051b7601a3","9999",1));
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

    private SignUpData CreatePlayerData(){
        SignUpData playerData = new SignUpData();
        playerData.nome = userInput.text;
        playerData.usuario = userInput.text;
        playerData.email = "sem_email@email.com";
        playerData.unidade = "ef88bb50-cd6a-11e7-91b8-00051b7601a3";
        playerData.matricula = "9999";
        playerData.ano = "1";
        return playerData;
    }
}

[Serializable]
public class SignUpData
{
    public string nome;
    public string usuario;
    public string email;
    public string unidade;
    public string matricula;
    public string ano;
}
