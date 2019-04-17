using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using _2MuchPines.Tools;
using Trilhas.JsonFormat;

namespace Trilhas.Controller
{

    public class AnswerController : MonoBehaviour
    {

        TextMeshProUGUI answerTMP;
        Button button;
        Resposta _answer;

        public Resposta Answer
        {
            get
            {
                return _answer;
            }

            set
            {
                _answer = value;
                answerTMP.text = _answer.texto;
                SetAction(_answer.codigo);
            }
        }

        void Start()
        {
            answerTMP = GetComponentInChildren<TextMeshProUGUI>();
            button = GetComponent<Button>();
        }

        void SetAction(string codigo)
        {
            //TODO:  add new listener each time that the object receives new content

            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(delegate
            {
                Debug.Log("setado botao " + codigo);
                QuizController.Instance.SaveResult(_answer);
                QuizController.Instance.ShowNextQuestion();
            });
        }
    }
}