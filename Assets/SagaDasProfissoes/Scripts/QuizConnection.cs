using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using Trilhas.Utilities;
using Trilhas.Controller;
using Trilhas.JsonFormat;


public class QuizConnection : UnityEngine.MonoBehaviour {
    private Connection _conn;
    readonly string pedido = "ec9be43e-16d0-43b2-86b5-1d217e77fcae";
    void Start(){
        _conn = Connection.Instance;
    }

    public void QuizConnectionAtempt(){
        StartCoroutine(WaitResponse());
    }

    string GetPedido()
    {
        return pedido;
    }

    IEnumerator WaitResponse(){
        //yield return new WaitWhile(() => !_conn.IsDone);
        yield return StartCoroutine(_conn.GetPerguntasQuiz(GetPedido()));
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
                JsonResponse jsonRx = new JsonResponse
                {
                    erros = new List<Erro>()
                };
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
            //Debug.Log(string.Format("JSON: {0}", jsonStr));   
            try
            {
                QuizController quizController = QuizController.Instance;
                if (quizController.ProcessQuiz(jsonStr))
                {
                    //EventManager.TriggerEvent("OK");
                }
                //_conn.Token = userController.User.token;

            }
            catch
            {
                JsonResponse jsonRx = new JsonResponse
                {
                    erros = new List<Erro>()
                };
                Erro erro = new Erro
                {
                    mensagem = "JSON: " + jsonStr
                };
                jsonRx.erros.Add(erro);
                //EventManager.TriggerEvent("ERROR");
                Debug.LogWarning(jsonRx.erros[0].mensagem);
            }            
        }
    }
}
